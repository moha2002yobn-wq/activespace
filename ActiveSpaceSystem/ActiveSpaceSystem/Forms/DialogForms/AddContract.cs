using ActiveSpace.Models;
using ActiveSpaceSystem.CustomItems;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Helpers;
using ActiveSpaceSystem.Models.enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.DialogForms
{
    public partial class AddContract : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private Customer _currentCustomer = null;
        private MonthlyContract _contractToEdit = null;

        private static readonly Dictionary<string, DayOfWeek> DaysMap = new Dictionary<string, DayOfWeek>
        {
            { "السبت", DayOfWeek.Saturday },
            { "الأحد", DayOfWeek.Sunday },
            { "الاثنين", DayOfWeek.Monday },
            { "الثلاثاء", DayOfWeek.Tuesday },
            { "الأربعاء", DayOfWeek.Wednesday },
            { "الخميس", DayOfWeek.Thursday },
            { "الجمعة", DayOfWeek.Friday }
        };

        public AddContract()
        {
            InitializeComponent();
            LoadInitialData();
            WireUpEvents();
        }

        public AddContract(MonthlyContract contract)
        {
            InitializeComponent();
            _contractToEdit = contract;
            LoadInitialData();
            FillDataForEdit();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            btnAddProperty.Click += btnAddProperty_Click;
            btnExit.Click += btnExit_Click;
            
            cmbDays.SelectedIndexChanged += (s, e) => UpdateOccurrencesLabel();
            dtpStartTime.ValueChanged += (s, e) => UpdateOccurrencesLabel();
            dtpEndTime.ValueChanged += (s, e) => UpdateOccurrencesLabel();
            dtpBookingDate.ValueChanged += (s, e) => UpdateOccurrencesLabel();
            dateTimePicker1.ValueChanged += (s, e) => UpdateOccurrencesLabel();
            txtPricePerHour.TextChanged += (s, e) => UpdateOccurrencesLabel();
            cmbCourt.SelectedIndexChanged += cmbCourt_SelectedIndexChanged;
            
            UpdateOccurrencesLabel();
            UpdateNoPropertiesLabel();
        }

        private void AddContract_Load(object sender, EventArgs e)
        {
            if (_contractToEdit == null) _currentCustomer = null;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }

        private void btnAddProperty_Click(object sender, EventArgs e)
        {
            if (cmbCourt.SelectedItem == null)
            {
                ShowWarning("الرجاء تحديد ملعب أولاً.");
                return;
            }

            Court selectedCourt = (Court)cmbCourt.SelectedItem;
            var prop = new BookingPropertyControl();
            prop.CourtRef = selectedCourt.CourtRef;
            prop.Width = flowProperties.ClientSize.Width - 25;
            prop.Margin = new Padding(0, 3, 0, 3);

            prop.ValueChanged += (s, ev) => UpdateOccurrencesLabel();
            prop.DeleteClicked += (s, ev) =>
            {
                flowProperties.Controls.Remove(prop);
                prop.Dispose();
                UpdateOccurrencesLabel();
                UpdateNoPropertiesLabel();
            };

            flowProperties.Controls.Add(prop);
            UpdateOccurrencesLabel();
            UpdateNoPropertiesLabel();
        }

        private void UpdateNoPropertiesLabel()
        {
            lblNoProperties.Visible = (flowProperties.Controls.Count == 0);
        }

        private void FillDataForEdit()
        {
            if (_contractToEdit == null) return;

            label1.Text = "تعديل عقد شهري";
            btSave.Text = "تعديل وحفظ";

            _currentCustomer = Customer.GetByPhone(_contractToEdit.CustomerPhoneNumber);
            if (_currentCustomer != null)
            {
                txtPhone.Texts = _currentCustomer.Phone;
                txtName.Texts = _currentCustomer.FullName;
                txtName.Enabled = false;
            }

            dtpBookingDate.Value = _contractToEdit.StartDate;
            dateTimePicker1.Value = _contractToEdit.EndDate;
            dtpStartTime.Value = DateTime.Today.Add(_contractToEdit.FixedStartTime);
            dtpEndTime.Value = DateTime.Today.Add(_contractToEdit.FixedEndTime);

            txtPricePerHour.Texts = _contractToEdit.PricePerHour.ToString();

            // Calculate existing deposit from database
            double totalSavedDeposit = _contractToEdit.Bookings?.Sum(b => (double)b.Price) ?? 0; // Or from payments
            deposittxt.Texts = totalSavedDeposit.ToString();

            if (Enum.TryParse(_contractToEdit.DayOfWeek, out DayOfWeek day))
            {
                var entry = DaysMap.FirstOrDefault(x => x.Value == day);
                if (entry.Key != null)
                {
                    cmbDays.SelectedValue = entry.Value;
                }
            }

            var court = Court.GetByName(_contractToEdit.CourtName);
            if (court != null)
            {
                cmbCourtType.Text = court.SportType;
                cmbCourt.SelectedValue = court.CourtName;
            }

            // Load existing properties
            if (_contractToEdit.Bookings != null && _contractToEdit.Bookings.Count > 0)
            {
                var firstBooking = _contractToEdit.Bookings[0];
                firstBooking.LoadInventoryItems();
                foreach (var item in firstBooking.InventoryItems)
                {
                    if (court != null)
                    {
                        var prop = new BookingPropertyControl();
                        prop.CourtRef = court.CourtRef;
                        prop.Width = flowProperties.ClientSize.Width - 25;
                        prop.Margin = new Padding(0, 3, 0, 3);

                        prop.ValueChanged += (s, ev) => UpdateOccurrencesLabel();
                        prop.DeleteClicked += (s, ev) =>
                        {
                            flowProperties.Controls.Remove(prop);
                            prop.Dispose();
                            UpdateOccurrencesLabel();
                            UpdateNoPropertiesLabel();
                        };
                        flowProperties.Controls.Add(prop);
                        
                        prop.SetPropertyData(item.ItemRef, item.Quantity, item.UsageType);
                    }
                }
            }

            UpdateOccurrencesLabel();
            UpdateNoPropertiesLabel();
        }

        private void LoadInitialData()
        {
            cmbCourtType.DataSource = CourtType.GetFakeData();
            cmbCourtType.DisplayMember = "TypeName";
            cmbCourtType.ValueMember = "TypeName";
            cmbCourtType.SelectedIndex = -1;

            cmbDays.DataSource = new BindingSource(DaysMap, null);
            cmbDays.DisplayMember = "Key";
            cmbDays.ValueMember = "Value";

            cmbCourt.SelectedIndex = -1;

            if (_contractToEdit == null)
            {
                DateTime nextHour = DateTime.Now.AddHours(1);
                DateTime startTime = new DateTime(nextHour.Year, nextHour.Month, nextHour.Day, nextHour.Hour, 0, 0);
                DateTime endTime = startTime.AddHours(1);

                dtpStartTime.Value = startTime;
                dtpEndTime.Value = endTime;
            }

            UpdateOccurrencesLabel();
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (this.ActiveControl == btnCancel) return;
            ValidateAndCheckCustomer();
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

            _currentCustomer = Customer.GetByPhone(phoneText);

            if (_currentCustomer != null)
            {
                txtName.Texts = _currentCustomer.FullName;
                txtName.Enabled = false;
            }
            else
            {
                txtName.Enabled = true;
            }
            return true;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (!ValidateAllInputs(out double pricePerHour, out double totalDeposit)) return;

            TimeSpan startTime = new TimeSpan(dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, 0);
            TimeSpan endTime = new TimeSpan(dtpEndTime.Value.Hour, dtpEndTime.Value.Minute, 0);

            if (cmbCourt.SelectedItem == null) { ShowWarning("الرجاء تحديد ملعب."); return; }
            Court selectedCourt = (Court)cmbCourt.SelectedItem;
            DayOfWeek selectedDay = (DayOfWeek)cmbDays.SelectedValue;

            HandleCustomerData();

            MonthlyContract contract = _contractToEdit ?? new MonthlyContract();

            if (_contractToEdit != null)
            {
                // Delete old contract bookings and payments before regenerating
                MonthlyContract.Delete(contract.ContractRef);
            }

            contract.CustomerPhoneNumber = _currentCustomer.Phone;
            contract.CourtName = selectedCourt.CourtName;
            contract.DayOfWeek = selectedDay.ToString();
            contract.StartDate = dtpBookingDate.Value.Date;
            contract.EndDate = dateTimePicker1.Value.Date;
            contract.FixedStartTime = startTime;
            contract.FixedEndTime = endTime;
            contract.PricePerHour = pricePerHour;
            contract.Status = MonthlyContractStatus.Active;
            contract.Customer = _currentCustomer;
            contract.Court = selectedCourt;

            contract.InventoryItems.Clear();
            foreach (var prop in flowProperties.Controls.OfType<BookingPropertyControl>())
            {
                contract.InventoryItems.Add(new BookingInventoryItem
                {
                    ItemRef = prop.SelectedItemRef,
                    ItemName = prop.SelectedItemName,
                    Quantity = prop.SelectedQuantity,
                    Price = prop.SelectedUnitPrice,
                    UsageType = prop.SelectedUsageType
                });
            }

            contract.GenerateBookings();

            // Calculate total amount based on generated bookings
            int sessionCount = contract.Bookings.Count;
            double durationInHours = (endTime - startTime).TotalHours;
            if (durationInHours < 0) durationInHours += 24;

            double baseTotalAmount = sessionCount * durationInHours * pricePerHour;
            double propertiesTotalPerSession = (double)flowProperties.Controls.OfType<BookingPropertyControl>().Sum(ctrl => ctrl.TotalPrice);
            double propertiesTotalAmount = sessionCount * propertiesTotalPerSession;

            contract.TotalAmount = baseTotalAmount + propertiesTotalAmount;

            if (totalDeposit > contract.TotalAmount)
            {
                ShowWarning($"قيمة العربون ({totalDeposit}) لا يمكن أن تتجاوز إجمالي العقد ({contract.TotalAmount})");
                return;
            }

            if (HasContractConflicts(contract, selectedCourt, out string conflictMessage))
            {
                ShowWarning(conflictMessage);
                return;
            }

            if (!ValidatePropertiesStock(contract))
            {
                return;
            }

            try
            {
                contract.Save();
                SaveContractPayments(contract, totalDeposit);

                ShowInfo(_contractToEdit == null ? "تم تسجيل العقد بنجاح." : "تم تحديث العقد بنجاح.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowError("خطأ أثناء الحفظ: " + ex.Message);
            }
        }

        private bool ValidatePropertiesStock(MonthlyContract contract)
        {
            var selectedProperties = flowProperties.Controls.OfType<BookingPropertyControl>().ToList();
            var aggregatedSales = new Dictionary<string, int>();
            var aggregatedRents = new Dictionary<string, List<Tuple<DateTime, TimeSpan, TimeSpan, int, string>>>();

            foreach (var prop in selectedProperties)
            {
                string itemRef = prop.SelectedItemRef;
                string itemName = prop.SelectedItemName;
                int qty = prop.SelectedQuantity;
                string usageType = prop.SelectedUsageType;

                if (qty <= 0) continue;

                if (usageType == "Rent")
                {
                    if (!aggregatedRents.ContainsKey(itemRef))
                    {
                        aggregatedRents[itemRef] = new List<Tuple<DateTime, TimeSpan, TimeSpan, int, string>>();
                    }
                    foreach (var booking in contract.Bookings)
                    {
                        aggregatedRents[itemRef].Add(new Tuple<DateTime, TimeSpan, TimeSpan, int, string>(
                            booking.BookingDate, booking.StartTime, booking.EndTime, qty, itemName
                        ));
                    }
                }
                else
                {
                    if (!aggregatedSales.ContainsKey(itemRef))
                    {
                        aggregatedSales[itemRef] = 0;
                    }
                    aggregatedSales[itemRef] += contract.Bookings.Count * qty;
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

                    string excludeContractRef = _contractToEdit != null ? _contractToEdit.ContractRef : "";
                    int dbAvailable = GetAvailableInventoryQuantityExcludingContract(itemRef, date, start, end, "Rent", excludeContractRef);

                    if (simultaneousRequestedInSession > dbAvailable)
                    {
                        ShowWarning($"الكمية المطلوبة للإيجار من الصنف '{itemName}' ({simultaneousRequestedInSession}) غير متوفرة في تاريخ {date.ToShortDateString()}. المتاح حالياً هو ({dbAvailable}).");
                        return false;
                    }
                }
            }

            // Verify Sale availability
            foreach (var kvp in aggregatedSales)
            {
                string itemRef = kvp.Key;
                int qtyRequestedTotal = kvp.Value;
                string itemName = "";

                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT product_name FROM PRODUCTS WHERE product_ref = @ref";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", itemRef);
                        itemName = cmd.ExecuteScalar()?.ToString() ?? "";
                    }
                }

                string excludeContractRef = _contractToEdit != null ? _contractToEdit.ContractRef : "";
                int dbAvailable = GetAvailableInventoryQuantityExcludingContract(itemRef, DateTime.Today, TimeSpan.Zero, TimeSpan.Zero, "Sale", excludeContractRef);

                if (qtyRequestedTotal > dbAvailable)
                {
                    ShowWarning($"الكمية المطلوبة للبيع من الصنف '{itemName}' ({qtyRequestedTotal}) غير متوفرة في المخزون لكامل فترة العقد. المتاح حالياً هو ({dbAvailable}).");
                    return false;
                }
            }

            return true;
        }

        private int GetAvailableInventoryQuantityExcludingContract(string itemRef, DateTime date, TimeSpan startTime, TimeSpan endTime, string usageType, string excludeContractRef = "")
        {
            int currentQty = 0;
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string qtyQuery = "SELECT current_quantity FROM INVENTORY WHERE item_ref = @item_ref";
                using (var cmd = new SqlCommand(qtyQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@item_ref", itemRef);
                    object res = cmd.ExecuteScalar();
                    if (res != null) currentQty = Convert.ToInt32(res);
                }

                if (usageType == "Rent")
                {
                    string rentQuery = @"
                        SELECT ISNULL(SUM(bi.quantity), 0)
                        FROM BOOKING_INVENTORY bi
                        JOIN BOOKINGS b ON bi.booking_ref = b.booking_ref
                        WHERE bi.item_ref = @item_ref 
                          AND bi.usage_type = 'Rent'
                          AND b.booking_date = @date
                          AND b.status <> 'ملغى'" + 
                          (!string.IsNullOrEmpty(excludeContractRef) ? " AND (b.contract_ref IS NULL OR b.contract_ref <> @exclude_contract)" : "");
                    using (var cmd = new SqlCommand(rentQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@item_ref", itemRef);
                        cmd.Parameters.AddWithValue("@date", date.Date);
                        cmd.Parameters.AddWithValue("@start_time", startTime);
                        cmd.Parameters.AddWithValue("@end_time", endTime);
                        if (!string.IsNullOrEmpty(excludeContractRef))
                        {
                            cmd.Parameters.AddWithValue("@exclude_contract", excludeContractRef);
                        }
                        currentQty -= Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                else
                {
                    string saleQuery = @"
                        SELECT ISNULL(SUM(bi.quantity), 0)
                        FROM BOOKING_INVENTORY bi
                        JOIN BOOKINGS b ON bi.booking_ref = b.booking_ref
                        WHERE bi.item_ref = @item_ref 
                          AND bi.usage_type = 'Sale'
                          AND b.status <> 'ملغى'" + 
                          (!string.IsNullOrEmpty(excludeContractRef) ? " AND (b.contract_ref IS NULL OR b.contract_ref <> @exclude_contract)" : "");
                    using (var cmd = new SqlCommand(saleQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@item_ref", itemRef);
                        if (!string.IsNullOrEmpty(excludeContractRef))
                        {
                            cmd.Parameters.AddWithValue("@exclude_contract", excludeContractRef);
                        }
                        currentQty -= Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            return currentQty >= 0 ? currentQty : 0;
        }

        private bool ValidateAllInputs(out double price, out double deposit)
        {
            price = 0; deposit = 0;

            if (!ValidateAndCheckCustomer()) return false;
            if (cmbDays.SelectedValue == null) { ShowWarning("يرجى اختيار يوم العقد."); return false; }

            if (!ValidationHelper.IsValidDecimalValue(txtPricePerHour.Texts, "سعر الساعة", out price, out string pErr))
            { ShowWarning(pErr); return false; }

            if (!ValidationHelper.IsValidDecimalValue(deposittxt.Texts, "العربون", out deposit, out string dErr))
            { ShowWarning(dErr); return false; }

            if (dtpBookingDate.Value.Date > dateTimePicker1.Value.Date)
            {
                ShowWarning("تاريخ البداية بعد تاريخ النهاية!");
                return false;
            }

            return true;
        }

        private void HandleCustomerData()
        {
            if (_currentCustomer == null)
            {
                _currentCustomer = new Customer
                {
                    FullName = txtName.Texts.Trim(),
                    Phone = txtPhone.Texts.Trim()
                };
                _currentCustomer.Save();
            }
        }

        private bool HasContractConflicts(MonthlyContract contract, Court court, out string message)
        {
            message = "";
            string excludeContractRef = _contractToEdit != null ? _contractToEdit.ContractRef : "";

            var allBookings = Booking.GetAll().Where(b => b.StatusString != "ملغى");
            
            if (!string.IsNullOrEmpty(excludeContractRef))
            {
                allBookings = allBookings.Where(b => b.ContractRef != excludeContractRef);
            }

            var bookingsList = allBookings.ToList();

            foreach (var b in contract.Bookings)
            {
                if (BookingFormHelper.IsDateTimeInPast(b.BookingDate, b.StartTime, out string pastWarn))
                {
                    message = $"الحصة في تاريخ {b.BookingDate.ToShortDateString()}: {pastWarn}";
                    return true;
                }

                TimeSpan courtOpen = court.OpenTime;
                TimeSpan courtClose = court.CloseTime;

                if (courtClose <= courtOpen)
                {
                    courtClose = courtClose.Add(TimeSpan.FromHours(24));
                }

                TimeSpan adjustedEnd = b.EndTime;
                if (adjustedEnd <= b.StartTime)
                {
                    adjustedEnd = adjustedEnd.Add(TimeSpan.FromHours(24));
                }

                if (b.StartTime < courtOpen || adjustedEnd > courtClose)
                {
                    string openStr = court.OpenTime.ToString(@"hh\:mm");
                    string closeStr = court.CloseTime.ToString(@"hh\:mm");
                    message = $"الحصة في تاريخ {b.BookingDate.ToShortDateString()} خارج أوقات العمل! ساعات العمل هي من {openStr} إلى {closeStr}.";
                    return true;
                }

                bool isReserved = bookingsList.Any(dbB =>
                    dbB.CourtName == court.CourtName &&
                    dbB.BookingDate.Date == b.BookingDate.Date &&
                    b.StartTime < dbB.EndTime &&
                    b.EndTime > dbB.StartTime
                );

                if (isReserved)
                {
                    message = $"تداخل في تاريخ {b.BookingDate.ToShortDateString()}: هذا الملعب محجوز بالفعل في هذه الفترة ({b.StartTime:hh\\:mm} - {b.EndTime:hh\\:mm}).";
                    return true;
                }
            }
            return false;
        }

        private void SaveContractPayments(MonthlyContract contract, double totalDeposit)
        {
            if (totalDeposit > 0)
            {
                var payment = new Payment
                {
                    AmountPaid = totalDeposit,
                    PaidAt = DateTime.Now,
                    ContractRef = contract.ContractRef,
                    CustomerPhoneNumber = contract.CustomerPhoneNumber
                };
                payment.Save();
            }
        }

        private void cmbCourtType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCourtType.SelectedValue != null)
            {
                string sportType = cmbCourtType.SelectedValue.ToString();
                cmbCourt.DataSource = Court.GetAll().Where(c => c.SportType == sportType).ToList();
                cmbCourt.DisplayMember = "CourtName";
                cmbCourt.ValueMember = "CourtName";
            }
        }

        private int CalculateOccurrences()
        {
            DateTime start = dtpBookingDate.Value.Date;
            DateTime end = dateTimePicker1.Value.Date;
            if (cmbDays.SelectedValue is DayOfWeek selectedDay)
            {
                int count = 0;
                for (DateTime date = start; date <= end; date = date.AddDays(1))
                {
                    if (date.DayOfWeek == selectedDay) count++;
                }
                return count;
            }
            return 0;
        }

        private void UpdateOccurrencesLabel()
        {
            int sessionCount = CalculateOccurrences();
            TimeSpan startTime = new TimeSpan(dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, 0);
            TimeSpan endTime = new TimeSpan(dtpEndTime.Value.Hour, dtpEndTime.Value.Minute, 0);
            double durationInHours = (endTime - startTime).TotalHours;
            if (durationInHours < 0) durationInHours += 24;

            double pricePerHour = double.TryParse(txtPricePerHour.Texts.Trim(), out double p) ? p : 0.0;
            double baseTotal = sessionCount * durationInHours * pricePerHour;

            double propertiesTotalPerSession = 0.0;
            if (flowProperties != null)
            {
                propertiesTotalPerSession = (double)flowProperties.Controls.OfType<BookingPropertyControl>().Sum(ctrl => ctrl.TotalPrice);
            }
            double propertiesTotal = sessionCount * propertiesTotalPerSession;

            double total = baseTotal + propertiesTotal;

            if (labelHours != null)
            {
                labelHours.Text = $"عدد الحصص: {sessionCount} | إجمالي القيمة: {total:N0} د.ل";
            }
            UpdateAlertText();
        }

        private void UpdateAlertText()
        {
            try
            {
                if (cmbDays == null || dtpStartTime == null || dtpEndTime == null || dtpBookingDate == null || dateTimePicker1 == null || lblAlertText == null) return;
                string day = cmbDays.Text;
                string start = dtpStartTime.Value.ToString(@"hh\:mm tt");
                string end = dtpEndTime.Value.ToString(@"hh\:mm tt");
                string startDate = dtpBookingDate.Value.ToShortDateString();
                string endDate = dateTimePicker1.Value.ToShortDateString();

                lblAlertText.Text = $"✓ سيتم حجز هذا الموعد تلقائياً كل {day} من {start} إلى {end} ابتداءً من {startDate} حتى {endDate}.";
            }
            catch { }
        }

        private void dtpBookingDate_ValueChanged(object sender, EventArgs e) => UpdateOccurrencesLabel();
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) => UpdateOccurrencesLabel();
        private void cmbDays_SelectedIndexChanged(object sender, EventArgs e) => UpdateOccurrencesLabel();

        private void ShowWarning(string m) => MessageBox.Show(m, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void ShowInfo(string m) => MessageBox.Show(m, "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void ShowError(string m) => MessageBox.Show(m, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
        private void button1_Click(object sender, EventArgs e) => this.Close();
        private void btnExit_Click(object sender, EventArgs e) => this.Close();

        private void cmbCourt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCourt.SelectedItem is Court court)
            {
                txtPricePerHour.Texts = court.PricePerHour.ToString();
                UpdateOccurrencesLabel();
            }
            else if (cmbCourt.SelectedValue != null)
            {
                string courtName = cmbCourt.SelectedValue.ToString();
                var c = Court.GetAll().FirstOrDefault(x => x.CourtName == courtName);
                if (c != null)
                {
                    txtPricePerHour.Texts = c.PricePerHour.ToString();
                    UpdateOccurrencesLabel();
                }
            }
        }
    }
}