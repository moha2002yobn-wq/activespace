namespace ActiveSpaceSystem.CustomItems
{
    partial class DamagedItemControl
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
            lblName = new System.Windows.Forms.Label();
            lblCategory = new System.Windows.Forms.Label();
            lblQtyTitle = new System.Windows.Forms.Label();
            lblQtyValue = new System.Windows.Forms.Label();
            lblLossTitle = new System.Windows.Forms.Label();
            lblLossValue = new System.Windows.Forms.Label();
            btnReport = new RoundedButton();
            btnRemove = new RoundedButton();
            cardPanel.SuspendLayout();
            SuspendLayout();
            // 
            // cardPanel
            // 
            cardPanel.BackColor = System.Drawing.Color.FromArgb(254, 242, 242);
            cardPanel.BorderColor = System.Drawing.Color.FromArgb(254, 226, 226);
            cardPanel.BorderRadius = 16;
            cardPanel.BorderSize = 1.2F;
            cardPanel.Controls.Add(lblName);
            cardPanel.Controls.Add(lblCategory);
            cardPanel.Controls.Add(lblQtyTitle);
            cardPanel.Controls.Add(lblQtyValue);
            cardPanel.Controls.Add(lblLossTitle);
            cardPanel.Controls.Add(lblLossValue);
            cardPanel.Controls.Add(btnReport);
            cardPanel.Controls.Add(btnRemove);
            cardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            cardPanel.Location = new System.Drawing.Point(0, 0);
            cardPanel.Name = "cardPanel";
            cardPanel.ShowShadow = false;
            cardPanel.Size = new System.Drawing.Size(800, 110);
            cardPanel.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblName.BackColor = System.Drawing.Color.Transparent;
            lblName.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Bold);
            lblName.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblName.Location = new System.Drawing.Point(530, 20);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(246, 28);
            lblName.TabIndex = 0;
            lblName.Text = "اسم الصنف التالف";
            lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCategory
            // 
            lblCategory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblCategory.BackColor = System.Drawing.Color.Transparent;
            lblCategory.Font = new System.Drawing.Font("Tajawal", 9.5F);
            lblCategory.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblCategory.Location = new System.Drawing.Point(530, 52);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new System.Drawing.Size(246, 24);
            lblCategory.TabIndex = 1;
            lblCategory.Text = "الفئة";
            lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblQtyTitle
            // 
            lblQtyTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblQtyTitle.BackColor = System.Drawing.Color.Transparent;
            lblQtyTitle.Font = new System.Drawing.Font("Tajawal", 9F);
            lblQtyTitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            lblQtyTitle.Location = new System.Drawing.Point(400, 22);
            lblQtyTitle.Name = "lblQtyTitle";
            lblQtyTitle.Size = new System.Drawing.Size(100, 22);
            lblQtyTitle.TabIndex = 2;
            lblQtyTitle.Text = "الكمية التالفة";
            lblQtyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQtyValue
            // 
            lblQtyValue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblQtyValue.BackColor = System.Drawing.Color.Transparent;
            lblQtyValue.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Bold);
            lblQtyValue.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            lblQtyValue.Location = new System.Drawing.Point(400, 50);
            lblQtyValue.Name = "lblQtyValue";
            lblQtyValue.Size = new System.Drawing.Size(100, 28);
            lblQtyValue.TabIndex = 3;
            lblQtyValue.Text = "0";
            lblQtyValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLossTitle
            // 
            lblLossTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblLossTitle.BackColor = System.Drawing.Color.Transparent;
            lblLossTitle.Font = new System.Drawing.Font("Tajawal", 9F);
            lblLossTitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            lblLossTitle.Location = new System.Drawing.Point(260, 22);
            lblLossTitle.Name = "lblLossTitle";
            lblLossTitle.Size = new System.Drawing.Size(120, 22);
            lblLossTitle.TabIndex = 4;
            lblLossTitle.Text = "الخسارة المالية";
            lblLossTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLossValue
            // 
            lblLossValue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblLossValue.BackColor = System.Drawing.Color.Transparent;
            lblLossValue.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Bold);
            lblLossValue.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            lblLossValue.Location = new System.Drawing.Point(260, 50);
            lblLossValue.Name = "lblLossValue";
            lblLossValue.Size = new System.Drawing.Size(120, 28);
            lblLossValue.TabIndex = 5;
            lblLossValue.Text = "0 د.ل";
            lblLossValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReport
            // 
            btnReport.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            btnReport.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnReport.BorderRadius = 10;
            btnReport.BorderSize = 0;
            btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnReport.Font = new System.Drawing.Font("Tajawal", 9.5F, System.Drawing.FontStyle.Bold);
            btnReport.ForeColor = System.Drawing.Color.White;
            btnReport.Location = new System.Drawing.Point(115, 37);
            btnReport.Name = "btnReport";
            btnReport.Size = new System.Drawing.Size(85, 36);
            btnReport.TabIndex = 6;
            btnReport.Text = "تبليغ";
            btnReport.UseVisualStyleBackColor = false;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = System.Drawing.Color.FromArgb(254, 242, 242);
            btnRemove.BorderColor = System.Drawing.Color.FromArgb(252, 165, 165);
            btnRemove.BorderRadius = 10;
            btnRemove.BorderSize = 1;
            btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRemove.Font = new System.Drawing.Font("Tajawal", 9.5F, System.Drawing.FontStyle.Bold);
            btnRemove.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            btnRemove.Location = new System.Drawing.Point(25, 37);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(75, 36);
            btnRemove.TabIndex = 7;
            btnRemove.Text = "إزالة";
            btnRemove.UseVisualStyleBackColor = false;
            // 
            // DamagedItemControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(cardPanel);
            Name = "DamagedItemControl";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            Size = new System.Drawing.Size(800, 110);
            cardPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        public CustomPanel cardPanel;
        public System.Windows.Forms.Label lblName;
        public System.Windows.Forms.Label lblCategory;
        public System.Windows.Forms.Label lblQtyTitle;
        public System.Windows.Forms.Label lblQtyValue;
        public System.Windows.Forms.Label lblLossTitle;
        public System.Windows.Forms.Label lblLossValue;
        public RoundedButton btnReport;
        public RoundedButton btnRemove;
    }
}
