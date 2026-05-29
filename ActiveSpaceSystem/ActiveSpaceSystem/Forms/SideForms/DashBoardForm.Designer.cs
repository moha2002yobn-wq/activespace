namespace ActiveSpaceSystem.Forms.SideForms
{
    partial class DashBoardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoardForm));
            flowLayoutPanel1 = new FlowLayoutPanel();
            TotalBookingCountCard = new ActiveSpaceSystem.CustomItems.AdvancedStatusCard();
            TotalCustomersCard = new ActiveSpaceSystem.CustomItems.AdvancedStatusCard();
            TotalIncomeCard = new ActiveSpaceSystem.CustomItems.AdvancedStatusCard();
            PercentgeCard = new ActiveSpaceSystem.CustomItems.AdvancedStatusCard();
            label13 = new Label();
            panel1 = new Panel();
            CourtsPanel = new ActiveSpaceSystem.CustomItems.CustomPanel();
            panel4 = new Panel();
            label19 = new Label();
            CourtPanel = new FlowLayoutPanel();
            customPanel1 = new ActiveSpaceSystem.CustomItems.CustomPanel();
            customChart1 = new ActiveSpaceSystem.CustomItems.CustomChart();
            panel2 = new Panel();
            pnlLeftContainer = new Panel();
            wrapperCourts = new Panel();
            pnlCourtsContainer = new ActiveSpaceSystem.CustomItems.CustomPanel();
            lblCourtsTitle = new Label();
            pnlBottomColumns = new FlowLayoutPanel();
            colTasks = new ActiveSpaceSystem.CustomItems.CustomPanel();
            flowTasks = new FlowLayoutPanel();
            headerTasks = new Panel();
            titleTasks = new Label();
            badgeTasks = new Label();
            colStock = new ActiveSpaceSystem.CustomItems.CustomPanel();
            flowStock = new FlowLayoutPanel();
            headerStock = new Panel();
            titleStock = new Label();
            badgeStock = new Label();
            colLate = new ActiveSpaceSystem.CustomItems.CustomPanel();
            flowLateContracts = new FlowLayoutPanel();
            headerLate = new Panel();
            titleLate = new Label();
            badgeLate = new Label();
            pnlQuickActions = new FlowLayoutPanel();
            cardBooking = new ActiveSpaceSystem.CustomItems.QuickActionCard();
            cardContract = new ActiveSpaceSystem.CustomItems.QuickActionCard();
            cardExpense = new ActiveSpaceSystem.CustomItems.QuickActionCard();
            cardCourts = new ActiveSpaceSystem.CustomItems.QuickActionCard();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            customPanel1.SuspendLayout();
            panel2.SuspendLayout();
            pnlLeftContainer.SuspendLayout();
            wrapperCourts.SuspendLayout();
            pnlCourtsContainer.SuspendLayout();
            pnlBottomColumns.SuspendLayout();
            colTasks.SuspendLayout();
            headerTasks.SuspendLayout();
            colStock.SuspendLayout();
            headerStock.SuspendLayout();
            colLate.SuspendLayout();
            headerLate.SuspendLayout();
            pnlQuickActions.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(TotalBookingCountCard);
            flowLayoutPanel1.Controls.Add(TotalCustomersCard);
            flowLayoutPanel1.Controls.Add(TotalIncomeCard);
            flowLayoutPanel1.Controls.Add(PercentgeCard);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(30, 10, 30, 10);
            flowLayoutPanel1.Size = new Size(792, 700);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // TotalBookingCountCard
            // 
            TotalBookingCountCard.BackColor = Color.Transparent;
            TotalBookingCountCard.BorderRadius = 20;
            TotalBookingCountCard.CardIcon = Properties.Resources.calendar_70;
            TotalBookingCountCard.IconBackColor = Color.White;
            TotalBookingCountCard.IconSize = 70;
            TotalBookingCountCard.Location = new Point(252, 20);
            TotalBookingCountCard.Margin = new Padding(10);
            TotalBookingCountCard.Name = "TotalBookingCountCard";
            TotalBookingCountCard.ShadowSize = 6;
            TotalBookingCountCard.Size = new Size(470, 150);
            TotalBookingCountCard.SubValueColor = Color.FromArgb(46, 204, 113);
            TotalBookingCountCard.SubValueFont = new Font("Tajawal", 9F);
            TotalBookingCountCard.SubValueText = "";
            TotalBookingCountCard.TabIndex = 0;
            TotalBookingCountCard.TitleColor = Color.Gray;
            TotalBookingCountCard.TitleFont = new Font("Tajawal Medium", 12F, FontStyle.Bold);
            TotalBookingCountCard.TitleText = "إجمالي الحجوزات اليوم";
            TotalBookingCountCard.ValueColor = SystemColors.ControlText;
            TotalBookingCountCard.ValueFont = new Font("Tajawal", 16F, FontStyle.Bold);
            TotalBookingCountCard.ValueText = "12,450 د.ل";
            // 
            // TotalCustomersCard
            // 
            TotalCustomersCard.BackColor = Color.Transparent;
            TotalCustomersCard.BorderRadius = 20;
            TotalCustomersCard.CardIcon = Properties.Resources.users_70__1_;
            TotalCustomersCard.IconBackColor = Color.White;
            TotalCustomersCard.IconSize = 70;
            TotalCustomersCard.Location = new Point(252, 190);
            TotalCustomersCard.Margin = new Padding(10);
            TotalCustomersCard.Name = "TotalCustomersCard";
            TotalCustomersCard.ShadowSize = 6;
            TotalCustomersCard.Size = new Size(470, 150);
            TotalCustomersCard.SubValueColor = Color.FromArgb(46, 204, 113);
            TotalCustomersCard.SubValueFont = new Font("Tajawal", 9F);
            TotalCustomersCard.SubValueText = "";
            TotalCustomersCard.TabIndex = 1;
            TotalCustomersCard.TitleColor = Color.Gray;
            TotalCustomersCard.TitleFont = new Font("Tajawal Medium", 12F, FontStyle.Bold);
            TotalCustomersCard.TitleText = "عدد العملاء النشطين";
            TotalCustomersCard.ValueColor = SystemColors.ControlText;
            TotalCustomersCard.ValueFont = new Font("Tajawal", 16F, FontStyle.Bold);
            TotalCustomersCard.ValueText = "12,450 د.ل";
            // 
            // TotalIncomeCard
            // 
            TotalIncomeCard.BackColor = Color.Transparent;
            TotalIncomeCard.BorderRadius = 20;
            TotalIncomeCard.CardIcon = Properties.Resources.mon_70;
            TotalIncomeCard.IconBackColor = Color.White;
            TotalIncomeCard.IconSize = 70;
            TotalIncomeCard.Location = new Point(252, 360);
            TotalIncomeCard.Margin = new Padding(10);
            TotalIncomeCard.Name = "TotalIncomeCard";
            TotalIncomeCard.ShadowSize = 6;
            TotalIncomeCard.Size = new Size(470, 150);
            TotalIncomeCard.SubValueColor = Color.FromArgb(46, 204, 113);
            TotalIncomeCard.SubValueFont = new Font("Tajawal", 9F);
            TotalIncomeCard.SubValueText = "";
            TotalIncomeCard.TabIndex = 2;
            TotalIncomeCard.TitleColor = Color.Gray;
            TotalIncomeCard.TitleFont = new Font("Tajawal Medium", 12F, FontStyle.Bold);
            TotalIncomeCard.TitleText = "إجمالي الإيرادات اليوم";
            TotalIncomeCard.ValueColor = SystemColors.ControlText;
            TotalIncomeCard.ValueFont = new Font("Tajawal", 16F, FontStyle.Bold);
            TotalIncomeCard.ValueText = "12,450 د.ل";
            // 
            // PercentgeCard
            // 
            PercentgeCard.BackColor = Color.Transparent;
            PercentgeCard.BorderRadius = 20;
            PercentgeCard.CardIcon = Properties.Resources.pulse_70;
            PercentgeCard.IconBackColor = Color.White;
            PercentgeCard.IconSize = 70;
            PercentgeCard.Location = new Point(252, 530);
            PercentgeCard.Margin = new Padding(10);
            PercentgeCard.Name = "PercentgeCard";
            PercentgeCard.ShadowSize = 6;
            PercentgeCard.Size = new Size(470, 150);
            PercentgeCard.SubValueColor = Color.FromArgb(46, 204, 113);
            PercentgeCard.SubValueFont = new Font("Tajawal", 9F);
            PercentgeCard.SubValueText = "";
            PercentgeCard.TabIndex = 3;
            PercentgeCard.TitleColor = Color.Gray;
            PercentgeCard.TitleFont = new Font("Tajawal Medium", 12F, FontStyle.Bold);
            PercentgeCard.TitleText = "معدل الإنشغال";
            PercentgeCard.ValueColor = SystemColors.ControlText;
            PercentgeCard.ValueFont = new Font("Tajawal", 16F, FontStyle.Bold);
            PercentgeCard.ValueText = "12,450 د.ل";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Tajawal Medium", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(649, 17);
            label13.Name = "label13";
            label13.Size = new Size(315, 41);
            label13.TabIndex = 7;
            label13.Text = "الإيرادات خلال الأسبوع";
            // 
            // panel1
            // 
            panel1.Controls.Add(CourtsPanel);
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 380);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(1001, 722);
            panel1.TabIndex = 2;
            panel1.Visible = false;
            // 
            // CourtsPanel
            // 
            CourtsPanel.AutoScroll = true;
            CourtsPanel.BackColor = Color.White;
            CourtsPanel.BorderColor = Color.FromArgb(230, 230, 230);
            CourtsPanel.BorderRadius = 20;
            CourtsPanel.BorderSize = 1F;
            CourtsPanel.Dock = DockStyle.Fill;
            CourtsPanel.Location = new Point(10, 67);
            CourtsPanel.Name = "CourtsPanel";
            CourtsPanel.Padding = new Padding(30);
            CourtsPanel.ShowShadow = true;
            CourtsPanel.Size = new Size(981, 645);
            CourtsPanel.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(label19);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(10, 10);
            panel4.Name = "panel4";
            panel4.Size = new Size(981, 57);
            panel4.TabIndex = 0;
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.Right;
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.Black;
            label19.Location = new Point(813, 15);
            label19.Name = "label19";
            label19.Size = new Size(122, 29);
            label19.TabIndex = 10;
            label19.Text = "حالة الملاعب";
            label19.Click += label19_Click;
            // 
            // CourtPanel
            // 
            CourtPanel.AutoSize = true;
            CourtPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CourtPanel.Dock = DockStyle.Top;
            CourtPanel.FlowDirection = FlowDirection.LeftToRight;
            CourtPanel.Location = new Point(20, 65);
            CourtPanel.Name = "CourtPanel";
            CourtPanel.Size = new Size(692, 0);
            CourtPanel.TabIndex = 0;
            CourtPanel.Resize += CourtPanel_Resize;
            // 
            // customPanel1
            // 
            customPanel1.BackColor = Color.White;
            customPanel1.BorderColor = Color.FromArgb(230, 230, 230);
            customPanel1.BorderRadius = 20;
            customPanel1.BorderSize = 1F;
            customPanel1.Controls.Add(customChart1);
            customPanel1.Controls.Add(panel2);
            customPanel1.Dock = DockStyle.Top;
            customPanel1.Location = new Point(0, 380);
            customPanel1.Name = "customPanel1";
            customPanel1.Padding = new Padding(10);
            customPanel1.ShowShadow = true;
            customPanel1.Size = new Size(1001, 566);
            customPanel1.TabIndex = 1;
            // 
            // customChart1
            // 
            customChart1.BackColor = Color.White;
            customChart1.BarColor = Color.FromArgb(46, 204, 113);
            customChart1.ChartData = (Dictionary<string, double>)resources.GetObject("customChart1.ChartData");
            customChart1.Dock = DockStyle.Fill;
            customChart1.LabelFont = new Font("Tajawal", 8F);
            customChart1.Location = new Point(10, 87);
            customChart1.Name = "customChart1";
            customChart1.Size = new Size(981, 469);
            customChart1.TabIndex = 1;
            customChart1.ValueFont = new Font("Tajawal", 9F, FontStyle.Bold);
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(248, 250, 252);
            panel2.Controls.Add(label13);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(10, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(981, 77);
            panel2.TabIndex = 0;
            // 
            // pnlLeftContainer
            // 
            pnlLeftContainer.AutoScroll = true;
            pnlLeftContainer.Controls.Add(wrapperCourts);
            pnlLeftContainer.Controls.Add(pnlBottomColumns);
            pnlLeftContainer.Controls.Add(pnlQuickActions);
            pnlLeftContainer.Controls.Add(flowLayoutPanel1);
            pnlLeftContainer.Dock = DockStyle.Fill;
            pnlLeftContainer.Location = new Point(0, 0);
            pnlLeftContainer.Name = "pnlLeftContainer";
            pnlLeftContainer.Size = new Size(813, 600);
            pnlLeftContainer.TabIndex = 4;
            // 
            // wrapperCourts
            // 
            wrapperCourts.AutoSize = true;
            wrapperCourts.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            wrapperCourts.BackColor = Color.Transparent;
            wrapperCourts.Controls.Add(pnlCourtsContainer);
            wrapperCourts.Dock = DockStyle.Top;
            wrapperCourts.Location = new Point(0, 2066);
            wrapperCourts.Name = "wrapperCourts";
            wrapperCourts.Padding = new Padding(30, 10, 30, 30);
            wrapperCourts.Size = new Size(792, 360);
            wrapperCourts.TabIndex = 0;
            // 
            // pnlCourtsContainer
            // 
            pnlCourtsContainer.AutoSize = true;
            pnlCourtsContainer.BackColor = Color.White;
            pnlCourtsContainer.BorderColor = Color.FromArgb(226, 232, 240);
            pnlCourtsContainer.BorderRadius = 20;
            pnlCourtsContainer.BorderSize = 1F;
            pnlCourtsContainer.Controls.Add(CourtPanel);
            pnlCourtsContainer.Controls.Add(lblCourtsTitle);
            pnlCourtsContainer.Dock = DockStyle.Top;
            pnlCourtsContainer.Location = new Point(30, 10);
            pnlCourtsContainer.MinimumSize = new Size(0, 320);
            pnlCourtsContainer.Name = "pnlCourtsContainer";
            pnlCourtsContainer.Padding = new Padding(20);
            pnlCourtsContainer.ShowShadow = true;
            pnlCourtsContainer.Size = new Size(732, 320);
            pnlCourtsContainer.TabIndex = 0;
            // 
            // lblCourtsTitle
            // 
            lblCourtsTitle.Dock = DockStyle.Top;
            lblCourtsTitle.Font = new Font("Tajawal Medium", 16F, FontStyle.Bold);
            lblCourtsTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblCourtsTitle.Location = new Point(20, 20);
            lblCourtsTitle.Name = "lblCourtsTitle";
            lblCourtsTitle.Padding = new Padding(0, 0, 15, 5);
            lblCourtsTitle.RightToLeft = RightToLeft.No;
            lblCourtsTitle.Size = new Size(692, 45);
            lblCourtsTitle.TabIndex = 0;
            lblCourtsTitle.Text = "حالة الملاعب الآن";
            lblCourtsTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlBottomColumns
            // 
            pnlBottomColumns.AutoSize = true;
            pnlBottomColumns.BackColor = Color.Transparent;
            pnlBottomColumns.Controls.Add(colTasks);
            pnlBottomColumns.Controls.Add(colStock);
            pnlBottomColumns.Controls.Add(colLate);
            pnlBottomColumns.Dock = DockStyle.Top;
            pnlBottomColumns.Location = new Point(0, 1036);
            pnlBottomColumns.MinimumSize = new Size(0, 530);
            pnlBottomColumns.Name = "pnlBottomColumns";
            pnlBottomColumns.Padding = new Padding(30, 10, 30, 20);
            pnlBottomColumns.RightToLeft = RightToLeft.Yes;
            pnlBottomColumns.Size = new Size(792, 1030);
            pnlBottomColumns.TabIndex = 1;
            // 
            // colTasks
            // 
            colTasks.BackColor = Color.White;
            colTasks.BorderColor = Color.FromArgb(226, 232, 240);
            colTasks.BorderRadius = 20;
            colTasks.BorderSize = 1F;
            colTasks.Controls.Add(flowTasks);
            colTasks.Controls.Add(headerTasks);
            colTasks.Location = new Point(402, 20);
            colTasks.Margin = new Padding(10);
            colTasks.Name = "colTasks";
            colTasks.Padding = new Padding(15);
            colTasks.ShowShadow = true;
            colTasks.Size = new Size(320, 480);
            colTasks.TabIndex = 0;
            // 
            // flowTasks
            // 
            flowTasks.AutoScroll = true;
            flowTasks.BackColor = Color.Transparent;
            flowTasks.Dock = DockStyle.Fill;
            flowTasks.FlowDirection = FlowDirection.TopDown;
            flowTasks.Location = new Point(15, 65);
            flowTasks.Name = "flowTasks";
            flowTasks.Padding = new Padding(0, 10, 0, 0);
            flowTasks.Size = new Size(290, 400);
            flowTasks.TabIndex = 0;
            flowTasks.WrapContents = false;
            // 
            // headerTasks
            // 
            headerTasks.BackColor = Color.Transparent;
            headerTasks.Controls.Add(titleTasks);
            headerTasks.Controls.Add(badgeTasks);
            headerTasks.Dock = DockStyle.Top;
            headerTasks.Location = new Point(15, 15);
            headerTasks.Name = "headerTasks";
            headerTasks.Size = new Size(290, 50);
            headerTasks.TabIndex = 1;
            // 
            // titleTasks
            // 
            titleTasks.AutoSize = true;
            titleTasks.Dock = DockStyle.Right;
            titleTasks.Font = new Font("Tajawal Medium", 13F, FontStyle.Bold);
            titleTasks.ForeColor = Color.FromArgb(15, 23, 42);
            titleTasks.Location = new Point(94, 0);
            titleTasks.Name = "titleTasks";
            titleTasks.RightToLeft = RightToLeft.Yes;
            titleTasks.Size = new Size(196, 30);
            titleTasks.TabIndex = 0;
            titleTasks.Text = "📋 المهام اليومية";
            titleTasks.TextAlign = ContentAlignment.MiddleRight;
            // 
            // badgeTasks
            // 
            badgeTasks.BackColor = Color.FromArgb(241, 245, 249);
            badgeTasks.Font = new Font("Tajawal", 9F, FontStyle.Bold);
            badgeTasks.ForeColor = Color.FromArgb(100, 116, 139);
            badgeTasks.Location = new Point(10, 12);
            badgeTasks.Name = "badgeTasks";
            badgeTasks.Size = new Size(48, 25);
            badgeTasks.TabIndex = 1;
            badgeTasks.Text = "2 / 5";
            badgeTasks.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // colStock
            // 
            colStock.BackColor = Color.White;
            colStock.BorderColor = Color.FromArgb(226, 232, 240);
            colStock.BorderRadius = 20;
            colStock.BorderSize = 1F;
            colStock.Controls.Add(flowStock);
            colStock.Controls.Add(headerStock);
            colStock.Location = new Point(62, 20);
            colStock.Margin = new Padding(10);
            colStock.Name = "colStock";
            colStock.Padding = new Padding(15);
            colStock.ShowShadow = true;
            colStock.Size = new Size(320, 480);
            colStock.TabIndex = 1;
            // 
            // flowStock
            // 
            flowStock.AutoScroll = true;
            flowStock.BackColor = Color.Transparent;
            flowStock.Dock = DockStyle.Fill;
            flowStock.FlowDirection = FlowDirection.TopDown;
            flowStock.Location = new Point(15, 65);
            flowStock.Name = "flowStock";
            flowStock.Padding = new Padding(0, 10, 0, 0);
            flowStock.Size = new Size(290, 400);
            flowStock.TabIndex = 0;
            flowStock.WrapContents = false;
            // 
            // headerStock
            // 
            headerStock.BackColor = Color.Transparent;
            headerStock.Controls.Add(titleStock);
            headerStock.Controls.Add(badgeStock);
            headerStock.Dock = DockStyle.Top;
            headerStock.Location = new Point(15, 15);
            headerStock.Name = "headerStock";
            headerStock.Size = new Size(290, 50);
            headerStock.TabIndex = 1;
            // 
            // titleStock
            // 
            titleStock.AutoSize = true;
            titleStock.Dock = DockStyle.Right;
            titleStock.Font = new Font("Tajawal Medium", 13F, FontStyle.Bold);
            titleStock.ForeColor = Color.FromArgb(15, 23, 42);
            titleStock.Location = new Point(85, 0);
            titleStock.Name = "titleStock";
            titleStock.RightToLeft = RightToLeft.Yes;
            titleStock.Size = new Size(205, 30);
            titleStock.TabIndex = 0;
            titleStock.Text = "📦 مخزون منخفض";
            titleStock.TextAlign = ContentAlignment.MiddleRight;
            // 
            // badgeStock
            // 
            badgeStock.BackColor = Color.FromArgb(254, 249, 195);
            badgeStock.Font = new Font("Tajawal", 9F, FontStyle.Bold);
            badgeStock.ForeColor = Color.FromArgb(202, 138, 4);
            badgeStock.Location = new Point(10, 12);
            badgeStock.Name = "badgeStock";
            badgeStock.Size = new Size(48, 25);
            badgeStock.TabIndex = 1;
            badgeStock.Text = "3";
            badgeStock.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // colLate
            // 
            colLate.BackColor = Color.White;
            colLate.BorderColor = Color.FromArgb(226, 232, 240);
            colLate.BorderRadius = 20;
            colLate.BorderSize = 1F;
            colLate.Controls.Add(flowLateContracts);
            colLate.Controls.Add(headerLate);
            colLate.Location = new Point(402, 520);
            colLate.Margin = new Padding(10);
            colLate.Name = "colLate";
            colLate.Padding = new Padding(15);
            colLate.ShowShadow = true;
            colLate.Size = new Size(320, 480);
            colLate.TabIndex = 2;
            // 
            // flowLateContracts
            // 
            flowLateContracts.AutoScroll = true;
            flowLateContracts.BackColor = Color.Transparent;
            flowLateContracts.Dock = DockStyle.Fill;
            flowLateContracts.FlowDirection = FlowDirection.TopDown;
            flowLateContracts.Location = new Point(15, 65);
            flowLateContracts.Name = "flowLateContracts";
            flowLateContracts.Padding = new Padding(0, 10, 0, 0);
            flowLateContracts.Size = new Size(290, 400);
            flowLateContracts.TabIndex = 0;
            flowLateContracts.WrapContents = false;
            // 
            // headerLate
            // 
            headerLate.BackColor = Color.Transparent;
            headerLate.Controls.Add(titleLate);
            headerLate.Controls.Add(badgeLate);
            headerLate.Dock = DockStyle.Top;
            headerLate.Location = new Point(15, 15);
            headerLate.Name = "headerLate";
            headerLate.Size = new Size(290, 50);
            headerLate.TabIndex = 1;
            // 
            // titleLate
            // 
            titleLate.AutoSize = true;
            titleLate.Dock = DockStyle.Right;
            titleLate.Font = new Font("Tajawal Medium", 13F, FontStyle.Bold);
            titleLate.ForeColor = Color.FromArgb(15, 23, 42);
            titleLate.Location = new Point(120, 0);
            titleLate.Name = "titleLate";
            titleLate.RightToLeft = RightToLeft.Yes;
            titleLate.Size = new Size(170, 30);
            titleLate.TabIndex = 0;
            titleLate.Text = "\U0001f6d1 عقود متأخرة";
            titleLate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // badgeLate
            // 
            badgeLate.BackColor = Color.FromArgb(254, 226, 226);
            badgeLate.Font = new Font("Tajawal", 9F, FontStyle.Bold);
            badgeLate.ForeColor = Color.FromArgb(220, 38, 38);
            badgeLate.Location = new Point(10, 12);
            badgeLate.Name = "badgeLate";
            badgeLate.Size = new Size(48, 25);
            badgeLate.TabIndex = 1;
            badgeLate.Text = "3";
            badgeLate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlQuickActions
            // 
            pnlQuickActions.AutoSize = true;
            pnlQuickActions.BackColor = Color.Transparent;
            pnlQuickActions.Controls.Add(cardBooking);
            pnlQuickActions.Controls.Add(cardContract);
            pnlQuickActions.Controls.Add(cardExpense);
            pnlQuickActions.Controls.Add(cardCourts);
            pnlQuickActions.Dock = DockStyle.Top;
            pnlQuickActions.Location = new Point(0, 700);
            pnlQuickActions.MinimumSize = new Size(0, 100);
            pnlQuickActions.Name = "pnlQuickActions";
            pnlQuickActions.Padding = new Padding(30, 10, 30, 10);
            pnlQuickActions.RightToLeft = RightToLeft.Yes;
            pnlQuickActions.Size = new Size(792, 336);
            pnlQuickActions.TabIndex = 2;
            // 
            // cardBooking
            // 
            cardBooking.BackColor = Color.White;
            cardBooking.BorderColor = Color.FromArgb(226, 232, 240);
            cardBooking.BorderRadius = 18;
            cardBooking.BorderSize = 1F;
            cardBooking.CardIconImage = Properties.Resources.icons8_calendar_80;
            cardBooking.IconBorderRadius = 12;
            cardBooking.IconBoxSize = 50;
            cardBooking.IconEmoji = "📅";
            cardBooking.IconSize = 30;
            cardBooking.Location = new Point(482, 20);
            cardBooking.Margin = new Padding(10);
            cardBooking.Name = "cardBooking";
            cardBooking.Padding = new Padding(5);
            cardBooking.ShowShadow = true;
            cardBooking.Size = new Size(240, 138);
            cardBooking.SubText = "+ إضافة جديد";
            cardBooking.TabIndex = 0;
            cardBooking.ThemeColor = Color.FromArgb(43, 127, 255);
            cardBooking.TitleText = "إضافة حجز جديد";
            
            // 
            // cardContract
            // 
            cardContract.BackColor = Color.White;
            cardContract.BorderColor = Color.FromArgb(226, 232, 240);
            cardContract.BorderRadius = 18;
            cardContract.BorderSize = 1F;
            cardContract.CardIconImage = Properties.Resources.icons8_contract_64;
            cardContract.IconBorderRadius = 12;
            cardContract.IconBoxSize = 50;
            cardContract.IconEmoji = "📄";
            cardContract.IconSize = 30;
            cardContract.Location = new Point(222, 20);
            cardContract.Margin = new Padding(10);
            cardContract.Name = "cardContract";
            cardContract.Padding = new Padding(5);
            cardContract.ShowShadow = true;
            cardContract.Size = new Size(240, 138);
            cardContract.SubText = "+ إضافة جديد";
            cardContract.TabIndex = 1;
            cardContract.ThemeColor = Color.FromArgb(46, 204, 113);
            cardContract.TitleText = "إضافة عقد شهري";
            // 
            // cardExpense
            // 
            cardExpense.BackColor = Color.White;
            cardExpense.BorderColor = Color.FromArgb(226, 232, 240);
            cardExpense.BorderRadius = 18;
            cardExpense.BorderSize = 1F;
            cardExpense.CardIconImage = Properties.Resources.icons8_split_money_50;
            cardExpense.IconBorderRadius = 12;
            cardExpense.IconBoxSize = 50;
            cardExpense.IconEmoji = "💵";
            cardExpense.IconSize = 30;
            cardExpense.Location = new Point(482, 178);
            cardExpense.Margin = new Padding(10);
            cardExpense.Name = "cardExpense";
            cardExpense.Padding = new Padding(5);
            cardExpense.ShowShadow = true;
            cardExpense.Size = new Size(240, 138);
            cardExpense.SubText = "+ إضافة جديد";
            cardExpense.TabIndex = 2;
            cardExpense.ThemeColor = Color.FromArgb(231, 76, 60);
            cardExpense.TitleText = "تسجيل مصروف";
            // 
            // cardCourts
            // 
            cardCourts.BackColor = Color.White;
            cardCourts.BorderColor = Color.FromArgb(226, 232, 240);
            cardCourts.BorderRadius = 18;
            cardCourts.BorderSize = 1F;
            cardCourts.CardIconImage = Properties.Resources.icons8_stadium_80__1_;
            cardCourts.IconBorderRadius = 12;
            cardCourts.IconBoxSize = 50;
            cardCourts.IconEmoji = "📋";
            cardCourts.IconSize = 40;
            cardCourts.Location = new Point(222, 178);
            cardCourts.Margin = new Padding(10);
            cardCourts.Name = "cardCourts";
            cardCourts.Padding = new Padding(5);
            cardCourts.ShowShadow = true;
            cardCourts.Size = new Size(240, 138);
            cardCourts.SubText = "+ إضافة جديد";
            cardCourts.TabIndex = 3;
            cardCourts.ThemeColor = Color.FromArgb(43, 127, 255);
            cardCourts.TitleText = "إدارة الملاعب";
            // 
            // DashBoardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(813, 600);
            Controls.Add(pnlLeftContainer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DashBoardForm";
            Text = "DashBoardForm";
            DockChanged += DashBoardForm_DockChanged;
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            customPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlLeftContainer.ResumeLayout(false);
            pnlLeftContainer.PerformLayout();
            wrapperCourts.ResumeLayout(false);
            wrapperCourts.PerformLayout();
            pnlCourtsContainer.ResumeLayout(false);
            pnlCourtsContainer.PerformLayout();
            pnlBottomColumns.ResumeLayout(false);
            colTasks.ResumeLayout(false);
            headerTasks.ResumeLayout(false);
            headerTasks.PerformLayout();
            colStock.ResumeLayout(false);
            headerStock.ResumeLayout(false);
            headerStock.PerformLayout();
            colLate.ResumeLayout(false);
            headerLate.ResumeLayout(false);
            headerLate.PerformLayout();
            pnlQuickActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private CustomItems.AdvancedStatusCard TotalBookingCountCard;
        private CustomItems.AdvancedStatusCard TotalCustomersCard;
        private CustomItems.AdvancedStatusCard TotalIncomeCard;
        private CustomItems.AdvancedStatusCard PercentgeCard;
        private Panel panel1;
        private Label label13;
        private Panel panel4;
        private Label label19;
        private CustomItems.CustomPanel CourtsPanel;
        private FlowLayoutPanel CourtPanel;
        private CustomItems.CustomPanel customPanel1;
        private Panel panel2;
        private CustomItems.CustomChart customChart1;
        private Panel pnlLeftContainer;

        // Visual Studio Designer friendly structures
        private FlowLayoutPanel flowTasks;
        private FlowLayoutPanel flowStock;
        private FlowLayoutPanel flowLateContracts;
        
        private FlowLayoutPanel pnlQuickActions;
        private CustomItems.QuickActionCard cardBooking;
        private CustomItems.QuickActionCard cardContract;
        private CustomItems.QuickActionCard cardExpense;
        private CustomItems.QuickActionCard cardCourts;
        
        private FlowLayoutPanel pnlBottomColumns;
        
        private CustomItems.CustomPanel colTasks;
        private Panel headerTasks;
        private Label badgeTasks;
        private Label titleTasks;
        
        private CustomItems.CustomPanel colStock;
        private Panel headerStock;
        private Label badgeStock;
        private Label titleStock;
        
        private CustomItems.CustomPanel colLate;
        private Panel headerLate;
        private Label badgeLate;
        private Label titleLate;
        
        private Panel wrapperCourts;
        private CustomItems.CustomPanel pnlCourtsContainer;
        private Label lblCourtsTitle;
    }
}