using System.Drawing;
using System.Windows.Forms;

namespace ActiveSpaceSystem.CustomItems
{
    partial class PurchaseItemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            containerPanel = new CustomPanel();
            lblIndex = new Label();
            btnDelete = new Button();
            lblCategory = new Label();
            panelCategory = new CustomPanel();
            cmbCategory = new ComboBox();
            btnAddCategory = new RoundedButton();
            lblItemName = new Label();
            txtItemName = new AbdulTextBox();
            lblQuantity = new Label();
            txtQuantity = new AbdulTextBox();
            lblUnitPrice = new Label();
            txtUnitPrice = new AbdulTextBox();
            lblSellingPrice = new Label();
            txtSellingPrice = new AbdulTextBox();
            lblCourtType = new Label();
            panelCourtType = new CustomPanel();
            cmbCourtType = new ComboBox();
            lblCourt = new Label();
            panelCourt = new CustomPanel();
            cmbCourt = new ComboBox();
            lblUsageType = new Label();
            chkForSale = new CheckBox();
            chkForRental = new CheckBox();
            lblRentalRate = new Label();
            txtRentalRate = new AbdulTextBox();
            chkManualMinQty = new CheckBox();
            panelNote = new CustomPanel();
            lblNoteText = new Label();
            txtMinQuantity = new AbdulTextBox();
            containerPanel.SuspendLayout();
            panelCategory.SuspendLayout();
            panelCourtType.SuspendLayout();
            panelCourt.SuspendLayout();
            panelNote.SuspendLayout();
            SuspendLayout();
            // 
            // containerPanel
            // 
            containerPanel.BackColor = Color.FromArgb(251, 251, 252);
            containerPanel.BorderColor = Color.FromArgb(230, 233, 237);
            containerPanel.BorderRadius = 15;
            containerPanel.BorderSize = 1F;
            containerPanel.Controls.Add(lblIndex);
            containerPanel.Controls.Add(btnDelete);
            containerPanel.Controls.Add(lblCategory);
            containerPanel.Controls.Add(panelCategory);
            containerPanel.Controls.Add(btnAddCategory);
            containerPanel.Controls.Add(lblItemName);
            containerPanel.Controls.Add(txtItemName);
            containerPanel.Controls.Add(lblQuantity);
            containerPanel.Controls.Add(txtQuantity);
            containerPanel.Controls.Add(lblUnitPrice);
            containerPanel.Controls.Add(txtUnitPrice);
            containerPanel.Controls.Add(lblSellingPrice);
            containerPanel.Controls.Add(txtSellingPrice);
            containerPanel.Controls.Add(lblCourtType);
            containerPanel.Controls.Add(panelCourtType);
            containerPanel.Controls.Add(lblCourt);
            containerPanel.Controls.Add(panelCourt);
            containerPanel.Controls.Add(lblUsageType);
            containerPanel.Controls.Add(chkForSale);
            containerPanel.Controls.Add(chkForRental);
            containerPanel.Controls.Add(lblRentalRate);
            containerPanel.Controls.Add(txtRentalRate);
            containerPanel.Controls.Add(chkManualMinQty);
            containerPanel.Controls.Add(panelNote);
            containerPanel.Controls.Add(txtMinQuantity);
            containerPanel.Dock = DockStyle.Fill;
            containerPanel.Location = new Point(5, 5);
            containerPanel.Name = "containerPanel";
            containerPanel.Padding = new Padding(15);
            containerPanel.ShowShadow = false;
            containerPanel.Size = new Size(850, 510);
            containerPanel.TabIndex = 0;
            // 
            // lblIndex
            // 
            lblIndex.AutoSize = true;
            lblIndex.Font = new Font("Tajawal", 11.5F, FontStyle.Bold);
            lblIndex.ForeColor = Color.FromArgb(29, 53, 87);
            lblIndex.Location = new Point(750, 15);
            lblIndex.Name = "lblIndex";
            lblIndex.Size = new Size(87, 29);
            lblIndex.TabIndex = 0;
            lblIndex.Text = "الصنف 1";
            // 
            // btnDelete
            // 
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold);
            btnDelete.ForeColor = Color.FromArgb(239, 68, 68);
            btnDelete.Location = new Point(20, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(35, 35);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "🗑";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            lblCategory.ForeColor = Color.FromArgb(70, 80, 95);
            lblCategory.Location = new Point(770, 50);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(53, 24);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "الفئة *";
            // 
            // panelCategory
            // 
            panelCategory.BackColor = Color.White;
            panelCategory.BorderColor = Color.FromArgb(209, 213, 219);
            panelCategory.BorderRadius = 10;
            panelCategory.BorderSize = 1F;
            panelCategory.Controls.Add(cmbCategory);
            panelCategory.Location = new Point(500, 80);
            panelCategory.Name = "panelCategory";
            panelCategory.ShowShadow = false;
            panelCategory.Size = new Size(260, 48);
            panelCategory.TabIndex = 4;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FlatStyle = FlatStyle.Flat;
            cmbCategory.Font = new Font("Tajawal", 10.5F);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(10, 8);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.RightToLeft = RightToLeft.Yes;
            cmbCategory.Size = new Size(240, 31);
            cmbCategory.TabIndex = 0;
            // 
            // btnAddCategory
            // 
            btnAddCategory.BackColor = Color.FromArgb(29, 53, 87);
            btnAddCategory.BorderColor = Color.FromArgb(29, 53, 87);
            btnAddCategory.BorderRadius = 10;
            btnAddCategory.BorderSize = 0;
            btnAddCategory.Cursor = Cursors.Hand;
            btnAddCategory.FlatStyle = FlatStyle.Flat;
            btnAddCategory.Font = new Font("Tajawal", 12F, FontStyle.Bold);
            btnAddCategory.ForeColor = Color.White;
            btnAddCategory.Location = new Point(440, 80);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(48, 48);
            btnAddCategory.TabIndex = 3;
            btnAddCategory.Text = "+";
            btnAddCategory.UseVisualStyleBackColor = false;
            // 
            // lblItemName
            // 
            lblItemName.AutoSize = true;
            lblItemName.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            lblItemName.ForeColor = Color.FromArgb(70, 80, 95);
            lblItemName.Location = new Point(320, 50);
            lblItemName.Name = "lblItemName";
            lblItemName.Size = new Size(105, 24);
            lblItemName.TabIndex = 5;
            lblItemName.Text = "اسم الصنف *";
            // 
            // txtItemName
            // 
            txtItemName.BackColor = Color.White;
            txtItemName.BorderColor = Color.FromArgb(209, 213, 219);
            txtItemName.BorderRadius = 10;
            txtItemName.Icon = null;
            txtItemName.IconLocation = HorizontalAlignment.Left;
            txtItemName.IconSize = 20;
            txtItemName.Location = new Point(20, 80);
            txtItemName.Name = "txtItemName";
            txtItemName.passwordChar = "\0";
            txtItemName.PlaceholderText = "مثال: كرات قدم - حجم 5";
            txtItemName.RightToLeft = RightToLeft.Yes;
            txtItemName.Size = new Size(400, 48);
            txtItemName.TabIndex = 6;
            txtItemName.Texts = "";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            lblQuantity.ForeColor = Color.FromArgb(70, 80, 95);
            lblQuantity.Location = new Point(760, 140);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(64, 24);
            lblQuantity.TabIndex = 7;
            lblQuantity.Text = "الكمية *";
            // 
            // txtQuantity
            // 
            txtQuantity.BackColor = Color.White;
            txtQuantity.BorderColor = Color.FromArgb(209, 213, 219);
            txtQuantity.BorderRadius = 10;
            txtQuantity.Icon = null;
            txtQuantity.IconLocation = HorizontalAlignment.Left;
            txtQuantity.IconSize = 20;
            txtQuantity.Location = new Point(440, 170);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.passwordChar = "\0";
            txtQuantity.PlaceholderText = "0";
            txtQuantity.RightToLeft = RightToLeft.Yes;
            txtQuantity.Size = new Size(380, 48);
            txtQuantity.TabIndex = 8;
            txtQuantity.Texts = "";
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            lblUnitPrice.ForeColor = Color.FromArgb(70, 80, 95);
            lblUnitPrice.Location = new Point(280, 140);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(143, 24);
            lblUnitPrice.TabIndex = 9;
            lblUnitPrice.Text = "سعر الشراء (د.ل) *";
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.BackColor = Color.White;
            txtUnitPrice.BorderColor = Color.FromArgb(209, 213, 219);
            txtUnitPrice.BorderRadius = 10;
            txtUnitPrice.Icon = null;
            txtUnitPrice.IconLocation = HorizontalAlignment.Left;
            txtUnitPrice.IconSize = 20;
            txtUnitPrice.Location = new Point(20, 170);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.passwordChar = "\0";
            txtUnitPrice.PlaceholderText = "0.00";
            txtUnitPrice.RightToLeft = RightToLeft.Yes;
            txtUnitPrice.Size = new Size(400, 48);
            txtUnitPrice.TabIndex = 10;
            txtUnitPrice.Texts = "";
            // 
            // lblSellingPrice
            // 
            lblSellingPrice.AutoSize = true;
            lblSellingPrice.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            lblSellingPrice.ForeColor = Color.FromArgb(70, 80, 95);
            lblSellingPrice.Location = new Point(750, 230);
            lblSellingPrice.Name = "lblSellingPrice";
            lblSellingPrice.Size = new Size(129, 24);
            lblSellingPrice.TabIndex = 15;
            lblSellingPrice.Text = "سعر البيع (د.ل) *";
            // 
            // txtSellingPrice
            // 
            txtSellingPrice.BackColor = Color.White;
            txtSellingPrice.BorderColor = Color.FromArgb(209, 213, 219);
            txtSellingPrice.BorderRadius = 10;
            txtSellingPrice.Icon = null;
            txtSellingPrice.IconLocation = HorizontalAlignment.Left;
            txtSellingPrice.IconSize = 20;
            txtSellingPrice.Location = new Point(574, 260);
            txtSellingPrice.Name = "txtSellingPrice";
            txtSellingPrice.passwordChar = "\0";
            txtSellingPrice.PlaceholderText = "0.00";
            txtSellingPrice.RightToLeft = RightToLeft.Yes;
            txtSellingPrice.Size = new Size(256, 48);
            txtSellingPrice.TabIndex = 16;
            txtSellingPrice.Texts = "";
            // 
            // lblCourtType
            // 
            lblCourtType.AutoSize = true;
            lblCourtType.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            lblCourtType.ForeColor = Color.FromArgb(70, 80, 95);
            lblCourtType.Location = new Point(730, 320);
            lblCourtType.Name = "lblCourtType";
            lblCourtType.Size = new Size(100, 24);
            lblCourtType.TabIndex = 11;
            lblCourtType.Text = "نوع الملعب *";
            // 
            // panelCourtType
            // 
            panelCourtType.BackColor = Color.White;
            panelCourtType.BorderColor = Color.FromArgb(209, 213, 219);
            panelCourtType.BorderRadius = 10;
            panelCourtType.BorderSize = 1F;
            panelCourtType.Controls.Add(cmbCourtType);
            panelCourtType.Location = new Point(440, 350);
            panelCourtType.Name = "panelCourtType";
            panelCourtType.ShowShadow = false;
            panelCourtType.Size = new Size(380, 48);
            panelCourtType.TabIndex = 12;
            // 
            // cmbCourtType
            // 
            cmbCourtType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourtType.FlatStyle = FlatStyle.Flat;
            cmbCourtType.Font = new Font("Tajawal", 10.5F);
            cmbCourtType.FormattingEnabled = true;
            cmbCourtType.Location = new Point(10, 8);
            cmbCourtType.Name = "cmbCourtType";
            cmbCourtType.RightToLeft = RightToLeft.Yes;
            cmbCourtType.Size = new Size(360, 31);
            cmbCourtType.TabIndex = 0;
            // 
            // lblCourt
            // 
            lblCourt.AutoSize = true;
            lblCourt.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            lblCourt.ForeColor = Color.FromArgb(70, 80, 95);
            lblCourt.Location = new Point(320, 320);
            lblCourt.Name = "lblCourt";
            lblCourt.Size = new Size(109, 24);
            lblCourt.TabIndex = 13;
            lblCourt.Text = "اسم الملعب *";
            // 
            // panelCourt
            // 
            panelCourt.BackColor = Color.White;
            panelCourt.BorderColor = Color.FromArgb(209, 213, 219);
            panelCourt.BorderRadius = 10;
            panelCourt.BorderSize = 1F;
            panelCourt.Controls.Add(cmbCourt);
            panelCourt.Location = new Point(20, 350);
            panelCourt.Name = "panelCourt";
            panelCourt.ShowShadow = false;
            panelCourt.Size = new Size(400, 48);
            panelCourt.TabIndex = 14;
            // 
            // cmbCourt
            // 
            cmbCourt.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourt.FlatStyle = FlatStyle.Flat;
            cmbCourt.Font = new Font("Tajawal", 10.5F);
            cmbCourt.FormattingEnabled = true;
            cmbCourt.Location = new Point(10, 8);
            cmbCourt.Name = "cmbCourt";
            cmbCourt.RightToLeft = RightToLeft.Yes;
            cmbCourt.Size = new Size(380, 31);
            cmbCourt.TabIndex = 0;
            // 
            // lblUsageType
            // 
            lblUsageType.AutoSize = true;
            lblUsageType.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            lblUsageType.ForeColor = Color.FromArgb(70, 80, 95);
            lblUsageType.Location = new Point(720, 140);
            lblUsageType.Name = "lblUsageType";
            lblUsageType.Size = new Size(121, 24);
            lblUsageType.TabIndex = 17;
            lblUsageType.Text = "نوع الاستخدام *";
            // 
            // chkForSale
            // 
            chkForSale.AutoSize = true;
            chkForSale.Checked = true;
            chkForSale.CheckState = CheckState.Checked;
            chkForSale.Cursor = Cursors.Hand;
            chkForSale.Font = new Font("Tajawal", 10F, FontStyle.Bold);
            chkForSale.ForeColor = Color.FromArgb(29, 53, 87);
            chkForSale.Location = new Point(740, 172);
            chkForSale.Name = "chkForSale";
            chkForSale.RightToLeft = RightToLeft.Yes;
            chkForSale.Size = new Size(72, 29);
            chkForSale.TabIndex = 20;
            chkForSale.Text = "للبيع";
            chkForSale.UseVisualStyleBackColor = true;
            // 
            // chkForRental
            // 
            chkForRental.AutoSize = true;
            chkForRental.Cursor = Cursors.Hand;
            chkForRental.Font = new Font("Tajawal", 10F, FontStyle.Bold);
            chkForRental.ForeColor = Color.FromArgb(29, 53, 87);
            chkForRental.Location = new Point(630, 172);
            chkForRental.Name = "chkForRental";
            chkForRental.RightToLeft = RightToLeft.Yes;
            chkForRental.Size = new Size(83, 29);
            chkForRental.TabIndex = 21;
            chkForRental.Text = "للتأجير";
            chkForRental.UseVisualStyleBackColor = true;
            // 
            // lblRentalRate
            // 
            lblRentalRate.AutoSize = true;
            lblRentalRate.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            lblRentalRate.ForeColor = Color.FromArgb(70, 80, 95);
            lblRentalRate.Location = new Point(430, 230);
            lblRentalRate.Name = "lblRentalRate";
            lblRentalRate.Size = new Size(139, 24);
            lblRentalRate.TabIndex = 22;
            lblRentalRate.Text = "سعر التأجير (د.ل) *";
            // 
            // txtRentalRate
            // 
            txtRentalRate.BackColor = Color.White;
            txtRentalRate.BorderColor = Color.FromArgb(209, 213, 219);
            txtRentalRate.BorderRadius = 10;
            txtRentalRate.Icon = null;
            txtRentalRate.IconLocation = HorizontalAlignment.Left;
            txtRentalRate.IconSize = 20;
            txtRentalRate.Location = new Point(298, 260);
            txtRentalRate.Name = "txtRentalRate";
            txtRentalRate.passwordChar = "\0";
            txtRentalRate.PlaceholderText = "0.00";
            txtRentalRate.RightToLeft = RightToLeft.Yes;
            txtRentalRate.Size = new Size(256, 48);
            txtRentalRate.TabIndex = 23;
            txtRentalRate.Texts = "";
            // 
            // chkManualMinQty
            // 
            chkManualMinQty.AutoSize = true;
            chkManualMinQty.Cursor = Cursors.Hand;
            chkManualMinQty.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            chkManualMinQty.ForeColor = Color.FromArgb(70, 80, 95);
            chkManualMinQty.Location = new Point(130, 230);
            chkManualMinQty.Name = "chkManualMinQty";
            chkManualMinQty.RightToLeft = RightToLeft.Yes;
            chkManualMinQty.Size = new Size(191, 28);
            chkManualMinQty.TabIndex = 24;
            chkManualMinQty.Text = "تحديد الحد الأدنى يدوياً";
            chkManualMinQty.UseVisualStyleBackColor = true;
            // 
            // panelNote
            // 
            panelNote.BackColor = Color.FromArgb(240, 247, 255);
            panelNote.BorderColor = Color.FromArgb(200, 223, 255);
            panelNote.BorderRadius = 10;
            panelNote.BorderSize = 1F;
            panelNote.Controls.Add(lblNoteText);
            panelNote.Location = new Point(20, 415);
            panelNote.Name = "panelNote";
            panelNote.Padding = new Padding(10);
            panelNote.ShowShadow = false;
            panelNote.Size = new Size(810, 80);
            panelNote.TabIndex = 20;
            // 
            // lblNoteText
            // 
            lblNoteText.Dock = DockStyle.Fill;
            lblNoteText.Font = new Font("Tajawal Medium", 7.79999971F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNoteText.ForeColor = Color.FromArgb(29, 53, 87);
            lblNoteText.Location = new Point(10, 10);
            lblNoteText.Name = "lblNoteText";
            lblNoteText.RightToLeft = RightToLeft.No;
            lblNoteText.Size = new Size(790, 60);
            lblNoteText.TabIndex = 0;
            lblNoteText.Text = "ملاحظة: في حال عدم تفعيل خيار تحديد الحد الأدنى يدوياً، سيتم وضع القيمة الافتراضية (5) للمنتجات الجديدة، أو الإبقاء على قيمتها السابقة إذا كان المنتج موجوداً مسبقاً\r\n";
            lblNoteText.TextAlign = ContentAlignment.MiddleRight;
            lblNoteText.UseCompatibleTextRendering = true;
            // 
            // txtMinQuantity
            // 
            txtMinQuantity.BackColor = Color.White;
            txtMinQuantity.BorderColor = Color.FromArgb(209, 213, 219);
            txtMinQuantity.BorderRadius = 10;
            txtMinQuantity.Icon = null;
            txtMinQuantity.IconLocation = HorizontalAlignment.Left;
            txtMinQuantity.IconSize = 20;
            txtMinQuantity.Location = new Point(20, 260);
            txtMinQuantity.Name = "txtMinQuantity";
            txtMinQuantity.passwordChar = "\0";
            txtMinQuantity.PlaceholderText = "5";
            txtMinQuantity.RightToLeft = RightToLeft.Yes;
            txtMinQuantity.Size = new Size(256, 48);
            txtMinQuantity.TabIndex = 25;
            txtMinQuantity.Texts = "";
            // 
            // PurchaseItemControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(containerPanel);
            Name = "PurchaseItemControl";
            Padding = new Padding(5);
            Size = new Size(860, 520);
            containerPanel.ResumeLayout(false);
            containerPanel.PerformLayout();
            panelCategory.ResumeLayout(false);
            panelCourtType.ResumeLayout(false);
            panelCourt.ResumeLayout(false);
            panelNote.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private ActiveSpaceSystem.CustomItems.CustomPanel containerPanel;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblCategory;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelCategory;
        public System.Windows.Forms.ComboBox cmbCategory;
        private ActiveSpaceSystem.CustomItems.RoundedButton btnAddCategory;
        private System.Windows.Forms.Label lblItemName;
        public ActiveSpaceSystem.CustomItems.AbdulTextBox txtItemName;
        private System.Windows.Forms.Label lblQuantity;
        public ActiveSpaceSystem.CustomItems.AbdulTextBox txtQuantity;
        private System.Windows.Forms.Label lblUnitPrice;
        public ActiveSpaceSystem.CustomItems.AbdulTextBox txtUnitPrice;
        private System.Windows.Forms.Label lblSellingPrice;
        public ActiveSpaceSystem.CustomItems.AbdulTextBox txtSellingPrice;
        private System.Windows.Forms.Label lblCourtType;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelCourtType;
        public System.Windows.Forms.ComboBox cmbCourtType;
        private System.Windows.Forms.Label lblCourt;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelCourt;
        public System.Windows.Forms.ComboBox cmbCourt;
        
        // New Controls for Usage Type and Rental Rate
        private System.Windows.Forms.Label lblUsageType;
        public System.Windows.Forms.CheckBox chkForSale;
        public System.Windows.Forms.CheckBox chkForRental;
        private System.Windows.Forms.Label lblRentalRate;
        public ActiveSpaceSystem.CustomItems.AbdulTextBox txtRentalRate;
        public System.Windows.Forms.CheckBox chkManualMinQty;
        public ActiveSpaceSystem.CustomItems.AbdulTextBox txtMinQuantity;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelNote;
        private System.Windows.Forms.Label lblNoteText;
    }
}
