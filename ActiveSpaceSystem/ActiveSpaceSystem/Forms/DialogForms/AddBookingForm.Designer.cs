namespace ActiveSpaceSystem.Forms.DialogForms
{
    partial class AddBookingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">bool disposing</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBookingForm));
            this.mainFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTopHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            
            this.panelCustomerInfo = new System.Windows.Forms.Panel();
            this.lblCustomerInfoHeader = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtName = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new ActiveSpaceSystem.CustomItems.AbdulTextBox();

            this.panelHeaderRow = new System.Windows.Forms.Panel();
            this.lblBookingsHeader = new System.Windows.Forms.Label();
            this.btnAddBookingCard = new ActiveSpaceSystem.CustomItems.RoundedButton();

            this.flowBookings = new System.Windows.Forms.FlowLayoutPanel();

            this.panelBottomSection = new System.Windows.Forms.Panel();
            this.lblTotalAll = new System.Windows.Forms.Label();
            this.txtTotalAll = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.deposittxt = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            this.roundedButton1 = new ActiveSpaceSystem.CustomItems.RoundedButton();
            this.btnCancel = new ActiveSpaceSystem.CustomItems.RoundedButton();

            this.mainFlow.SuspendLayout();
            this.panelTopHeader.SuspendLayout();
            this.panelCustomerInfo.SuspendLayout();
            this.panelHeaderRow.SuspendLayout();
            this.panelBottomSection.SuspendLayout();
            this.SuspendLayout();

            // 
            // mainFlow
            // 
            this.mainFlow.AutoScroll = true;
            this.mainFlow.BackColor = System.Drawing.Color.White;
            this.mainFlow.Controls.Add(this.panelTopHeader);
            this.mainFlow.Controls.Add(this.panelCustomerInfo);
            this.mainFlow.Controls.Add(this.panelHeaderRow);
            this.mainFlow.Controls.Add(this.flowBookings);
            this.mainFlow.Controls.Add(this.panelBottomSection);
            this.mainFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainFlow.Location = new System.Drawing.Point(0, 0);
            this.mainFlow.Name = "mainFlow";
            this.mainFlow.Padding = new System.Windows.Forms.Padding(20, 10, 20, 20);
            this.mainFlow.Size = new System.Drawing.Size(800, 780);
            this.mainFlow.TabIndex = 0;
            this.mainFlow.WrapContents = false;

            // 
            // panelTopHeader
            // 
            this.panelTopHeader.Controls.Add(this.lblTitle);
            this.panelTopHeader.Controls.Add(this.btnExit);
            this.panelTopHeader.Location = new System.Drawing.Point(23, 13);
            this.panelTopHeader.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.panelTopHeader.Name = "panelTopHeader";
            this.panelTopHeader.Size = new System.Drawing.Size(740, 50);
            this.panelTopHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Tajawal", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(29, 53, 87);
            this.lblTitle.Location = new System.Drawing.Point(400, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(330, 35);
            this.lblTitle.Text = "إضافة حجز جديد";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.btnExit.Location = new System.Drawing.Point(10, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(35, 35);
            this.btnExit.Text = "✕";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // 
            // panelCustomerInfo
            // 
            this.panelCustomerInfo.BackColor = System.Drawing.Color.FromArgb(240, 246, 255);
            this.panelCustomerInfo.Controls.Add(this.lblCustomerInfoHeader);
            this.panelCustomerInfo.Controls.Add(this.lblCustomerName);
            this.panelCustomerInfo.Controls.Add(this.txtName);
            this.panelCustomerInfo.Controls.Add(this.lblPhone);
            this.panelCustomerInfo.Controls.Add(this.txtPhone);
            this.panelCustomerInfo.Location = new System.Drawing.Point(23, 76);
            this.panelCustomerInfo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.panelCustomerInfo.Name = "panelCustomerInfo";
            this.panelCustomerInfo.Size = new System.Drawing.Size(740, 130);
            this.panelCustomerInfo.TabIndex = 1;
            this.panelCustomerInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCustomerInfo_Paint);

            // 
            // lblCustomerInfoHeader
            // 
            this.lblCustomerInfoHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomerInfoHeader.Font = new System.Drawing.Font("Tajawal", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblCustomerInfoHeader.ForeColor = System.Drawing.Color.FromArgb(29, 53, 87);
            this.lblCustomerInfoHeader.Location = new System.Drawing.Point(580, 10);
            this.lblCustomerInfoHeader.Name = "lblCustomerInfoHeader";
            this.lblCustomerInfoHeader.Size = new System.Drawing.Size(140, 25);
            this.lblCustomerInfoHeader.Text = "بيانات العميل";
            this.lblCustomerInfoHeader.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomerName.Font = new System.Drawing.Font("Tajawal Medium", 10F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(100, 110, 125);
            this.lblCustomerName.Location = new System.Drawing.Point(200, 42);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(150, 25);
            this.lblCustomerName.Text = "اسم العميل";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(215, 225, 240);
            this.txtName.BorderRadius = 10;
            this.txtName.Font = new System.Drawing.Font("Tajawal", 11F);
            this.txtName.Location = new System.Drawing.Point(20, 70);
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.Size = new System.Drawing.Size(330, 42);
            this.txtName.TabIndex = 2;
            this.txtName.Texts = "";

            // 
            // lblPhone
            // 
            this.lblPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhone.Font = new System.Drawing.Font("Tajawal Medium", 10F, System.Drawing.FontStyle.Bold);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(100, 110, 125);
            this.lblPhone.Location = new System.Drawing.Point(570, 42);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(150, 25);
            this.lblPhone.Text = "رقم الهاتف";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.BorderColor = System.Drawing.Color.FromArgb(215, 225, 240);
            this.txtPhone.BorderRadius = 10;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPhone.Location = new System.Drawing.Point(390, 70);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPhone.Size = new System.Drawing.Size(330, 42);
            this.txtPhone.TabIndex = 1;
            this.txtPhone.Texts = "";
            this.txtPhone.KeyPress += this.txtPhone_KeyPress;
            this.txtPhone.Leave += this.txtPhone_Leave;

            // 
            // panelHeaderRow
            // 
            this.panelHeaderRow.Controls.Add(this.lblBookingsHeader);
            this.panelHeaderRow.Controls.Add(this.btnAddBookingCard);
            this.panelHeaderRow.Location = new System.Drawing.Point(23, 224);
            this.panelHeaderRow.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.panelHeaderRow.Name = "panelHeaderRow";
            this.panelHeaderRow.Size = new System.Drawing.Size(740, 55);
            this.panelHeaderRow.TabIndex = 2;

            // 
            // lblBookingsHeader
            // 
            this.lblBookingsHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBookingsHeader.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Bold);
            this.lblBookingsHeader.ForeColor = System.Drawing.Color.FromArgb(29, 53, 87);
            this.lblBookingsHeader.Location = new System.Drawing.Point(540, 15);
            this.lblBookingsHeader.Name = "lblBookingsHeader";
            this.lblBookingsHeader.Size = new System.Drawing.Size(180, 30);
            this.lblBookingsHeader.Text = "الحجوزات (1)";
            this.lblBookingsHeader.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // 
            // btnAddBookingCard
            // 
            this.btnAddBookingCard.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnAddBookingCard.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAddBookingCard.BorderRadius = 10;
            this.btnAddBookingCard.BorderSize = 0;
            this.btnAddBookingCard.FlatAppearance.BorderSize = 0;
            this.btnAddBookingCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBookingCard.Font = new System.Drawing.Font("Tajawal", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnAddBookingCard.ForeColor = System.Drawing.Color.White;
            this.btnAddBookingCard.Location = new System.Drawing.Point(20, 7);
            this.btnAddBookingCard.Name = "btnAddBookingCard";
            this.btnAddBookingCard.Size = new System.Drawing.Size(180, 40);
            this.btnAddBookingCard.TabIndex = 3;
            this.btnAddBookingCard.Text = "+ إضافة حجز آخر";
            this.btnAddBookingCard.UseVisualStyleBackColor = false;
            this.btnAddBookingCard.Click += new System.EventHandler(this.BtnAddBookingCard_Click);

            // 
            // flowBookings
            // 
            this.flowBookings.AutoSize = true;
            this.flowBookings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowBookings.BackColor = System.Drawing.Color.White;
            this.flowBookings.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flowBookings.Location = new System.Drawing.Point(23, 292);
            this.flowBookings.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.flowBookings.Name = "flowBookings";
            this.flowBookings.Size = new System.Drawing.Size(740, 0);
            this.flowBookings.TabIndex = 3;
            this.flowBookings.WrapContents = true;

            // 
            // panelBottomSection
            // 
            this.panelBottomSection.Controls.Add(this.lblTotalAll);
            this.panelBottomSection.Controls.Add(this.txtTotalAll);
            this.panelBottomSection.Controls.Add(this.lblDeposit);
            this.panelBottomSection.Controls.Add(this.deposittxt);
            this.panelBottomSection.Controls.Add(this.roundedButton1);
            this.panelBottomSection.Controls.Add(this.btnCancel);
            this.panelBottomSection.Location = new System.Drawing.Point(23, 310);
            this.panelBottomSection.Name = "panelBottomSection";
            this.panelBottomSection.Size = new System.Drawing.Size(740, 180);
            this.panelBottomSection.TabIndex = 4;

            // 
            // lblTotalAll
            // 
            this.lblTotalAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAll.Font = new System.Drawing.Font("Tajawal Medium", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalAll.ForeColor = System.Drawing.Color.FromArgb(100, 110, 125);
            this.lblTotalAll.Location = new System.Drawing.Point(390, 10);
            this.lblTotalAll.Name = "lblTotalAll";
            this.lblTotalAll.Size = new System.Drawing.Size(330, 25);
            this.lblTotalAll.Text = "إجمالي المبلغ";
            this.lblTotalAll.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // 
            // txtTotalAll
            // 
            this.txtTotalAll.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            this.txtTotalAll.BorderColor = System.Drawing.Color.FromArgb(29, 53, 87);
            this.txtTotalAll.BorderRadius = 10;
            this.txtTotalAll.Enabled = false;
            this.txtTotalAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtTotalAll.Location = new System.Drawing.Point(390, 38);
            this.txtTotalAll.Name = "txtTotalAll";
            this.txtTotalAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalAll.Size = new System.Drawing.Size(330, 45);
            this.txtTotalAll.TabIndex = 5;
            this.txtTotalAll.Texts = "0";

            // 
            // lblDeposit
            // 
            this.lblDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeposit.Font = new System.Drawing.Font("Tajawal Medium", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDeposit.ForeColor = System.Drawing.Color.FromArgb(100, 110, 125);
            this.lblDeposit.Location = new System.Drawing.Point(20, 10);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(330, 25);
            this.lblDeposit.Text = "العربون المدفوع (د.ل)";
            this.lblDeposit.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // 
            // deposittxt
            // 
            this.deposittxt.BackColor = System.Drawing.Color.White;
            this.deposittxt.BorderColor = System.Drawing.Color.FromArgb(29, 53, 87);
            this.deposittxt.BorderRadius = 10;
            this.deposittxt.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.deposittxt.Location = new System.Drawing.Point(20, 38);
            this.deposittxt.Name = "deposittxt";
            this.deposittxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.deposittxt.Size = new System.Drawing.Size(330, 45);
            this.deposittxt.TabIndex = 4;
            this.deposittxt.Texts = "0";

            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.roundedButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundedButton1.BorderRadius = 10;
            this.roundedButton1.BorderSize = 0;
            this.roundedButton1.FlatAppearance.BorderSize = 0;
            this.roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton1.Font = new System.Drawing.Font("Tajawal", 13.5F, System.Drawing.FontStyle.Bold);
            this.roundedButton1.ForeColor = System.Drawing.Color.White;
            this.roundedButton1.Location = new System.Drawing.Point(390, 105);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(330, 50);
            this.roundedButton1.TabIndex = 6;
            this.roundedButton1.Text = "حفظ جميع الحجوزات";
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Click += new System.EventHandler(this.roundedButton1_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.BorderSize = 0;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tajawal", 13.5F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnCancel.Location = new System.Drawing.Point(20, 105);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(330, 50);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // AddBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 780);
            this.Controls.Add(this.mainFlow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddBookingForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddBookingForm";
            this.Load += new System.EventHandler(this.AddBookingForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AddBookingForm_Paint);
            this.mainFlow.ResumeLayout(false);
            this.mainFlow.PerformLayout();
            this.panelTopHeader.ResumeLayout(false);
            this.panelCustomerInfo.ResumeLayout(false);
            this.panelHeaderRow.ResumeLayout(false);
            this.panelBottomSection.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel mainFlow;
        private System.Windows.Forms.Panel panelTopHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnExit;
        
        private System.Windows.Forms.Panel panelCustomerInfo;
        private System.Windows.Forms.Label lblCustomerInfoHeader;
        private System.Windows.Forms.Label lblCustomerName;
        private CustomItems.AbdulTextBox txtName;
        private System.Windows.Forms.Label lblPhone;
        private CustomItems.AbdulTextBox txtPhone;

        private System.Windows.Forms.Panel panelHeaderRow;
        private System.Windows.Forms.Label lblBookingsHeader;
        private CustomItems.RoundedButton btnAddBookingCard;

        public System.Windows.Forms.FlowLayoutPanel flowBookings;

        private System.Windows.Forms.Panel panelBottomSection;
        private System.Windows.Forms.Label lblTotalAll;
        private CustomItems.AbdulTextBox txtTotalAll;
        private System.Windows.Forms.Label lblDeposit;
        private CustomItems.AbdulTextBox deposittxt;
        private CustomItems.RoundedButton roundedButton1;
        private CustomItems.RoundedButton btnCancel;
    }
}