namespace ActiveSpaceSystem.CustomItems
{
    partial class BookingItemControl
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

        private void InitializeComponent()
        {
            cardPanel = new CustomPanel();
            lblIndex = new Label();
            btnDeleteBooking = new RoundedButton();
            lblCourtTypeHeader = new Label();
            panelCourtType = new CustomPanel();
            cmbCourtType = new ComboBox();
            lblCourtHeader = new Label();
            panelCourt = new CustomPanel();
            cmbCourt = new ComboBox();
            lblDateHeader = new Label();
            panelBookingDate = new CustomPanel();
            dtpBookingDate = new DateTimePicker();
            lblStartHeader = new Label();
            panelStartTime = new CustomPanel();
            dtpStartTime = new DateTimePicker();
            lblEndHeader = new Label();
            panelEndTime = new CustomPanel();
            dtpEndTime = new DateTimePicker();
            lblBasePriceHeader = new Label();
            txtBasePrice = new AbdulTextBox();
            lblTotalHeader = new Label();
            panelTotalContainer = new CustomPanel();
            lblTotal = new Label();
            lblPropsHeader = new Label();
            btnAddProperty = new RoundedButton();
            panelPropertiesContainer = new CustomPanel();
            flowProperties = new FlowLayoutPanel();
            lblNoProperties = new Label();
            cardPanel.SuspendLayout();
            panelCourtType.SuspendLayout();
            panelCourt.SuspendLayout();
            panelBookingDate.SuspendLayout();
            panelStartTime.SuspendLayout();
            panelEndTime.SuspendLayout();
            panelTotalContainer.SuspendLayout();
            panelPropertiesContainer.SuspendLayout();
            flowProperties.SuspendLayout();
            SuspendLayout();
            // 
            // cardPanel
            // 
            cardPanel.BackColor = Color.FromArgb(245, 247, 250);
            cardPanel.BorderColor = Color.FromArgb(225, 230, 240);
            cardPanel.BorderRadius = 20;
            cardPanel.BorderSize = 1F;
            cardPanel.Controls.Add(lblIndex);
            cardPanel.Controls.Add(btnDeleteBooking);
            cardPanel.Controls.Add(lblCourtTypeHeader);
            cardPanel.Controls.Add(panelCourtType);
            cardPanel.Controls.Add(lblCourtHeader);
            cardPanel.Controls.Add(panelCourt);
            cardPanel.Controls.Add(lblDateHeader);
            cardPanel.Controls.Add(panelBookingDate);
            cardPanel.Controls.Add(lblStartHeader);
            cardPanel.Controls.Add(panelStartTime);
            cardPanel.Controls.Add(lblEndHeader);
            cardPanel.Controls.Add(panelEndTime);
            cardPanel.Controls.Add(lblBasePriceHeader);
            cardPanel.Controls.Add(txtBasePrice);
            cardPanel.Controls.Add(lblTotalHeader);
            cardPanel.Controls.Add(panelTotalContainer);
            cardPanel.Controls.Add(lblPropsHeader);
            cardPanel.Controls.Add(btnAddProperty);
            cardPanel.Controls.Add(panelPropertiesContainer);
            cardPanel.Location = new Point(5, 5);
            cardPanel.Name = "cardPanel";
            cardPanel.ShowShadow = false;
            cardPanel.Size = new Size(720, 415);
            cardPanel.TabIndex = 0;
            // 
            // lblIndex
            // 
            lblIndex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblIndex.BackColor = Color.Transparent;
            lblIndex.Font = new Font("Tajawal", 12.5F, FontStyle.Bold);
            lblIndex.ForeColor = Color.FromArgb(29, 53, 87);
            lblIndex.Location = new Point(530, 22);
            lblIndex.Name = "lblIndex";
            lblIndex.Size = new Size(170, 30);
            lblIndex.TabIndex = 0;
            lblIndex.Text = "حجز رقم 1";
            lblIndex.TextAlign = ContentAlignment.TopRight;
            // 
            // btnDeleteBooking
            // 
            btnDeleteBooking.BackColor = Color.FromArgb(254, 242, 242);
            btnDeleteBooking.BorderColor = Color.FromArgb(252, 165, 165);
            btnDeleteBooking.BorderRadius = 10;
            btnDeleteBooking.BorderSize = 1;
            btnDeleteBooking.Cursor = Cursors.Hand;
            btnDeleteBooking.FlatStyle = FlatStyle.Flat;
            btnDeleteBooking.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            btnDeleteBooking.ForeColor = Color.FromArgb(239, 68, 68);
            btnDeleteBooking.Location = new Point(20, 18);
            btnDeleteBooking.Name = "btnDeleteBooking";
            btnDeleteBooking.Size = new Size(120, 34);
            btnDeleteBooking.TabIndex = 1;
            btnDeleteBooking.Text = "حذف هذا الحجز";
            btnDeleteBooking.UseVisualStyleBackColor = false;
            // 
            // lblCourtTypeHeader
            // 
            lblCourtTypeHeader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCourtTypeHeader.BackColor = Color.Transparent;
            lblCourtTypeHeader.Font = new Font("Tajawal Medium", 10F, FontStyle.Bold);
            lblCourtTypeHeader.ForeColor = Color.FromArgb(100, 110, 125);
            lblCourtTypeHeader.Location = new Point(370, 62);
            lblCourtTypeHeader.Name = "lblCourtTypeHeader";
            lblCourtTypeHeader.RightToLeft = RightToLeft.No;
            lblCourtTypeHeader.Size = new Size(330, 25);
            lblCourtTypeHeader.TabIndex = 2;
            lblCourtTypeHeader.Text = "نوع الملعب";
            lblCourtTypeHeader.TextAlign = ContentAlignment.TopRight;
            // 
            // panelCourtType
            // 
            panelCourtType.BackColor = Color.White;
            panelCourtType.BorderColor = Color.FromArgb(215, 225, 240);
            panelCourtType.BorderRadius = 10;
            panelCourtType.BorderSize = 1F;
            panelCourtType.Controls.Add(cmbCourtType);
            panelCourtType.Location = new Point(370, 90);
            panelCourtType.Name = "panelCourtType";
            panelCourtType.ShowShadow = false;
            panelCourtType.Size = new Size(330, 42);
            panelCourtType.TabIndex = 2;
            // 
            // cmbCourtType
            // 
            cmbCourtType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourtType.FlatStyle = FlatStyle.Flat;
            cmbCourtType.Font = new Font("Tajawal", 10.5F);
            cmbCourtType.FormattingEnabled = true;
            cmbCourtType.Location = new Point(5, 5);
            cmbCourtType.Name = "cmbCourtType";
            cmbCourtType.Size = new Size(318, 31);
            cmbCourtType.TabIndex = 0;
            // 
            // lblCourtHeader
            // 
            lblCourtHeader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCourtHeader.BackColor = Color.Transparent;
            lblCourtHeader.Font = new Font("Tajawal Medium", 10F, FontStyle.Bold);
            lblCourtHeader.ForeColor = Color.FromArgb(100, 110, 125);
            lblCourtHeader.Location = new Point(20, 62);
            lblCourtHeader.Name = "lblCourtHeader";
            lblCourtHeader.RightToLeft = RightToLeft.No;
            lblCourtHeader.Size = new Size(330, 25);
            lblCourtHeader.TabIndex = 3;
            lblCourtHeader.Text = "الملعب";
            lblCourtHeader.TextAlign = ContentAlignment.TopRight;
            // 
            // panelCourt
            // 
            panelCourt.BackColor = Color.White;
            panelCourt.BorderColor = Color.FromArgb(215, 225, 240);
            panelCourt.BorderRadius = 10;
            panelCourt.BorderSize = 1F;
            panelCourt.Controls.Add(cmbCourt);
            panelCourt.Location = new Point(20, 90);
            panelCourt.Name = "panelCourt";
            panelCourt.ShowShadow = false;
            panelCourt.Size = new Size(330, 42);
            panelCourt.TabIndex = 3;
            // 
            // cmbCourt
            // 
            cmbCourt.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourt.FlatStyle = FlatStyle.Flat;
            cmbCourt.Font = new Font("Tajawal", 10.5F);
            cmbCourt.FormattingEnabled = true;
            cmbCourt.Location = new Point(5, 5);
            cmbCourt.Name = "cmbCourt";
            cmbCourt.Size = new Size(318, 31);
            cmbCourt.TabIndex = 0;
            // 
            // lblDateHeader
            // 
            lblDateHeader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDateHeader.BackColor = Color.Transparent;
            lblDateHeader.Font = new Font("Tajawal Medium", 10F, FontStyle.Bold);
            lblDateHeader.ForeColor = Color.FromArgb(100, 110, 125);
            lblDateHeader.Location = new Point(350, 147);
            lblDateHeader.Name = "lblDateHeader";
            lblDateHeader.RightToLeft = RightToLeft.No;
            lblDateHeader.Size = new Size(350, 25);
            lblDateHeader.TabIndex = 4;
            lblDateHeader.Text = "التاريخ";
            lblDateHeader.TextAlign = ContentAlignment.TopRight;
            // 
            // panelBookingDate
            // 
            panelBookingDate.BackColor = Color.White;
            panelBookingDate.BorderColor = Color.FromArgb(215, 225, 240);
            panelBookingDate.BorderRadius = 10;
            panelBookingDate.BorderSize = 1F;
            panelBookingDate.Controls.Add(dtpBookingDate);
            panelBookingDate.Location = new Point(350, 175);
            panelBookingDate.Name = "panelBookingDate";
            panelBookingDate.ShowShadow = false;
            panelBookingDate.Size = new Size(350, 42);
            panelBookingDate.TabIndex = 4;
            // 
            // dtpBookingDate
            // 
            dtpBookingDate.CalendarFont = new Font("Tajawal", 10.5F);
            dtpBookingDate.Font = new Font("Tajawal", 10.5F);
            dtpBookingDate.Format = DateTimePickerFormat.Short;
            dtpBookingDate.Location = new Point(5, 6);
            dtpBookingDate.Name = "dtpBookingDate";
            dtpBookingDate.Size = new Size(338, 32);
            dtpBookingDate.TabIndex = 0;
            // 
            // lblStartHeader
            // 
            lblStartHeader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStartHeader.BackColor = Color.Transparent;
            lblStartHeader.Font = new Font("Tajawal Medium", 10F, FontStyle.Bold);
            lblStartHeader.ForeColor = Color.FromArgb(100, 110, 125);
            lblStartHeader.Location = new Point(185, 147);
            lblStartHeader.Name = "lblStartHeader";
            lblStartHeader.RightToLeft = RightToLeft.No;
            lblStartHeader.Size = new Size(150, 25);
            lblStartHeader.TabIndex = 5;
            lblStartHeader.Text = "من";
            lblStartHeader.TextAlign = ContentAlignment.TopRight;
            // 
            // panelStartTime
            // 
            panelStartTime.BackColor = Color.White;
            panelStartTime.BorderColor = Color.FromArgb(215, 225, 240);
            panelStartTime.BorderRadius = 10;
            panelStartTime.BorderSize = 1F;
            panelStartTime.Controls.Add(dtpStartTime);
            panelStartTime.Location = new Point(185, 175);
            panelStartTime.Name = "panelStartTime";
            panelStartTime.ShowShadow = false;
            panelStartTime.Size = new Size(150, 42);
            panelStartTime.TabIndex = 5;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "HH:mm";
            dtpStartTime.Font = new Font("Segoe UI", 11F);
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(5, 6);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(138, 32);
            dtpStartTime.TabIndex = 0;
            // 
            // lblEndHeader
            // 
            lblEndHeader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblEndHeader.BackColor = Color.Transparent;
            lblEndHeader.Font = new Font("Tajawal Medium", 10F, FontStyle.Bold);
            lblEndHeader.ForeColor = Color.FromArgb(100, 110, 125);
            lblEndHeader.Location = new Point(20, 147);
            lblEndHeader.Name = "lblEndHeader";
            lblEndHeader.RightToLeft = RightToLeft.No;
            lblEndHeader.Size = new Size(150, 25);
            lblEndHeader.TabIndex = 6;
            lblEndHeader.Text = "إلى";
            lblEndHeader.TextAlign = ContentAlignment.TopRight;
            // 
            // panelEndTime
            // 
            panelEndTime.BackColor = Color.White;
            panelEndTime.BorderColor = Color.FromArgb(215, 225, 240);
            panelEndTime.BorderRadius = 10;
            panelEndTime.BorderSize = 1F;
            panelEndTime.Controls.Add(dtpEndTime);
            panelEndTime.Location = new Point(20, 175);
            panelEndTime.Name = "panelEndTime";
            panelEndTime.ShowShadow = false;
            panelEndTime.Size = new Size(150, 42);
            panelEndTime.TabIndex = 6;
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "HH:mm";
            dtpEndTime.Font = new Font("Segoe UI", 11F);
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(5, 6);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(138, 32);
            dtpEndTime.TabIndex = 0;
            // 
            // lblBasePriceHeader
            // 
            lblBasePriceHeader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBasePriceHeader.BackColor = Color.Transparent;
            lblBasePriceHeader.Font = new Font("Tajawal Medium", 10F, FontStyle.Bold);
            lblBasePriceHeader.ForeColor = Color.FromArgb(100, 110, 125);
            lblBasePriceHeader.Location = new Point(370, 227);
            lblBasePriceHeader.Name = "lblBasePriceHeader";
            lblBasePriceHeader.RightToLeft = RightToLeft.No;
            lblBasePriceHeader.Size = new Size(330, 25);
            lblBasePriceHeader.TabIndex = 7;
            lblBasePriceHeader.Text = "السعر الأساسي (د.ل)";
            lblBasePriceHeader.TextAlign = ContentAlignment.TopRight;
            // 
            // txtBasePrice
            // 
            txtBasePrice.BackColor = Color.White;
            txtBasePrice.BorderColor = Color.FromArgb(215, 225, 240);
            txtBasePrice.BorderRadius = 10;
            txtBasePrice.Font = new Font("Segoe UI", 11F);
            txtBasePrice.Icon = null;
            txtBasePrice.IconLocation = HorizontalAlignment.Left;
            txtBasePrice.IconSize = 20;
            txtBasePrice.Location = new Point(370, 255);
            txtBasePrice.Name = "txtBasePrice";
            txtBasePrice.passwordChar = "\0";
            txtBasePrice.PlaceholderText = "أدخل النص هنا...";
            txtBasePrice.Size = new Size(330, 42);
            txtBasePrice.TabIndex = 7;
            txtBasePrice.Texts = "0";
            // 
            // lblTotalHeader
            // 
            lblTotalHeader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalHeader.BackColor = Color.Transparent;
            lblTotalHeader.Font = new Font("Tajawal Medium", 10F, FontStyle.Bold);
            lblTotalHeader.ForeColor = Color.FromArgb(100, 110, 125);
            lblTotalHeader.Location = new Point(20, 227);
            lblTotalHeader.Name = "lblTotalHeader";
            lblTotalHeader.RightToLeft = RightToLeft.No;
            lblTotalHeader.Size = new Size(330, 25);
            lblTotalHeader.TabIndex = 8;
            lblTotalHeader.Text = "الإجمالي";
            lblTotalHeader.TextAlign = ContentAlignment.TopRight;
            // 
            // panelTotalContainer
            // 
            panelTotalContainer.BackColor = Color.FromArgb(240, 246, 255);
            panelTotalContainer.BorderColor = Color.FromArgb(215, 225, 240);
            panelTotalContainer.BorderRadius = 10;
            panelTotalContainer.BorderSize = 2F;
            panelTotalContainer.Controls.Add(lblTotal);
            panelTotalContainer.Location = new Point(20, 255);
            panelTotalContainer.Name = "panelTotalContainer";
            panelTotalContainer.ShowShadow = false;
            panelTotalContainer.Size = new Size(330, 42);
            panelTotalContainer.TabIndex = 8;
            // 
            // lblTotal
            // 
            lblTotal.BackColor = Color.Transparent;
            lblTotal.Dock = DockStyle.Fill;
            lblTotal.Font = new Font("Tajawal", 12F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(0, 150, 136);
            lblTotal.Location = new Point(0, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(330, 42);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "0 د.ل";
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPropsHeader
            // 
            lblPropsHeader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPropsHeader.BackColor = Color.Transparent;
            lblPropsHeader.Font = new Font("Tajawal", 11.5F, FontStyle.Bold);
            lblPropsHeader.ForeColor = Color.FromArgb(29, 53, 87);
            lblPropsHeader.Location = new Point(470, 312);
            lblPropsHeader.Name = "lblPropsHeader";
            lblPropsHeader.Size = new Size(230, 30);
            lblPropsHeader.TabIndex = 9;
            lblPropsHeader.Text = "خصائص من المخزون";
            lblPropsHeader.TextAlign = ContentAlignment.TopRight;
            // 
            // btnAddProperty
            // 
            btnAddProperty.BackColor = Color.FromArgb(29, 53, 87);
            btnAddProperty.BorderColor = Color.PaleVioletRed;
            btnAddProperty.BorderRadius = 10;
            btnAddProperty.BorderSize = 0;
            btnAddProperty.Cursor = Cursors.Hand;
            btnAddProperty.FlatStyle = FlatStyle.Flat;
            btnAddProperty.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            btnAddProperty.ForeColor = Color.White;
            btnAddProperty.Location = new Point(20, 310);
            btnAddProperty.Name = "btnAddProperty";
            btnAddProperty.Size = new Size(130, 34);
            btnAddProperty.TabIndex = 9;
            btnAddProperty.Text = "+ إضافة خاصية";
            btnAddProperty.UseVisualStyleBackColor = false;
            // 
            // panelPropertiesContainer
            // 
            panelPropertiesContainer.BackColor = Color.FromArgb(250, 251, 252);
            panelPropertiesContainer.BorderColor = Color.FromArgb(226, 232, 240);
            panelPropertiesContainer.BorderRadius = 12;
            panelPropertiesContainer.BorderSize = 1F;
            panelPropertiesContainer.Controls.Add(flowProperties);
            panelPropertiesContainer.Location = new Point(20, 350);
            panelPropertiesContainer.Name = "panelPropertiesContainer";
            panelPropertiesContainer.ShowShadow = false;
            panelPropertiesContainer.Size = new Size(680, 45);
            panelPropertiesContainer.TabIndex = 10;
            // 
            // flowProperties
            // 
            flowProperties.AutoScroll = true;
            flowProperties.BackColor = Color.Transparent;
            flowProperties.Controls.Add(lblNoProperties);
            flowProperties.Location = new Point(5, 5);
            flowProperties.Name = "flowProperties";
            flowProperties.Size = new Size(670, 35);
            flowProperties.TabIndex = 0;
            // 
            // lblNoProperties
            // 
            lblNoProperties.BackColor = Color.Transparent;
            lblNoProperties.Font = new Font("Tajawal", 9.5F);
            lblNoProperties.ForeColor = Color.Gray;
            lblNoProperties.Location = new Point(7, 0);
            lblNoProperties.Name = "lblNoProperties";
            lblNoProperties.Size = new Size(660, 25);
            lblNoProperties.TabIndex = 0;
            lblNoProperties.Text = "لا توجد خصائص إضافية. اضغط 'إضافة خاصية' لإضافة معدات من المخزون.";
            lblNoProperties.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BookingItemControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(cardPanel);
            Name = "BookingItemControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(730, 425);
            cardPanel.ResumeLayout(false);
            panelCourtType.ResumeLayout(false);
            panelCourt.ResumeLayout(false);
            panelBookingDate.ResumeLayout(false);
            panelStartTime.ResumeLayout(false);
            panelEndTime.ResumeLayout(false);
            panelTotalContainer.ResumeLayout(false);
            panelPropertiesContainer.ResumeLayout(false);
            flowProperties.ResumeLayout(false);
            ResumeLayout(false);
        }

        public System.Windows.Forms.Label lblIndex;
        public System.Windows.Forms.ComboBox cmbCourtType;
        public System.Windows.Forms.ComboBox cmbCourt;
        public System.Windows.Forms.DateTimePicker dtpBookingDate;
        public System.Windows.Forms.DateTimePicker dtpStartTime;
        public System.Windows.Forms.DateTimePicker dtpEndTime;
        public ActiveSpaceSystem.CustomItems.AbdulTextBox txtBasePrice;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.FlowLayoutPanel flowProperties;
        public System.Windows.Forms.Label lblNoProperties;
        public ActiveSpaceSystem.CustomItems.RoundedButton btnAddProperty;
        public ActiveSpaceSystem.CustomItems.RoundedButton btnDeleteBooking;
        
        private System.Windows.Forms.Label lblCourtTypeHeader;
        private System.Windows.Forms.Label lblCourtHeader;
        private System.Windows.Forms.Label lblDateHeader;
        private System.Windows.Forms.Label lblStartHeader;
        private System.Windows.Forms.Label lblEndHeader;
        private System.Windows.Forms.Label lblBasePriceHeader;
        private System.Windows.Forms.Label lblTotalHeader;
        private System.Windows.Forms.Label lblPropsHeader;

        private ActiveSpaceSystem.CustomItems.CustomPanel cardPanel;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelCourtType;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelCourt;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelTotalContainer;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelBookingDate;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelStartTime;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelEndTime;
        public ActiveSpaceSystem.CustomItems.CustomPanel panelPropertiesContainer;
    }
}
