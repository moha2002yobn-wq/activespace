namespace ActiveSpaceSystem.Forms.DialogForms
{
    partial class AddPurchaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            lblTitle = new Label();
            buttonClose = new Button();
            panelInvoiceInfo = new ActiveSpaceSystem.CustomItems.CustomPanel();
            lblInvoiceHeader = new Label();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            lblSupplier = new Label();
            txtSupplierName = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            lblPurchasesHeader = new Label();
            btnAddItem = new ActiveSpaceSystem.CustomItems.RoundedButton();
            flowItems = new FlowLayoutPanel();
            btCancel = new ActiveSpaceSystem.CustomItems.RoundedButton();
            btSave = new ActiveSpaceSystem.CustomItems.RoundedButton();
            panelInvoiceInfo.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Tajawal", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(29, 53, 87);
            lblTitle.Location = new Point(620, 31);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(281, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "إضافة مشتريات جديدة";
            // 
            // buttonClose
            // 
            buttonClose.Cursor = Cursors.Hand;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonClose.ForeColor = Color.DimGray;
            buttonClose.Location = new Point(27, 31);
            buttonClose.Margin = new Padding(4, 5, 4, 5);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(47, 54);
            buttonClose.TabIndex = 1;
            buttonClose.Text = "✕";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // panelInvoiceInfo
            // 
            panelInvoiceInfo.BackColor = Color.FromArgb(251, 251, 252);
            panelInvoiceInfo.BorderColor = Color.FromArgb(240, 242, 245);
            panelInvoiceInfo.BorderRadius = 15;
            panelInvoiceInfo.BorderSize = 1F;
            panelInvoiceInfo.Controls.Add(lblInvoiceHeader);
            panelInvoiceInfo.Controls.Add(lblDate);
            panelInvoiceInfo.Controls.Add(dtpDate);
            panelInvoiceInfo.Controls.Add(lblSupplier);
            panelInvoiceInfo.Controls.Add(txtSupplierName);
            panelInvoiceInfo.Location = new Point(40, 123);
            panelInvoiceInfo.Margin = new Padding(4, 5, 4, 5);
            panelInvoiceInfo.Name = "panelInvoiceInfo";
            panelInvoiceInfo.ShowShadow = false;
            panelInvoiceInfo.Size = new Size(870, 191);
            panelInvoiceInfo.TabIndex = 2;
            // 
            // lblInvoiceHeader
            // 
            lblInvoiceHeader.AutoSize = true;
            lblInvoiceHeader.Font = new Font("Tajawal", 12F, FontStyle.Bold);
            lblInvoiceHeader.ForeColor = Color.FromArgb(70, 80, 95);
            lblInvoiceHeader.Location = new Point(660, 18);
            lblInvoiceHeader.Margin = new Padding(4, 0, 4, 0);
            lblInvoiceHeader.Name = "lblInvoiceHeader";
            lblInvoiceHeader.Size = new Size(167, 29);
            lblInvoiceHeader.TabIndex = 0;
            lblInvoiceHeader.Text = "معلومات الفاتورة";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            lblDate.ForeColor = Color.FromArgb(100, 110, 125);
            lblDate.Location = new Point(760, 69);
            lblDate.Margin = new Padding(4, 0, 4, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(65, 24);
            lblDate.TabIndex = 1;
            lblDate.Text = "التاريخ *";
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Tajawal", 11F);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(450, 115);
            dtpDate.Margin = new Padding(4, 5, 4, 5);
            dtpDate.Name = "dtpDate";
            dtpDate.RightToLeft = RightToLeft.Yes;
            dtpDate.RightToLeftLayout = true;
            dtpDate.Size = new Size(380, 33);
            dtpDate.TabIndex = 2;
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            lblSupplier.ForeColor = Color.FromArgb(100, 110, 125);
            lblSupplier.Location = new Point(310, 69);
            lblSupplier.Margin = new Padding(4, 0, 4, 0);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(100, 24);
            lblSupplier.TabIndex = 3;
            lblSupplier.Text = "اسم المورد *";
            // 
            // txtSupplierName
            // 
            txtSupplierName.BackColor = Color.White;
            txtSupplierName.BorderColor = Color.FromArgb(209, 213, 219);
            txtSupplierName.BorderRadius = 10;
            txtSupplierName.Font = new Font("Tajawal", 11F);
            txtSupplierName.Icon = null;
            txtSupplierName.IconLocation = HorizontalAlignment.Left;
            txtSupplierName.IconSize = 20;
            txtSupplierName.Location = new Point(27, 108);
            txtSupplierName.Margin = new Padding(4, 5, 4, 5);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.passwordChar = "\0";
            txtSupplierName.PlaceholderText = "اسم المورد أو الشركة";
            txtSupplierName.RightToLeft = RightToLeft.Yes;
            txtSupplierName.Size = new Size(390, 47);
            txtSupplierName.TabIndex = 4;
            txtSupplierName.Texts = "";
            // 
            // lblPurchasesHeader
            // 
            lblPurchasesHeader.AutoSize = true;
            lblPurchasesHeader.Font = new Font("Tajawal", 13F, FontStyle.Bold);
            lblPurchasesHeader.ForeColor = Color.FromArgb(70, 80, 95);
            lblPurchasesHeader.Location = new Point(790, 362);
            lblPurchasesHeader.Margin = new Padding(4, 0, 4, 0);
            lblPurchasesHeader.Name = "lblPurchasesHeader";
            lblPurchasesHeader.Size = new Size(120, 32);
            lblPurchasesHeader.TabIndex = 3;
            lblPurchasesHeader.Text = "المشتريات";
            // 
            // btnAddItem
            // 
            btnAddItem.BackColor = Color.FromArgb(29, 53, 87);
            btnAddItem.BorderColor = Color.FromArgb(29, 53, 87);
            btnAddItem.BorderRadius = 10;
            btnAddItem.BorderSize = 0;
            btnAddItem.Cursor = Cursors.Hand;
            btnAddItem.FlatStyle = FlatStyle.Flat;
            btnAddItem.Font = new Font("Tajawal", 11F, FontStyle.Bold);
            btnAddItem.ForeColor = Color.White;
            btnAddItem.Location = new Point(40, 354);
            btnAddItem.Margin = new Padding(4, 5, 4, 5);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(187, 50);
            btnAddItem.TabIndex = 4;
            btnAddItem.Text = "+ إضافة صنف";
            btnAddItem.UseVisualStyleBackColor = false;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // flowItems
            // 
            flowItems.AutoScroll = true;
            flowItems.FlowDirection = FlowDirection.TopDown;
            flowItems.Location = new Point(40, 420);
            flowItems.Margin = new Padding(4, 5, 4, 5);
            flowItems.Name = "flowItems";
            flowItems.Size = new Size(870, 400);
            flowItems.TabIndex = 3;
            flowItems.WrapContents = false;
            // 
            // btCancel
            // 
            btCancel.BackColor = Color.White;
            btCancel.BorderColor = Color.FromArgb(209, 213, 219);
            btCancel.BorderRadius = 10;
            btCancel.BorderSize = 1;
            btCancel.Cursor = Cursors.Hand;
            btCancel.FlatStyle = FlatStyle.Flat;
            btCancel.Font = new Font("Tajawal", 13F, FontStyle.Bold);
            btCancel.ForeColor = Color.FromArgb(100, 110, 125);
            btCancel.Location = new Point(40, 840);
            btCancel.Margin = new Padding(4, 5, 4, 5);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(420, 55);
            btCancel.TabIndex = 5;
            btCancel.Text = "إلغاء";
            btCancel.UseVisualStyleBackColor = false;
            btCancel.Click += btCancel_Click;
            // 
            // btSave
            // 
            btSave.BackColor = Color.FromArgb(110, 220, 180);
            btSave.BorderColor = Color.FromArgb(110, 220, 180);
            btSave.BorderRadius = 10;
            btSave.BorderSize = 0;
            btSave.Cursor = Cursors.Hand;
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Tajawal", 13F, FontStyle.Bold);
            btSave.ForeColor = Color.White;
            btSave.Location = new Point(490, 840);
            btSave.Margin = new Padding(4, 5, 4, 5);
            btSave.Name = "btSave";
            btSave.Size = new Size(420, 55);
            btSave.TabIndex = 6;
            btSave.Text = "+ حفظ المشتريات";
            btSave.UseVisualStyleBackColor = false;
            btSave.Click += btSave_Click;
            // 
            // AddPurchaseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(950, 915);
            Controls.Add(lblTitle);
            Controls.Add(buttonClose);
            Controls.Add(panelInvoiceInfo);
            Controls.Add(lblPurchasesHeader);
            Controls.Add(btnAddItem);
            Controls.Add(flowItems);
            Controls.Add(btCancel);
            Controls.Add(btSave);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "AddPurchaseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إضافة مشتريات جديدة";
            Load += AddPurchaseForm_Load;
            Paint += AddPurchaseForm_Paint;
            panelInvoiceInfo.ResumeLayout(false);
            panelInvoiceInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button buttonClose;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelInvoiceInfo;
        private System.Windows.Forms.Label lblInvoiceHeader;
        private System.Windows.Forms.Label lblDate;
        public System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblSupplier;
        private ActiveSpaceSystem.CustomItems.AbdulTextBox txtSupplierName;

        private System.Windows.Forms.Label lblPurchasesHeader;
        private ActiveSpaceSystem.CustomItems.RoundedButton btnAddItem;
        public System.Windows.Forms.FlowLayoutPanel flowItems;

        private ActiveSpaceSystem.CustomItems.RoundedButton btCancel;
        private ActiveSpaceSystem.CustomItems.RoundedButton btSave;
    }
}
