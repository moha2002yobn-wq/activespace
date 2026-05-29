using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ActiveSpace.Models;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Models;

namespace ActiveSpaceSystem.CustomItems
{
    public partial class BookingItemControl : UserControl
    {
        public event EventHandler TotalPriceChanged;
        public event EventHandler DeleteClicked;

        private int _index = 1;
        public int Index
        {
            get => _index;
            set
            {
                _index = value;
                lblIndex.Text = $"حجز رقم {_index}";
            }
        }

        public bool ShowDeleteButton
        {
            get => btnDeleteBooking.Visible;
            set => btnDeleteBooking.Visible = value;
        }

        public string SelectedCourtType => cmbCourtType.SelectedValue?.ToString() ?? "";
        public string SelectedCourtName => cmbCourt.SelectedValue?.ToString() ?? "";
        public DateTime SelectedDate => dtpBookingDate.Value;
        public TimeSpan SelectedStartTime => dtpStartTime.Value.TimeOfDay;
        public TimeSpan SelectedEndTime => dtpEndTime.Value.TimeOfDay;

        public double BasePrice
        {
            get => double.TryParse(txtBasePrice.Texts.Trim(), out double p) ? p : 0.0;
            set => txtBasePrice.Texts = value.ToString("0.##");
        }

        public double TotalPrice => BasePrice + (double)PropertiesTotalPrice;

        public decimal PropertiesTotalPrice
        {
            get
            {
                decimal total = 0m;
                foreach (var ctrl in flowProperties.Controls.OfType<BookingPropertyControl>())
                {
                    total += ctrl.TotalPrice;
                }
                return total;
            }
        }

        public List<BookingInventoryItem> GetInventoryItems()
        {
            var list = new List<BookingInventoryItem>();
            foreach (var ctrl in flowProperties.Controls.OfType<BookingPropertyControl>())
            {
                list.Add(new BookingInventoryItem
                {
                    ItemRef = ctrl.SelectedItemRef,
                    ItemName = ctrl.SelectedItemName,
                    Quantity = ctrl.SelectedQuantity,
                    Price = ctrl.SelectedUnitPrice,
                    UsageType = ctrl.SelectedUsageType
                });
            }
            return list;
        }

        private bool _isInitialLoading = true;

        public BookingItemControl()
        {
            InitializeComponent();

            dtpStartTime.Value = DateTime.Today.AddHours(16);
            dtpEndTime.Value = DateTime.Today.AddHours(17);

            LoadCourtTypes();
            
            cmbCourtType.SelectedIndexChanged += CmbCourtType_SelectedIndexChanged;
            cmbCourt.SelectedIndexChanged += CmbCourt_SelectedIndexChanged;
            dtpStartTime.ValueChanged += Timing_ValueChanged;
            dtpEndTime.ValueChanged += Timing_ValueChanged;
            dtpBookingDate.ValueChanged += Timing_ValueChanged;
            txtBasePrice.TextChanged += TxtBasePrice_TextChanged;

            btnAddProperty.Click += BtnAddProperty_Click;
            btnDeleteBooking.Click += (s, e) => DeleteClicked?.Invoke(this, EventArgs.Empty);

            _isInitialLoading = false;
            RecalculatePrices();
        }

        private void LoadCourtTypes()
        {
            cmbCourtType.DataSource = null;
            cmbCourtType.Items.Clear();
            cmbCourtType.DisplayMember = "TypeName";
            cmbCourtType.ValueMember = "TypeName";
            cmbCourtType.DataSource = CourtType.GetFakeData();
            
            if (cmbCourtType.Items.Count > 0)
            {
                cmbCourtType.SelectedIndex = 0;
                LoadCourtsForType();
            }
        }

        private void LoadCourtsForType()
        {
            string type = SelectedCourtType;
            if (string.IsNullOrEmpty(type)) return;

            var courtsList = Court.GetAll().Where(c => c.SportType == type).ToList();
            
            cmbCourt.DataSource = null;
            cmbCourt.DisplayMember = "CourtName";
            cmbCourt.ValueMember = "CourtName";
            cmbCourt.DataSource = courtsList;

            if (cmbCourt.Items.Count > 0)
            {
                cmbCourt.SelectedIndex = 0;
            }
            else
            {
                txtBasePrice.Texts = "0";
            }
        }

        private void RecalculatePrices()
        {
            if (_isInitialLoading) return;

            // 1. Auto-calculate Base Price
            if (cmbCourt.SelectedItem is Court selectedCourt)
            {
                double pricePerHour = selectedCourt.PricePerHour;
                double hours = (dtpEndTime.Value - dtpStartTime.Value).TotalHours;
                if (hours < 0) hours += 24; // Handle midnight crossing

                double calculatedBase = Math.Max(0.0, hours * pricePerHour);
                txtBasePrice.Texts = calculatedBase.ToString("0.##");
            }

            // 2. Update Total Label
            double total = TotalPrice;
            lblTotal.Text = $"{total:N0} د.ل";

            // 3. Notify Form
            TotalPriceChanged?.Invoke(this, EventArgs.Empty);
        }

        private void CmbCourtType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCourtsForType();
            UpdateAllPropertyControlsCourt();
        }

