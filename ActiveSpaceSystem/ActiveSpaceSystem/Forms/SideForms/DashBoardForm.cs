using ActiveSpace.Models;
using ActiveSpaceSystem.CustomItems;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Models;
using ActiveSpaceSystem.Models.enums;
using ActiveSpaceSystem.Forms.MainForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.SideForms
{
    public partial class DashBoardForm : Form
    {
        private bool isExpanded = false;

        public DashBoardForm()
        {
            InitializeComponent();

            // Safe design-time guard to prevent visual studio designer loading errors
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                return;
            }

            SetupFigmaLayout();
            this.Load += (s, e) =>
            {
                LoadCourts();
                UpdateCards();
                LoadFigmaColumns();
            };
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            LoadCourts();
            UpdateCards();
            LoadFigmaColumns();
        }

        private void UpdateCards()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // Total bookings
                string q1 = "SELECT COUNT(*) FROM BOOKINGS";
                using (var cmd = new SqlCommand(q1, conn))
                {
                    TotalBookingCountCard.ValueText = cmd.ExecuteScalar().ToString();
                }

                // Total customers
                string q2 = "SELECT COUNT(*) FROM CUSTOMERS";
                using (var cmd = new SqlCommand(q2, conn))
                {
                    TotalCustomersCard.ValueText = cmd.ExecuteScalar().ToString();
                }

                string rlm = "\u200F";

                // Today's income
                string q3 = "SELECT ISNULL(SUM(amount), 0) FROM PAYMENTS WHERE payment_date = @today";
                using (var cmd = new SqlCommand(q3, conn))
                {
                    cmd.Parameters.AddWithValue("@today", DateTime.Today);
                    double todayTotal = Convert.ToDouble(cmd.ExecuteScalar());
                    TotalIncomeCard.ValueText = $"{rlm}{todayTotal:N2} د.ل";
                }

                // Today's booked hours
                string q4 = "SELECT ISNULL(SUM(DATEDIFF(MINUTE, start_time, end_time)), 0) FROM BOOKINGS WHERE booking_date = @today";
                using (var cmd = new SqlCommand(q4, conn))
                {
                    cmd.Parameters.AddWithValue("@today", DateTime.Today);
                    double totalBookedMinutes = Convert.ToDouble(cmd.ExecuteScalar());
                    double totalBookedHours = totalBookedMinutes / 60.0;

                    // Total available hours (courts * 16 hours default)
                    string q5 = "SELECT COUNT(*) FROM COURTS";
                    int courtCount;
                    using (var cmd2 = new SqlCommand(q5, conn))
                    {
                        courtCount = (int)cmd2.ExecuteScalar();
                    }
                    double totalAvailableHours = courtCount * 16.0; // 8AM to midnight

                    double occupancyRate = 0;
                    if (totalAvailableHours > 0)
                    {
                        occupancyRate = (totalBookedHours / totalAvailableHours) * 100;
                    }
                    PercentgeCard.ValueText = $"{occupancyRate:N1}%";
                }
            }
        }

        public void LoadCourts()
        {
            CourtPanel.Controls.Clear();
            CourtPanel.RightToLeft = RightToLeft.Yes;
            CourtPanel.FlowDirection = FlowDirection.LeftToRight;

            var courts = Court.GetAll();
            var leftContainer = pnlLeftContainer;
            int availableWidth = leftContainer != null ? leftContainer.ClientSize.Width : CourtPanel.ClientSize.Width;

            // 3 columns layout for courts (adjusted mathematically for container padding: W - 170)
            int cols = 3;
            int courtWidth = (availableWidth - 170) / 3;
            if (courtWidth < 230) { courtWidth = (availableWidth - 120) / 2; cols = 2; }
            if (courtWidth < 230) { courtWidth = availableWidth - 80; cols = 1; }

            foreach (var court in courts)
            {
                CourtCard card = new CourtCard();
                card.CourtName = court.CourtName;
                card.SportType = court.SportType;

                if (!court.IsCurrentlyOpen())
                {
                    card.CustomStatusText = "خارج وقت العمل";
                }
                else
                {
                    card.CustomStatusText = ""; // Clear custom status
                    var currentBooking = GetActiveBookingForCourt(court.CourtName);
                    if (currentBooking != null)
                    {
                        card.IsReserved = true;
                        card.ReservationTime = $"محجوز من {currentBooking.StartTime:hh\\:mm} إلى {currentBooking.EndTime:hh\\:mm}";
                    }
                    else
                    {
                        card.IsReserved = false;
                    }
                }
                card.Width = courtWidth;
                card.Height = 115;
                card.Margin = new Padding(10);

                CourtPanel.Controls.Add(card);
            }

            // Explicitly set dynamic height on initial load
            if (courts.Count > 0)
            {
                int rows = (int)Math.Ceiling((double)courts.Count / cols);
                int calculatedHeight = rows * 135 + 10;
                CourtPanel.Height = calculatedHeight;

                var courtsContainer = this.Controls.Find("pnlCourtsContainer", true).FirstOrDefault() as Panel;
                if (courtsContainer != null && lblCourtsTitle != null)
                {
                    courtsContainer.Height = lblCourtsTitle.Height + calculatedHeight + 45;
                    if (wrapperCourts != null)
                    {
                        wrapperCourts.Height = courtsContainer.Height + wrapperCourts.Padding.Top + wrapperCourts.Padding.Bottom;
                    }
                }
            }
        }

        public static Booking GetActiveBookingForCourt(string courtName)
        {
            DateTime today = DateTime.Today;
            TimeSpan now = DateTime.Now.TimeOfDay;

            return Booking.GetAll().FirstOrDefault(b =>
                b.CourtName == courtName &&
                b.BookingDate.Date == today &&
                b.StartTime <= now &&
                b.EndTime >= now &&
                b.Status != BookingStatus.NoShow
            );
        }

        bool isFirstMode = true;

        private void DashBoardForm_DockChanged(object sender, EventArgs e)
        {
            if (isFirstMode)
            {
                foreach (var card in flowLayoutPanel1.Controls.OfType<AdvancedStatusCard>())
                {
                    card.Width = 360;
                    card.Margin = new Padding(10, 0, 10, 0);
                }
                flowLayoutPanel1.Padding = new Padding(30, 20, 30, 0);
            }
            else
            {
                foreach (var card in flowLayoutPanel1.Controls.OfType<AdvancedStatusCard>())
                {
                    card.Width = 420;
                    card.Margin = new Padding(10);
                }
                flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
                flowLayoutPanel1.Padding = new Padding(30, 20, 30, 20);
            }
            isFirstMode = !isFirstMode;
        }

        private void CourtPanel_Resize(object sender, EventArgs e)
        {
            var leftContainer = pnlLeftContainer;
            int availableWidth = leftContainer != null ? leftContainer.ClientSize.Width : CourtPanel.ClientSize.Width;

            // 3 columns layout for courts (adjusted mathematically for container padding: W - 170)
            int cols = 3;
            int courtWidth = (availableWidth - 170) / 3;
            if (courtWidth < 230) { courtWidth = (availableWidth - 120) / 2; cols = 2; }
            if (courtWidth < 230) { courtWidth = availableWidth - 80; cols = 1; }

            foreach (var card in CourtPanel.Controls.OfType<CourtCard>())
            {
                card.Width = courtWidth;
                card.Height = 115;
            }

            // Explicitly set dynamic height based on row count
            if (CourtPanel.Controls.Count > 0)
            {
                int rows = (int)Math.Ceiling((double)CourtPanel.Controls.Count / cols);
                int calculatedHeight = rows * 135 + 10;
                CourtPanel.Height = calculatedHeight;

                var courtsContainer = this.Controls.Find("pnlCourtsContainer", true).FirstOrDefault() as Panel;
                if (courtsContainer != null && lblCourtsTitle != null)
                {
                    courtsContainer.Height = lblCourtsTitle.Height + calculatedHeight + 45;
                    if (wrapperCourts != null)
                    {
                        wrapperCourts.Height = courtsContainer.Height + wrapperCourts.Padding.Top + wrapperCourts.Padding.Bottom;
                    }
                }
            }

            CourtPanel.ResumeLayout();
        }

        private void SetupFigmaLayout()
        {
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.RightToLeft = RightToLeft.Yes;
            this.AutoScroll = false; // Disable form-level scroll to avoid conflicts

            var leftContainer = pnlLeftContainer;
            if (leftContainer != null)
            {
                leftContainer.Dock = DockStyle.Fill;
                leftContainer.Padding = new Padding(0, 0, 0, 30); // Add bottom padding for better scroll feel
            }

            // Hide old hidden components to avoid Z-order overlaps
            var oldPanel1 = this.Controls.Find("panel1", true).FirstOrDefault();
            if (oldPanel1 != null) oldPanel1.Visible = false;

            if (lblCourtsTitle != null)
            {
                lblCourtsTitle.SendToBack();
            }
            if (CourtPanel != null)
            {
                CourtPanel.BringToFront();
                CourtPanel.RightToLeft = RightToLeft.Yes;
                CourtPanel.FlowDirection = FlowDirection.LeftToRight;
            }

            // Bind Navigation events to the cards in the designer
            Action navBooking = () => { var f = Application.OpenForms["MainForm"] as MainForm; if (f != null) f.NavigateToForm("Booking"); };
            Action navContract = () => { var f = Application.OpenForms["MainForm"] as MainForm; if (f != null) f.NavigateToForm("Contract"); };
            Action navExpense = () => { var f = Application.OpenForms["MainForm"] as MainForm; if (f != null) f.NavigateToForm("Expense"); };
            Action navCourts = () => { new StaduimSteting().ShowDialog(); };

            if (cardBooking != null) cardBooking.Click += (s, e) => navBooking();
            if (cardContract != null) cardContract.Click += (s, e) => navContract();
            if (cardExpense != null) cardExpense.Click += (s, e) => navExpense();
            if (cardCourts != null) cardCourts.Click += (s, e) => navCourts();

            // Set up KPI card parameters
            TotalBookingCountCard.TitleText = "إجمالي الحجوزات اليوم";
            TotalBookingCountCard.SubValueText = "";
            TotalIncomeCard.TitleText = "إجمالي الإيرادات اليوم";
            TotalIncomeCard.SubValueText = "";
            TotalCustomersCard.TitleText = "عدد العملاء النشطين";
            TotalCustomersCard.SubValueText = "";
            PercentgeCard.TitleText = "معدل الإشغال";
            PercentgeCard.SubValueText = "";

            var kpiCards = new Control[] { TotalBookingCountCard, TotalCustomersCard, TotalIncomeCard, PercentgeCard };

            // Centralized Responsive Layout Logic
            if (leftContainer != null)
            {
                int lastContainerWidth = 0;
                leftContainer.SizeChanged += (s, e) =>
                {
                    int currentWidth = leftContainer.ClientSize.Width;
                    // Threshold of 20px prevents infinite loops caused by scrollbars appearing/disappearing
                    if (Math.Abs(currentWidth - lastContainerWidth) < 20) return;
                    lastContainerWidth = currentWidth;

                    // Ensure ALL section panels use IDENTICAL side padding for pixel-perfect alignment
                    int sidePad = 10;
                    flowLayoutPanel1.Padding = new Padding(sidePad, 10, sidePad, 0);
                    pnlQuickActions.Padding = new Padding(sidePad, 0, sidePad, 5);
                    pnlQuickActions.AutoSize = true;
                    pnlQuickActions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    pnlBottomColumns.Padding = new Padding(sidePad, 10, sidePad, 20);

                    leftContainer.SuspendLayout();

                    // 1. Stats and Quick Actions (4 columns ideally)
                    int availableWidth = currentWidth - (sidePad * 2);
                    int kpiWidth = (availableWidth / 4) - 20; // 20 for margins (10 each side)
                    if (kpiWidth < 220) kpiWidth = (availableWidth / 2) - 20;
                    if (kpiWidth < 220) kpiWidth = availableWidth - 20;

                    foreach (Control c in kpiCards) { c.Width = kpiWidth; c.Height = 135; }
                    foreach (Control c in pnlQuickActions.Controls) { c.Width = kpiWidth; c.Height = 140; }

                    // 2. Notifications Columns (3 columns ideally)
                    int notifWidth = (availableWidth / 3) - 20;
                    if (notifWidth < 300) notifWidth = (availableWidth / 2) - 20;
                    if (notifWidth < 300) notifWidth = availableWidth - 20;

                    colTasks.Width = notifWidth;
                    colStock.Width = notifWidth;
                    colLate.Width = notifWidth;

                    foreach (Control c in flowTasks.Controls) c.Width = notifWidth - 35;
                    foreach (Control c in flowStock.Controls) c.Width = notifWidth - 35;
                    foreach (Control c in flowLateContracts.Controls) c.Width = notifWidth - 35;

                    // 3. Court Cards (3 columns ideally)
                    FlowLayoutPanel flowCourts = CourtPanel as FlowLayoutPanel;
                    if (flowCourts != null)
                    {
                        int cols = 3;
                        int courtWidth = (currentWidth - 170) / 3;
                        if (courtWidth < 230) { courtWidth = (currentWidth - 120) / 2; cols = 2; }
                        if (courtWidth < 230) { courtWidth = currentWidth - 80; cols = 1; }

                        foreach (Control c in flowCourts.Controls)
                        {
                            c.Width = courtWidth;
                            c.Height = 115;
                        }

                        // Explicitly set dynamic height based on row count
                        if (flowCourts.Controls.Count > 0)
                        {
                            int rows = (int)Math.Ceiling((double)flowCourts.Controls.Count / cols);
                            int calculatedHeight = rows * 135 + 10;
                            flowCourts.Height = calculatedHeight;

                            if (pnlCourtsContainer != null && lblCourtsTitle != null)
                            {
                                pnlCourtsContainer.Height = lblCourtsTitle.Height + calculatedHeight + 45;
                                if (wrapperCourts != null)
                                {
                                    wrapperCourts.Height = pnlCourtsContainer.Height + wrapperCourts.Padding.Top + wrapperCourts.Padding.Bottom;
                                }
                            }
                        }
                    }

                    leftContainer.ResumeLayout(true);
                };
            }

            // Rounded corner drawing for badges (placed here to avoid Visual Studio designer parsing limitations)
            if (badgeTasks != null)
            {
                badgeTasks.Paint += (s, e) =>
                {
                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        path.AddArc(0, 0, 10, 10, 180, 90);
                        path.AddArc(badgeTasks.Width - 10, 0, 10, 10, 270, 90);
                        path.AddArc(badgeTasks.Width - 10, badgeTasks.Height - 10, 10, 10, 0, 90);
                        path.AddArc(0, badgeTasks.Height - 10, 10, 10, 90, 90);
                        path.CloseFigure();
                        badgeTasks.Region = new Region(path);
                    }
                };
            }

            if (badgeStock != null)
            {
                badgeStock.Paint += (s, e) =>
                {
                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        path.AddArc(0, 0, 10, 10, 180, 90);
                        path.AddArc(badgeStock.Width - 10, 0, 10, 10, 270, 90);
                        path.AddArc(badgeStock.Width - 10, badgeStock.Height - 10, 10, 10, 0, 90);
                        path.AddArc(0, badgeStock.Height - 10, 10, 10, 90, 90);
                        path.CloseFigure();
                        badgeStock.Region = new Region(path);
                    }
                };
            }

            if (badgeLate != null)
            {
                badgeLate.Paint += (s, e) =>
                {
                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        path.AddArc(0, 0, 10, 10, 180, 90);
                        path.AddArc(badgeLate.Width - 10, 0, 10, 10, 270, 90);
                        path.AddArc(badgeLate.Width - 10, badgeLate.Height - 10, 10, 10, 0, 90);
                        path.AddArc(0, badgeLate.Height - 10, 10, 10, 90, 90);
                        path.CloseFigure();
                        badgeLate.Region = new Region(path);
                    }
                };
            }
        }

        private Control CreateShowMoreItem(string text, int width, EventHandler onClick)
        {
            var btn = new Button
            {
                Text = text,
                Font = new Font("Tajawal Medium", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(59, 130, 246), // Accent premium blue
                BackColor = Color.FromArgb(243, 248, 255), // Light blue highlight background
                FlatStyle = FlatStyle.Flat,
                Size = new Size(width, 45),
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 5, 0, 5),
                RightToLeft = RightToLeft.Yes
            };
            btn.FlatAppearance.BorderColor = Color.FromArgb(219, 234, 254);
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 242, 254);
            btn.Click += onClick;
            return btn;
        }

        private Control CreateShowLessItem(string text, int width, EventHandler onClick)
        {
            var btn = new Button
            {
                Text = text,
                Font = new Font("Tajawal Medium", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 116, 139), // Slate gray
                BackColor = Color.FromArgb(248, 250, 252), // Ultra light gray background
                FlatStyle = FlatStyle.Flat,
                Size = new Size(width, 45),
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 5, 0, 5),
                RightToLeft = RightToLeft.Yes
            };
            btn.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
            btn.Click += onClick;
            return btn;
        }

        private void LoadFigmaColumns()
        {
            // Clear current controls
            flowTasks.Controls.Clear();
            flowStock.Controls.Clear();
            flowLateContracts.Controls.Clear();

            // Disable inner scrollbars
            flowTasks.AutoScroll = false;
            flowStock.AutoScroll = false;
            flowLateContracts.AutoScroll = false;

            // Determine control width
            int itemWidth = flowTasks.ClientSize.Width - 10;
            if (itemWidth < 100) itemWidth = 255;

            // Temporary lists to collect all controls
            var taskControls = new List<Control>();
            var stockControls = new List<Control>();
            var lateControls = new List<Control>();

            // 1. Load Daily Tasks (completely dynamic from BOOKINGS)
            int taskCount = 0;
            int completedTasks = 0;
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string q = @"SELECT b.booking_ref, c.court_name, b.start_time 
                                 FROM BOOKINGS b 
                                 INNER JOIN COURTS c ON b.court_ref = c.court_ref 
                                 WHERE b.booking_date = @today";
                    using (var cmd = new SqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@today", DateTime.Today);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string bRef = reader.GetString(0);
                                string court = reader.GetString(1);
                                TimeSpan start = reader.GetTimeSpan(2);
                                bool isPast = start < DateTime.Now.TimeOfDay;

                                var taskItem = new TaskItemControl
                                {
                                    TitleText = $"تأكيد حجز {court} ({bRef})",
                                    TimeText = DateTime.Today.Add(start).ToString("hh:mm tt"),
                                    IsCompleted = isPast,
                                    Width = itemWidth
                                };
                                taskItem.StatusChanged += (s, e) =>
                                {
                                    int count = flowTasks.Controls.OfType<TaskItemControl>().Count();
                                    int completed = flowTasks.Controls.OfType<TaskItemControl>().Count(t => t.IsCompleted);
                                    UpdateBadge(flowTasks, $"{completed} / {count}");
                                };

                                taskControls.Add(taskItem);
                                taskCount++;
                                if (isPast) completedTasks++;
                            }
                        }
                    }
                }
            }
            catch { }
            UpdateBadge(flowTasks, $"{completedTasks} / {taskCount}");

            // 2. Load Stock (completely dynamic from INVENTORY)
            int stockCount = 0;
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string q = @"SELECT pr.product_name, c.category_name, i.current_quantity, pr.min_quantity 
                                    FROM INVENTORY i 
                                    INNER JOIN PRODUCTS pr ON i.item_ref = pr.product_ref
                                    LEFT JOIN INVENTORY_CATEGORIES c ON pr.category_ref = c.category_ref 
                                    WHERE i.current_quantity <= pr.min_quantity";
                    using (var cmd = new SqlCommand(q, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string itemName = reader.GetString(0);
                                string category = reader.IsDBNull(1) ? "مستلزمات" : reader.GetString(1);
                                int currentQty = reader.GetInt32(2);
                                int minQty = reader.GetInt32(3);

                                var stockItem = new StockItemControl
                                {
                                    ItemName = itemName,
                                    SubText = $"{category}\n{currentQty} / {minQty} (الحد الأدنى)",
                                    Width = itemWidth
                                };
                                stockItem.OrderClicked += (s, e) => MessageBox.Show($"تم طلب {itemName} بنجاح!", "طلب توريد", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                stockControls.Add(stockItem);
                                stockCount++;
                            }
                        }
                    }
                }
            }
            catch { }
            UpdateBadge(flowStock, stockCount.ToString());

            // 3. Load Late Contracts (completely dynamic from MONTHLY_CONTRACTS)
            int lateCount = 0;
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string q = @"
                        SELECT C.full_name, CO.court_name, MC.monthly_value, MC.end_date, MC.contract_ref
                        FROM MONTHLY_CONTRACTS MC
                        INNER JOIN CUSTOMERS C ON MC.customer_phone_number = C.phone_number
                        INNER JOIN COURTS CO ON MC.court_ref = CO.court_ref
                        WHERE MC.payment_status != N'مدفوع' AND MC.payment_status != N'paid'
                           OR MC.end_date <= DATEADD(day, 3, @today)";
                    using (var cmd = new SqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@today", DateTime.Today);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader.GetString(0);
                                string court = reader.GetString(1);
                                decimal val = reader.GetDecimal(2);
                                DateTime endDate = reader.GetDateTime(3);
                                string contractRef = reader.GetString(4);
                                int lateDays = (DateTime.Today - endDate).Days;
                                string lateText = lateDays > 0 ? $"متأخر {lateDays} أيام" : "يستحق التحصيل";

                                var lateItem = new LateContractItemControl
                                {
                                    CustomerName = name,
                                    SubText = $"{court} - {val:N0} د.ل",
                                    LateDaysText = lateText,
                                    Width = itemWidth
                                };
                                lateItem.CollectClicked += (s, e) => MessageBox.Show($"تحصيل قيمة العقد للعميل {name} بقيمة {val:N0} د.ل...", "تحصيل عقد", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                lateControls.Add(lateItem);
                                lateCount++;
                            }
                        }
                    }
                }
            }
            catch { }
            UpdateBadge(flowLateContracts, lateCount.ToString());

            // Populate FlowLayoutPanels based on expansion state
            PopulateColumn(flowTasks, taskControls, itemWidth);
            PopulateColumn(flowStock, stockControls, itemWidth);
            PopulateColumn(flowLateContracts, lateControls, itemWidth);

            // Calculate the exact height required based on the CURRENT loaded controls to prevent any cropping or scrollbars
            int maxFlowHeight = 0;
            foreach (var flow in new[] { flowTasks, flowStock, flowLateContracts })
            {
                int flowHeight = 0;
                foreach (Control c in flow.Controls)
                {
                    flowHeight += c.Height + c.Margin.Top + c.Margin.Bottom;
                }
                if (flowHeight > maxFlowHeight)
                {
                    maxFlowHeight = flowHeight;
                }
            }

            // Ensure a beautiful premium minimum height so empty cards look perfect
            maxFlowHeight = Math.Max(maxFlowHeight, 280);

            // Set the outer custom panels to this dynamically computed height
            int colHeight = maxFlowHeight + 85;
            colTasks.Height = colHeight;
            colStock.Height = colHeight;
            colLate.Height = colHeight;
        }

        private void PopulateColumn(FlowLayoutPanel panel, List<Control> controls, int itemWidth)
        {
            if (isExpanded)
            {
                foreach (var control in controls)
                {
                    control.Width = itemWidth;
                    panel.Controls.Add(control);
                }
                if (controls.Count > 3)
                {
                    panel.Controls.Add(CreateShowLessItem("عرض أقل 🡱", itemWidth, (s, e) => { isExpanded = false; LoadFigmaColumns(); }));
                }
            }
            else
            {
                for (int i = 0; i < Math.Min(3, controls.Count); i++)
                {
                    controls[i].Width = itemWidth;
                    panel.Controls.Add(controls[i]);
                }
                if (controls.Count > 3)
                {
                    panel.Controls.Add(CreateShowMoreItem($"عرض المزيد (+{controls.Count - 3}) 🡳", itemWidth, (s, e) => { isExpanded = true; LoadFigmaColumns(); }));
                }
            }
        }

        private void UpdateBadge(FlowLayoutPanel panel, string text)
        {
            foreach (Control parent in panel.Parent.Controls)
            {
                if (parent is Panel header && header != panel)
                {
                    foreach (Control c in header.Controls)
                    {
                        if (c is Label badge && (badge.Text.Contains("/") || text.Contains("/") || badge.Width == 48 || badge.Location.X < 50))
                        {
                            badge.Text = text;
                        }
                    }
                }
            }
        }

        
    }
}
