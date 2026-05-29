using ActiveSpace.Models;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Forms.DialogForms;
using ActiveSpaceSystem.Forms.GridStyle;
using ActiveSpaceSystem.Forms.Views;
using ActiveSpaceSystem.Models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.SideForms
{
    public partial class PaymentForm : Form
    {
        private BindingList<PaymentViewModel> paymentsList;
        private PaymentGridRenderer gridRenderer;

        public PaymentForm()
        {
            InitializeComponent();
            this.TopLevel = false;
            gridRenderer = new PaymentGridRenderer();
            SetupGrid();
            this.Load += PaymentForm_Load;
            bookingDetailsCard.BtnPayment.Click += btn_payment_Click;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvReservation.ClearSelection();
        }

        private void UpdateCards()
        {
            string rlm = "\u200F";
            DateTime selectedDate = dtpPaymentDate.Value.Date;

            // Get total debt and count of pending bookings on the selected date
            double totalDebt = paymentsList.Where(p => p.Remaining > 0).Sum(p => p.Remaining);
            int pendingCount = paymentsList.Count(p => p.Remaining > 0);

            TotalDebtsCard.ValueText = $"{rlm}{totalDebt:N2} د.ل";
            TotalDebtsCard.SubValueText = $"{rlm}{pendingCount} حجز";

            // Update daily income and down payments cards
            UpdateDailyIncomeStats();
            UpdateDownPaymentsCard();
        }

        private void UpdateDownPaymentsCard()
        {
            string rlm = "\u200F";
            DateTime selectedDate = dtpPaymentDate.Value.Date;

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                // Get the first payment of each booking made today
                string query = @"
                    SELECT ISNULL(SUM(p.amount), 0), COUNT(DISTINCT p.booking_ref)
                    FROM PAYMENTS p
                    WHERE p.payment_date = @selectedDate
                      AND p.payment_ref = (
                          SELECT TOP 1 payment_ref 
                          FROM PAYMENTS 
                          WHERE booking_ref = p.booking_ref 
                          ORDER BY payment_date, payment_time
                      )";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@selectedDate", selectedDate);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            double totalRealDeposit = Convert.ToDouble(reader.GetDecimal(0));
                            int count = reader.GetInt32(1);
                            DownPaymentCard.ValueText = $"{rlm}{totalRealDeposit:N2} د.ل";
                            DownPaymentCard.SubValueText = $"{rlm}{count} حجز";
                        }
                    }
                }
            }
        }

        private void UpdateDailyIncomeStats()
        {
            string rlm = "\u200F";
            DateTime selectedDate = dtpPaymentDate.Value.Date;

            double todayTotal = 0;
            double yesterdayTotal = 0;

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string qToday = "SELECT ISNULL(SUM(amount), 0) FROM PAYMENTS WHERE payment_date = @today";
                using (var cmd = new SqlCommand(qToday, conn))
                {
                    cmd.Parameters.AddWithValue("@today", selectedDate);
                    todayTotal = Convert.ToDouble(cmd.ExecuteScalar());
                }

                string qYesterday = "SELECT ISNULL(SUM(amount), 0) FROM PAYMENTS WHERE payment_date = @yesterday";
                using (var cmd = new SqlCommand(qYesterday, conn))
                {
                    cmd.Parameters.AddWithValue("@yesterday", selectedDate.AddDays(-1));
                    yesterdayTotal = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            double percentageDiff = 0;
            if (yesterdayTotal > 0)
            {
                percentageDiff = (todayTotal - yesterdayTotal) / yesterdayTotal * 100;
            }
            else if (todayTotal > 0)
            {
                percentageDiff = 100;
            }

            DailyIncomeCard.ValueText = $"{rlm}{todayTotal:N2} د.ل";

            if (percentageDiff >= 0)
            {
                DailyIncomeCard.SubValueColor = Color.FromArgb(40, 167, 69);
                DailyIncomeCard.SubValueText = $"{rlm}منذ الأمس {rlm}+%{percentageDiff:0}";
            }
            else
            {
                DailyIncomeCard.SubValueColor = Color.FromArgb(220, 53, 69);
                DailyIncomeCard.SubValueText = $"{rlm}منذ الأمس {rlm}-%{Math.Abs(percentageDiff):0}";
            }
        }

        private void btn_payment_Click(object sender, EventArgs e)
        {
            string rawBookingID = bookingDetailsCard.BookingID;

            // Determine the actual ID and whether it's a contract
            string idForPayment;
            string idForRefresh;
            if (rawBookingID.StartsWith("MC-"))
            {
                // It's a contract: pass MC-CONT-xxx to AddPaymentForm
                idForPayment = rawBookingID;
                idForRefresh = rawBookingID.Substring(3); // CONT-xxx
            }
            else
            {
                // It's a booking: strip B- prefix if present
                idForRefresh = rawBookingID.StartsWith("B-") ? rawBookingID.Substring(2) : rawBookingID;
                idForPayment = idForRefresh;
            }

            if (!string.IsNullOrEmpty(idForPayment))
            {
                using (var paymentDialog = new AddPaymentForm())
                {
                    paymentDialog.SetBookingData(idForPayment, $"{bookingDetailsCard.RemainingAmount}");

                    if (paymentDialog.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                        ShowBookingDetails(idForRefresh);
                        dgvReservation.ClearSelection();
                    }
                }
            }
        }

        private void SetupGrid()
        {
            dgvReservation.DataSource = null;
            dgvReservation.Rows.Clear();

            dgvReservation.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvReservation.EditMode = DataGridViewEditMode.EditProgrammatically;

            dgvReservation.CellPainting += dgvReservation_CellPainting;
            dgvReservation.CellClick += dgvReservation_CellClick;

            AddColumns();
        }

        private void AddColumns()
        {
            dgvReservation.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BookingID",
                HeaderText = "رقم الحجز",
                Name = "BookingID",
                Width = 100
            });

            dgvReservation.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerName",
                HeaderText = "العميل",
                Name = "CustomerName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True }
            });

            dgvReservation.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BookingDate",
                HeaderText = "التاريخ",
                Name = "BookingDate",
                Width = 110
            });

            dgvReservation.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalAmount",
                HeaderText = "المبلغ الكلي",
                Name = "TotalAmount",
                Width = 110
            });

            dgvReservation.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PaidAmount",
                HeaderText = "المدفوع",
                Name = "PaidAmount",
                Width = 100
            });

            dgvReservation.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Remaining",
                HeaderText = "المتبقي",
                Name = "Remaining",
                Width = 100
            });

            dgvReservation.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "الحالة",
                Name = "Status",
                Width = 130
            });

            dgvReservation.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ActionBtn",
                HeaderText = "الإجراء",
                Width = 120
            });

            dgvReservation.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PaidAt",
                Name = "PaidAt",
                HeaderText = "الإجراء",
                Width = 0,
                Visible = false
            });

            dgvReservation.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Booking",
                Name = "Booking",
                HeaderText = "الإجراء",
                Width = 0,
                Visible = false
            });
        }

        public void LoadData()
        {
            DateTime selectedDate = dtpPaymentDate.Value.Date;
            var dict = new Dictionary<string, PaymentViewModel>();

            // 1. Process all bookings on the selected date
            var bookingsOnDate = Booking.GetAll()
                .Where(b => b.BookingDate.Date == selectedDate)
                .ToList();

            foreach (var booking in bookingsOnDate)
            {
                if (string.IsNullOrEmpty(booking.ContractRef))
                {
                    // Regular booking
                    double remaining = Payment.CalculateRemaining(booking.BookingRef);
                    double totalAmt = booking.TotalAmount;
                    double paid = totalAmt - remaining;

                    dict[booking.BookingRef] = new PaymentViewModel
                    {
                        BookingID = booking.BookingID,
                        CustomerName = booking.Customer?.FullName ?? "غير معروف",
                        BookingDate = booking.BookingDate.ToString("yyyy-MM-dd"),
                        TotalAmount = totalAmt,
                        PaidAmount = paid,
                        Remaining = remaining,
                        Status = booking.Status,
                        PaidAt = booking.BookingDate,
                        Booking = booking
                    };
                }
                else
                {
                    // Contract booking: show the contract itself
                    var mc = MonthlyContract.GetByRef(booking.ContractRef);
                    if (mc != null)
                    {
                        double remaining = Payment.CalculateRemainingForContract(mc.ContractRef);
                        double contractTotal = (double)mc.MonthlyValue;
                        double contractPaid = contractTotal - remaining;

                        dict[mc.ContractRef] = new PaymentViewModel
                        {
                            BookingID = mc.ContractRef,
                            CustomerName = mc.Customer?.FullName ?? "غير معروف",
                            BookingDate = booking.BookingDate.ToString("yyyy-MM-dd"),
                            TotalAmount = contractTotal,
                            PaidAmount = contractPaid,
                            Remaining = remaining,
                            Status = (remaining <= 0) ? BookingStatus.Completed : BookingStatus.Confirmed,
                            PaidAt = booking.BookingDate,
                            Booking = new Booking
                            {
                                BookingRef = mc.ContractRef,
                                CustomerPhoneNumber = mc.CustomerPhoneNumber,
                                CourtName = mc.CourtName,
                                BookingDate = booking.BookingDate,
                                Price = mc.MonthlyValue,
                                Status = (remaining <= 0) ? BookingStatus.Completed : BookingStatus.Confirmed
                            }
                        };
                    }
                }
            }

            // 2. Process all actual payments made on this date
            var paymentsOnDate = Payment.GetAll()
                .Where(p => p.PaymentDate.Date == selectedDate)
                .ToList();

            foreach (var payment in paymentsOnDate)
            {
                if (!string.IsNullOrEmpty(payment.BookingRef))
                {
                    if (!dict.ContainsKey(payment.BookingRef))
                    {
                        var b = Booking.GetByRef(payment.BookingRef);
                        if (b != null)
                        {
                            double remaining = Payment.CalculateRemaining(b.BookingRef);
                            double totalAmt = b.TotalAmount;
                            double paid = totalAmt - remaining;

                            dict[b.BookingRef] = new PaymentViewModel
                            {
                                BookingID = b.BookingID,
                                CustomerName = b.Customer?.FullName ?? "غير معروف",
                                BookingDate = b.BookingDate.ToString("yyyy-MM-dd"),
                                TotalAmount = totalAmt,
                                PaidAmount = paid,
                                Remaining = remaining,
                                Status = b.Status,
                                PaidAt = payment.PaidAt,
                                Booking = b
                            };
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(payment.ContractRef))
                {
                    if (!dict.ContainsKey(payment.ContractRef))
                    {
                        var mc = MonthlyContract.GetByRef(payment.ContractRef);
                        if (mc != null)
                        {
                            double remaining = Payment.CalculateRemainingForContract(mc.ContractRef);
                            double contractTotal = (double)mc.MonthlyValue;
                            double contractPaid = contractTotal - remaining;

                            dict[mc.ContractRef] = new PaymentViewModel
                            {
                                BookingID = mc.ContractRef,
                                CustomerName = mc.Customer?.FullName ?? "غير معروف",
                                BookingDate = mc.StartDate.ToString("yyyy-MM-dd"),
                                TotalAmount = contractTotal,
                                PaidAmount = contractPaid,
                                Remaining = remaining,
                                Status = (remaining <= 0) ? BookingStatus.Completed : BookingStatus.Confirmed,
                                PaidAt = payment.PaidAt,
                                Booking = new Booking
                                {
                                    BookingRef = mc.ContractRef,
                                    CustomerPhoneNumber = mc.CustomerPhoneNumber,
                                    CourtName = mc.CourtName,
                                    BookingDate = mc.StartDate,
                                    Price = mc.MonthlyValue,
                                    Status = (remaining <= 0) ? BookingStatus.Completed : BookingStatus.Confirmed
                                }
                            };
                        }
                    }
                }
            }

            paymentsList = new BindingList<PaymentViewModel>(dict.Values.ToList());
            dgvReservation.DataSource = paymentsList;

            UpdateCards();
        }

        private void dgvReservation_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = dgvReservation.Columns[e.ColumnIndex].Name;

            if (columnName == "Status")
            {
                BookingStatus status = (BookingStatus)e.Value;
                gridRenderer.RenderStatusCell(e, status);
            }
            else if (columnName == "ActionBtn")
            {
                double remaining = Convert.ToDouble(dgvReservation.Rows[e.RowIndex].Cells["Remaining"].Value);
                gridRenderer.RenderActionColumn(e, remaining);
            }
        }

        private void dgvReservation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var item = dgvReservation.Rows[e.RowIndex].DataBoundItem as PaymentViewModel;
            if (item == null) return;

            string columnName = dgvReservation.Columns[e.ColumnIndex].Name;

            if (columnName == "ActionBtn")
            {
                if (item.Remaining > 0)
                {
                    // Determine if this is a contract or a booking
                    string payId = item.BookingID.StartsWith("CONT-") ? $"MC-{item.BookingID}" : item.BookingID;

                    using (var paymentDialog = new AddPaymentForm())
                    {
                        paymentDialog.SetBookingData(payId, $"{item.Remaining} د.ل");

                        if (paymentDialog.ShowDialog() == DialogResult.OK)
                        {
                            LoadData();
                            ShowBookingDetails(item.BookingID);
                            dgvReservation.ClearSelection();
                        }
                    }
                }
            }
            else
            {
                ShowBookingDetails(item.BookingID);
                bookingDetailsCard.BtnPayment.Visible = item.Remaining > 0;
            }
        }

        private void ShowBookingDetails(string bookingId)
        {
            var booking = Booking.GetByRef(bookingId);
            if (booking != null)
            {
                double paid = booking.TotalAmount - Payment.CalculateRemaining(booking.BookingRef);
                double remaining = booking.TotalAmount - paid;

                // If this booking belongs to a contract, show contract details instead
                if (!string.IsNullOrEmpty(booking.ContractRef))
                {
                    ShowBookingDetails(booking.ContractRef);
                    return;
                }

                bookingDetailsCard.BookingID = $"B-{booking.BookingRef}";
                bookingDetailsCard.CustomerName = booking.Customer?.FullName ?? "غير معروف";
                bookingDetailsCard.PhoneNumber = booking.Customer?.Phone ?? "---";

                bookingDetailsCard.TotalAmount = $"{booking.TotalAmount} د.ل";
                bookingDetailsCard.PaidAmount = $"{paid} د.ل";
                bookingDetailsCard.RemainingAmount = $"{remaining} د.ل";
                bookingDetailsCard.DepositAmount = $"{booking.Deposit} د.ل";

                bookingDetailsCard.IsItemSelected = true;
                bookingDetailsCard.RemainingColor = remaining > 0 ? Color.Red : Color.Green;
                bookingDetailsCard.BtnPayment.Visible = remaining > 0;
            }
            else
            {
                var mc = MonthlyContract.GetByRef(bookingId);
                if (mc != null)
                {
                    double remaining = Payment.CalculateRemainingForContract(mc.ContractRef);
                    double paid = (double)mc.MonthlyValue - remaining;

                    bookingDetailsCard.BookingID = $"MC-{mc.ContractRef}";
                    bookingDetailsCard.CustomerName = mc.Customer?.FullName ?? "غير معروف";
                    bookingDetailsCard.PhoneNumber = mc.Customer?.Phone ?? "---";

                    bookingDetailsCard.TotalAmount = $"{mc.MonthlyValue} د.ل";
                    bookingDetailsCard.PaidAmount = $"{paid} د.ل";
                    bookingDetailsCard.RemainingAmount = $"{remaining} د.ل";
                    bookingDetailsCard.DepositAmount = "0.00 د.ل";

                    bookingDetailsCard.IsItemSelected = true;
                    bookingDetailsCard.RemainingColor = remaining > 0 ? Color.Red : Color.Green;
                    bookingDetailsCard.BtnPayment.Visible = remaining > 0;
                }
            }
        }

        private void btnBackDate_Click(object sender, EventArgs e)
        {
            dtpPaymentDate.Value = dtpPaymentDate.Value.AddDays(-1);
        }

        private void btnForwardDate_Click(object sender, EventArgs e)
        {
            dtpPaymentDate.Value = dtpPaymentDate.Value.AddDays(1);
        }

        private void dtpPaymentDate_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
            bookingDetailsCard.IsItemSelected = false;
            dgvReservation.ClearSelection();
        }
    }
}