        private void CmbCourt_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecalculatePrices();
            UpdateAllPropertyControlsCourt();
        }

        private void UpdateAllPropertyControlsCourt()
        {
            if (cmbCourt.SelectedItem is Court court)
            {
                foreach (var ctrl in flowProperties.Controls.OfType<BookingPropertyControl>())
                {
                    ctrl.CourtRef = court.CourtRef;
                }
            }
        }

        private void Timing_ValueChanged(object sender, EventArgs e)
        {
            RecalculatePrices();
        }

        private void TxtBasePrice_TextChanged(object sender, EventArgs e)
        {
            double total = TotalPrice;
            lblTotal.Text = $"{total:N0} د.ل";
            TotalPriceChanged?.Invoke(this, EventArgs.Empty);
        }

        private void BtnAddProperty_Click(object sender, EventArgs e)
        {
            if (!(cmbCourt.SelectedItem is Court selectedCourt))
            {
                MessageBox.Show("الرجاء اختيار ملعب أولاً قبل إضافة خصائص من المخزون.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var propCtrl = new BookingPropertyControl();
            
            // Wire up event handlers first so they capture the initial price loading event
            propCtrl.ValueChanged += (s, ev) => {
                double total = TotalPrice;
                lblTotal.Text = $"{total:N0} د.ل";
                TotalPriceChanged?.Invoke(this, EventArgs.Empty);
            };

            propCtrl.DeleteClicked += (s, ev) => {
                flowProperties.Controls.Remove(propCtrl);
                UpdatePropertiesHeaderState();
                double total = TotalPrice;
                lblTotal.Text = $"{total:N0} د.ل";
                TotalPriceChanged?.Invoke(this, EventArgs.Empty);
            };

            // Set CourtRef to trigger data load
            propCtrl.CourtRef = selectedCourt.CourtRef;
            propCtrl.Width = flowProperties.ClientSize.Width > 50 ? flowProperties.ClientSize.Width - 25 : 665;

            flowProperties.Controls.Add(propCtrl);
            UpdatePropertiesHeaderState();

            // Force update the UI total price immediately upon adding the property
            double currentTotal = TotalPrice;
            lblTotal.Text = $"{currentTotal:N0} د.ل";
            TotalPriceChanged?.Invoke(this, EventArgs.Empty);
        }

        private void UpdatePropertiesHeaderState()
        {
            lblNoProperties.Visible = (flowProperties.Controls.Count == 0);
            
            // Dynamically adjust height of control based on properties count
            int baseHeight = 425;
            int propsHeight = 0;
            foreach (Control ctrl in flowProperties.Controls)
            {
                propsHeight += ctrl.Height + 10;
            }
            if (propsHeight == 0) propsHeight = 45; // Height for empty label
            
            flowProperties.Height = propsHeight + 5;
            
            if (panelPropertiesContainer != null)
            {
                panelPropertiesContainer.Height = propsHeight + 10;
            }
            
            if (cardPanel != null)
            {
                cardPanel.Height = baseHeight + (panelPropertiesContainer != null ? panelPropertiesContainer.Height : flowProperties.Height) - 50;
                this.Height = cardPanel.Height + 10;
            }
            else
            {
                this.Height = baseHeight + flowProperties.Height - 45;
            }
        }

        public void SetBookingData(Booking booking)
        {
            _isInitialLoading = true;

            dtpBookingDate.Value = booking.BookingDate;
            dtpStartTime.Value = DateTime.Today.Add(booking.StartTime);
            dtpEndTime.Value = DateTime.Today.Add(booking.EndTime);

            if (booking.Court != null)
            {
                cmbCourtType.SelectedValue = booking.Court.SportType;
                LoadCourtsForType();
                cmbCourt.SelectedValue = booking.Court.CourtName;
            }

            txtBasePrice.Texts = booking.Price.ToString("0.##");

            // Load property controls
            flowProperties.Controls.Clear();
            foreach (var item in booking.InventoryItems)
            {
                var propCtrl = new BookingPropertyControl();
                propCtrl.CourtRef = booking.CourtRef;
                propCtrl.Width = flowProperties.ClientSize.Width > 50 ? flowProperties.ClientSize.Width - 25 : 665;
                
                // We must select item and category properly
                propCtrl.CourtName = booking.CourtName;
                
                // Let it load categories
                propCtrl.cmbCategory.Text = ""; // Trigger reload/binding
                // Set values
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string getCat = "SELECT category_ref FROM PRODUCTS WHERE product_ref = @item";
                    using (var cmd = new SqlCommand(getCat, conn))
                    {
                        cmd.Parameters.AddWithValue("@item", item.ItemRef);
                        var catObj = cmd.ExecuteScalar();
                        if (catObj != null)
                        {
                            propCtrl.cmbCategory.SelectedValue = catObj.ToString();
                            propCtrl.cmbItem.SelectedValue = item.ItemRef;
                        }
                    }
                }
                
                propCtrl.txtQty.Text = item.Quantity.ToString();
                propCtrl.cmbType.Text = item.UsageType == "Rent" ? "إيجار" : "بيع";

                propCtrl.ValueChanged += (s, ev) => {
                    double total = TotalPrice;
                    lblTotal.Text = $"{total:N0} د.ل";
                    TotalPriceChanged?.Invoke(this, EventArgs.Empty);
                };

                propCtrl.DeleteClicked += (s, ev) => {
                    flowProperties.Controls.Remove(propCtrl);
                    UpdatePropertiesHeaderState();
                    double total = TotalPrice;
                    lblTotal.Text = $"{total:N0} د.ل";
                    TotalPriceChanged?.Invoke(this, EventArgs.Empty);
                };

                flowProperties.Controls.Add(propCtrl);
            }

            _isInitialLoading = false;
            UpdatePropertiesHeaderState();
            RecalculatePrices();
        }
    }
}
