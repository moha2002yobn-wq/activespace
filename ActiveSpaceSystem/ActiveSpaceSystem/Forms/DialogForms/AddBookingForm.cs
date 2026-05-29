using ActiveSpace.Models;
using ActiveSpaceSystem.CustomItems;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Forms.SideForms;
using ActiveSpaceSystem.Forms.Views;
using ActiveSpaceSystem.Helpers;
using ActiveSpaceSystem.Models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.DialogForms
{
    public partial class AddBookingForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        private Customer customer;
        private BookingViewModel _bookingToEdit;

        public AddBookingForm()
        {
            InitializeComponent();
            lblTitle.Text = "إضافة حجز جديد";
        }

        public AddBookingForm(BookingViewModel booking) : this()
        {
            _bookingToEdit = booking;
            lblTitle.Text = "تعديل بيانات الحجز";
            roundedButton1.Text = "تحديث الحجز";
            btnAddBookingCard.Visible = false; // Cannot add other bookings when editing a single booking
        }

        private void AddBookingForm_Load(object sender, EventArgs e)
        {
            customer = null;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));

            if (_bookingToEdit == null)
            {
                // Create one initial booking card only if one wasn't already created (e.g. via scheduler)
                if (flowBookings.Controls.Count == 0)
                {
                    BtnAddBookingCard_Click(this, EventArgs.Empty);
                }
            }
            else
            {
                FillData();
            }
        }

        private void FillData()
        {
            if (_bookingToEdit == null) return;

            try
            {
                txtPhone.Texts = _bookingToEdit.Phone ?? "";
                txtName.Texts = _bookingToEdit.CustomerName ?? "";
                txtName.Enabled = false;
                txtPhone.Enabled = false;

                var bookingModel = Booking.GetByRef(_bookingToEdit.BookingID);
                if (bookingModel != null)
                {
                    // Create booking card and populate it
                    var card = new BookingItemControl();
                    card.Index = 1;
                    card.Width = 730;
                    card.ShowDeleteButton = false; // Cannot delete the single edited booking card

                    card.TotalPriceChanged += (s, ev) => RecalculateAllTotals();
                    card.SetBookingData(bookingModel);

                    flowBookings.Controls.Add(card);

                    // Load deposit
                    deposittxt.Texts = bookingModel.Deposit.ToString("0.##");
                }

                RecalculateAllTotals();
                UpdateBookingsHeaderCount();
                this.PerformLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل بيانات الحجز: " + ex.Message);
            }
        }

        private void RecalculateAllTotals()
        {
            double total = 0.0;
            foreach (var card in flowBookings.Controls.OfType<BookingItemControl>())
            {
                total += card.TotalPrice;
            }
            txtTotalAll.Texts = total.ToString("N0");
        }

        public void loadCourtData(string courtName, string TypeName, DateTime date, DateTime start, DateTime End)
        {
            if (flowBookings.Controls.Count == 0)
            {
                BtnAddBookingCard_Click(this, EventArgs.Empty);
            }

            var card = flowBookings.Controls.OfType<BookingItemControl>().FirstOrDefault();
            if (card != null)
            {
                card.dtpBookingDate.Value = date;
                card.dtpStartTime.Value = start;
                card.dtpEndTime.Value = End;
                
                card.cmbCourtType.SelectedValue = TypeName;
                
                // Invoke courts loading
                var method = card.GetType().GetMethod("LoadCourtsForType", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                method?.Invoke(card, null);
                
                card.cmbCourt.SelectedValue = courtName;
            }
        }

        private void BtnAddBookingCard_Click(object sender, EventArgs e)
        {
            var card = new BookingItemControl();
            card.Index = flowBookings.Controls.Count + 1;
            card.Width = 730;

            card.TotalPriceChanged += (s, ev) => RecalculateAllTotals();
            card.DeleteClicked += (s, ev) =>
            {
                flowBookings.Controls.Remove(card);
                // Re-index remaining cards
                int idx = 1;
                foreach (var c in flowBookings.Controls.OfType<BookingItemControl>())
                {
                    c.Index = idx++;
                }
                RecalculateAllTotals();
                UpdateBookingsHeaderCount();
                this.PerformLayout();
            };

            flowBookings.Controls.Add(card);
            RecalculateAllTotals();
            UpdateBookingsHeaderCount();
            this.PerformLayout();
        }

        private bool IsBookingConflict(Court court, DateTime date, TimeSpan start, TimeSpan end, out string message)
        {
            bool reserved = BookingFormHelper.IsCourtReserved(court, date, start, end, out message);

            if (reserved)
            {
                if (_bookingToEdit != null)
                {
                    // Exclude the currently edited booking itself
                    bool conflictWithOthers = Booking.GetAll().Any(b =>
                        b.BookingRef != _bookingToEdit.BookingID &&
                        b.CourtName == court.CourtName &&
                        b.BookingDate.Date == date.Date &&
                        start < b.EndTime &&
                        end > b.StartTime
                    );

                    if (!conflictWithOthers)
                    {
                        message = string.Empty;
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        private bool IsWithinWorkingHours(Court court, TimeSpan start, TimeSpan end, out string message)
        {
            message = "";
            if (court.OpenTime == court.CloseTime) return true; // 24 hours open

            bool isOpen = false;
            if (court.OpenTime < court.CloseTime)
            {
                isOpen = (start >= court.OpenTime && end <= court.CloseTime);
            }
            else
            {
                // Midnight crossing
                isOpen = (start >= court.OpenTime || start <= court.CloseTime) &&
                        (end >= court.OpenTime || end <= court.CloseTime);
            }

            if (!isOpen)
            {
                message = $"الملعب '{court.CourtName}' خارج أوقات العمل. ساعات العمل هي من {court.OpenTime:hh\\:mm} إلى {court.CloseTime:hh\\:mm}.";
                return false;
            }
            return true;
        }

        private void AddBookingForm_Paint(object sender, PaintEventArgs e)
        {
            Color borderColor = Color.FromArgb(224, 224, 224);
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, borderColor, ButtonBorderStyle.Solid);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (this.ActiveControl == btnCancel || this.ActiveControl == btnExit)
            {
                return;
            }

            var focusedControl = FindFocusedControl(this);
            if (focusedControl == btnCancel || focusedControl == btnExit)
            {
                return;
            }

            ValidateAndCheckCustomer();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                if (ValidateAndCheckCustomer())
                {
                    txtName.Focus();
                }
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ValidateAndCheckCustomer()
        {
            string phoneText = txtPhone.Texts.Trim();

            if (!ValidationHelper.IsValidPhoneNumber(phoneText, out string errorMessage))
            {
                ShowWarning(errorMessage);
                txtName.Texts = "";

                this.BeginInvoke(new Action(() => txtPhone.Focus()));
                return false;
            }

            customer = Customer.GetByPhone(phoneText);

            if (customer != null)
            {
                txtName.Texts = customer.FullName;
                txtName.Enabled = false;
            }
            else
            {
                txtName.Texts = "";
                txtName.Enabled = true;
            }

            return true;
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            // 1. Validate Customer
            if (!ValidationHelper.IsValidPhoneNumber(txtPhone.Texts, out string phoneError))
            {
                ShowWarning(phoneError);
                txtPhone.Focus();
                return;
            }

            if (!ValidationHelper.IsValidCustomerName(txtName.Texts, out string nameError))
            {
                ShowWarning(nameError);
                txtName.Focus();
                return;
            }

            var cards = flowBookings.Controls.OfType<BookingItemControl>().ToList();
            if (cards.Count == 0)
            {
                ShowWarning("الرجاء إضافة حجز واحد على الأقل.");
                return;
            }

            // 2. Validate overall deposit
            if (!double.TryParse(deposittxt.Texts.Trim(), out double deposit) || deposit < 0)
            {
                ShowWarning("الرجاء إدخال قيمة عربون صحيحة.");
                deposittxt.Focus();
                return;
            }

            double totalAll = 0;
            foreach (var card in cards)
            {
                totalAll += card.TotalPrice;
            }

            if (deposit > totalAll)
            {
                ShowWarning("لا يمكن أن يكون العربون المدفوع أكبر من إجمالي مبلغ الحجوزات!");
                deposittxt.Focus();
                return;
            }

            // 3. Validate each booking card's timing, conflicts, and operational hours
            foreach (var card in cards)
            {
                if (string.IsNullOrEmpty(card.SelectedCourtName))
                {
                    ShowWarning($"الرجاء اختيار ملعب للحجز رقم {card.Index}.");
                    return;
                }

                // Check open/close working hours
                Court court = Court.GetAll().FirstOrDefault(c => c.CourtName == card.SelectedCourtName);
                if (court != null)
                {
                    if (!IsWithinWorkingHours(court, card.SelectedStartTime, card.SelectedEndTime, out string openWarning))
                    {
                        ShowWarning(openWarning);
                        return;
                    }

                    if (IsBookingConflict(court, card.SelectedDate, card.SelectedStartTime, card.SelectedEndTime, out string conflictMsg))
                    {
                        ShowWarning($"الحجز رقم {card.Index}: " + conflictMsg);
                        return;
                    }
                }
            }

            // 4. Check conflicts within the session cards (simultaneous double bookings of same court)
            for (int i = 0; i < cards.Count; i++)
            {
                for (int j = i + 1; j < cards.Count; j++)
                {
                    if (cards[i].SelectedCourtName == cards[j].SelectedCourtName &&
                        cards[i].SelectedDate.Date == cards[j].SelectedDate.Date)
                    {
                        TimeSpan s1 = cards[i].SelectedStartTime;
                        TimeSpan e1 = cards[i].SelectedEndTime;
                        TimeSpan s2 = cards[j].SelectedStartTime;
                        TimeSpan e2 = cards[j].SelectedEndTime;

                        if (s1 < e2 && e1 > s2)
                        {
                            ShowWarning($"هناك تضارب في الأوقات للملعب '{cards[i].SelectedCourtName}' بين الحجز رقم {cards[i].Index} والحجز رقم {cards[j].Index}!");
                            return;
                        }
                    }
                }
            }

            // 5. INVENTORY STOCK AVAILABILITY VALIDATION
            var aggregatedRents = new Dictionary<string, List<Tuple<DateTime, TimeSpan, TimeSpan, int, string>>>();
            var aggregatedSales = new Dictionary<string, int>();

            foreach (var card in cards)
            {
                var items = card.GetInventoryItems();
                foreach (var item in items)
                {
                    if (item.UsageType == "Rent")
                    {
                        if (!aggregatedRents.ContainsKey(item.ItemRef))
                        {
                            aggregatedRents[item.ItemRef] = new List<Tuple<DateTime, TimeSpan, TimeSpan, int, string>>();
                        }
                        aggregatedRents[item.ItemRef].Add(new Tuple<DateTime, TimeSpan, TimeSpan, int, string>(
                            card.SelectedDate, card.SelectedStartTime, card.SelectedEndTime, item.Quantity, item.ItemName
                        ));
                    }
                    else
                    {
                        if (!aggregatedSales.ContainsKey(item.ItemRef))
                        {
                            aggregatedSales[item.ItemRef] = 0;
                        }
                        aggregatedSales[item.ItemRef] += item.Quantity;
                    }
                }
            }

            // Verify Rental availability
            foreach (var kvp in aggregatedRents)
            {
                string itemRef = kvp.Key;
                var requests = kvp.Value;
                string itemName = requests[0].Item5;

                foreach (var req in requests)
                {
                    DateTime date = req.Item1;
                    TimeSpan start = req.Item2;
                    TimeSpan end = req.Item3;

                    int simultaneousRequestedInSession = requests
                        .Where(r => r.Item1.Date == date.Date && r.Item2 < end && r.Item3 > start)
                        .Sum(r => r.Item4);

                    string excludeRef = _bookingToEdit != null ? _bookingToEdit.BookingID : "";
                    int dbAvailable = Booking.GetAvailableQuantity(itemRef, date, start, end, "Rent", excludeRef);

                    if (simultaneousRequestedInSession > dbAvailable)
                    {
                        ShowWarning($"الكمية المطلوبة للإيجار من الصنف '{itemName}' ({simultaneousRequestedInSession}) غير متوفرة في الفترة الزمنية المحددة. المتاح حالياً هو ({dbAvailable}).");
                        return;
                    }
                }
            }

            // Verify Sale availability
            foreach (var kvp in aggregatedSales)
            {
                string itemRef = kvp.Key;
                int qtyRequestedInSession = kvp.Value;
                string itemName = "";

                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT product_name FROM PRODUCTS WHERE product_ref = @ref", conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", itemRef);
                        var res = cmd.ExecuteScalar();
                        if (res != null) itemName = res.ToString();
                    }
                }

                string excludeRef = _bookingToEdit != null ? _bookingToEdit.BookingID : "";
                int dbAvailable = Booking.GetAvailableQuantity(itemRef, DateTime.Today, TimeSpan.Zero, TimeSpan.Zero, "Sale", excludeRef);

                if (qtyRequestedInSession > dbAvailable)
                {
                    ShowWarning($"الكمية المطلوبة للبيع من الصنف '{itemName}' ({qtyRequestedInSession}) غير متوفرة. المتاح حالياً هو ({dbAvailable}).");
                    return;
                }
            }

            // 6. SAVE DATA TO DATABASE
            try
            {
                if (customer == null)
                {
                    customer = new Customer
                    {
                        FullName = txtName.Texts.Trim(),
                        Phone = txtPhone.Texts.Trim()
                    };
                    customer.Save();
                }

                // If editing, we update the existing single booking
                if (_bookingToEdit != null)
                {
                    var card = cards[0];
                    Court selectedCourt = Court.GetAll().FirstOrDefault(c => c.CourtName == card.SelectedCourtName);

                    var original = Booking.GetByRef(_bookingToEdit.BookingID);
                    if (original != null)
                    {
                        original.CourtName = card.SelectedCourtName;
                        original.CourtRef = selectedCourt.CourtRef;
                        original.BookingDate = card.SelectedDate;
                        original.StartTime = card.SelectedStartTime;
                        original.EndTime = card.SelectedEndTime;
                        original.Price = card.TotalPrice;
                        original.Status = (deposit >= card.TotalPrice) ? BookingStatus.Completed : BookingStatus.Confirmed;
                        original.CustomerPhoneNumber = customer.Phone;

                        // Set inventory items inside original model
                        original.InventoryItems = card.GetInventoryItems();

                        // Save updates
                        original.Save();

                        // Update deposit payment
                        UpdateOrCreateDepositPayment(original.BookingRef, deposit);
                    }

                    ShowInfo("تم تحديث بيانات الحجز بنجاح.");
                }
                else
                {
                    // Saving new multi bookings
                    List<Booking> savedBookings = new List<Booking>();
                    
                    // Distribute deposit: we can put the full deposit on the first booking or distribute it.
                    // Put the full deposit on the first booking for accounting, others are Confirmed without deposit.
                    double remainingDepositToAssign = deposit;

                    foreach (var card in cards)
                    {
                        Court selectedCourt = Court.GetAll().FirstOrDefault(c => c.CourtName == card.SelectedCourtName);
                        
                        double currentCardDeposit = Math.Min(remainingDepositToAssign, card.TotalPrice);
                        remainingDepositToAssign -= currentCardDeposit;

                        Booking newBooking = new Booking
                        {
                            CustomerPhoneNumber = customer.Phone,
                            CourtName = card.SelectedCourtName,
                            CourtRef = selectedCourt.CourtRef,
                            BookingDate = card.SelectedDate.Date,
                            StartTime = card.SelectedStartTime,
                            EndTime = card.SelectedEndTime,
                            Price = card.TotalPrice,
                            Status = (currentCardDeposit >= card.TotalPrice) ? BookingStatus.Completed : BookingStatus.Confirmed,
                            Customer = customer,
                            Court = selectedCourt
                        };

                        newBooking.InventoryItems = card.GetInventoryItems();

                        // Temporarily assign deposit to save it properly in trigger/payments flow
                        newBooking.Deposit = currentCardDeposit;
                        newBooking.Save();

                        savedBookings.Add(newBooking);
                    }

                    ShowInfo("تم تسجيل الحجوزات بنجاح.");
                }

                // Refresh side list forms if open
                Application.OpenForms.OfType<ManageBooking>().FirstOrDefault()?.LoadData();
                Application.OpenForms.OfType<MangeCustomers>().FirstOrDefault()?.LoadData();
                Application.OpenForms.OfType<PaymentForm>().FirstOrDefault()?.LoadData();
                
                // Refresh Dashboard Form if open
                var dashboard = Application.OpenForms.OfType<DashBoardForm>().FirstOrDefault();
                if (dashboard != null)
                {
                    // Access LoadCourts through reflection or call a refresh
                    var method = dashboard.GetType().GetMethod("LoadCourts");
                    method?.Invoke(dashboard, null);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowError("حدث خطأ أثناء حفظ الحجوزات: " + ex.Message);
            }
        }

        private void UpdateOrCreateDepositPayment(string bookingRef, double depositAmount)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                
                // Check if payment already exists for this booking_ref
                string checkQuery = "SELECT payment_ref FROM PAYMENTS WHERE booking_ref = @booking_ref";
                string payRef = null;
                using (var cmd = new SqlCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@booking_ref", bookingRef);
                    var res = cmd.ExecuteScalar();
                    if (res != null) payRef = res.ToString();
                }

                if (depositAmount > 0)
                {
                    if (payRef != null)
                    {
                        // Update
                        string updateQuery = "UPDATE PAYMENTS SET amount = @amount WHERE payment_ref = @pay_ref";
                        using (var cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@amount", (decimal)depositAmount);
                            cmd.Parameters.AddWithValue("@pay_ref", payRef);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Create
                        string payDateStr = DateTime.Today.ToString("yyyyMMdd");
                        var existingRefs = new HashSet<int>();
                        string selectQuery = "SELECT CAST(RIGHT(payment_ref, 3) AS INT) FROM PAYMENTS WHERE payment_ref LIKE 'PAY-' + @date + '-%'";
                        using (var selectCmd = new SqlCommand(selectQuery, conn))
                        {
                            selectCmd.Parameters.AddWithValue("@date", payDateStr);
                            using (var reader = selectCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (!reader.IsDBNull(0)) existingRefs.Add(reader.GetInt32(0));
                                }
                            }
                        }
                        int nextSeq = 1;
                        while (existingRefs.Contains(nextSeq)) nextSeq++;
                        string newPayRef = $"PAY-{payDateStr}-{nextSeq.ToString("D3")}";

                        string insertQuery = @"
                            INSERT INTO PAYMENTS (payment_ref, customer_phone_number, payment_date, payment_time, booking_ref, contract_ref, amount)
                            VALUES (@pay_ref, @cust_phone, @date, @time, @booking_ref, NULL, @amount)";
                        using (var cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@pay_ref", newPayRef);
                            cmd.Parameters.AddWithValue("@cust_phone", txtPhone.Texts.Trim());
                            cmd.Parameters.AddWithValue("@date", DateTime.Today);
                            cmd.Parameters.AddWithValue("@time", DateTime.Now.TimeOfDay);
                            cmd.Parameters.AddWithValue("@booking_ref", bookingRef);
                            cmd.Parameters.AddWithValue("@amount", (decimal)depositAmount);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    // If deposit was set to 0, remove previous payment record
                    if (payRef != null)
                    {
                        string deleteQuery = "DELETE FROM PAYMENTS WHERE payment_ref = @pay_ref";
                        using (var cmd = new SqlCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@pay_ref", payRef);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private Control FindFocusedControl(Control control)
        {
            var container = control as IContainerControl;
            while (container != null && container.ActiveControl != null)
            {
                control = container.ActiveControl;
                container = control as IContainerControl;
            }
            return control;
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowInfo(string message)
        {
            MessageBox.Show(message, "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "خطأ في النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UpdateBookingsHeaderCount()
        {
            lblBookingsHeader.Text = $"الحجوزات ({flowBookings.Controls.Count})";
        }

        private void panelCustomerInfo_Paint(object sender, PaintEventArgs e)
        {
            Color borderColor = Color.FromArgb(215, 230, 255);
            using (var pen = new Pen(borderColor, 1.5f))
            {
                // Draw rounded rectangle or border
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                var rect = panelCustomerInfo.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
    }
}