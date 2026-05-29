namespace ActiveSpaceSystem.Forms.DialogForms
{
    partial class DamagedGoodsDialog
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
            headerPanel = new System.Windows.Forms.Panel();
            iconPanel = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            lblClose = new System.Windows.Forms.Label();
            listPanel = new System.Windows.Forms.FlowLayoutPanel();
            footerPanel = new System.Windows.Forms.Panel();
            summaryCard = new ActiveSpaceSystem.CustomItems.CustomPanel();
            lblTotalTitle = new System.Windows.Forms.Label();
            lblTotalValue = new System.Windows.Forms.Label();
            headerPanel.SuspendLayout();
            footerPanel.SuspendLayout();
            summaryCard.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = System.Drawing.Color.White;
            headerPanel.Controls.Add(iconPanel);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(lblClose);
            headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            headerPanel.Location = new System.Drawing.Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new System.Drawing.Size(850, 70);
            headerPanel.TabIndex = 0;
            // 
            // iconPanel
            // 
            iconPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            iconPanel.BackColor = System.Drawing.Color.Transparent;
            iconPanel.Location = new System.Drawing.Point(792, 18);
            iconPanel.Name = "iconPanel";
            iconPanel.Size = new System.Drawing.Size(34, 34);
            iconPanel.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblTitle.BackColor = System.Drawing.Color.Transparent;
            lblTitle.Font = new System.Drawing.Font("Tajawal", 15F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            lblTitle.Location = new System.Drawing.Point(542, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(244, 34);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "تقرير البضائع التالفة";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblClose
            // 
            lblClose.BackColor = System.Drawing.Color.Transparent;
            lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            lblClose.Font = new System.Drawing.Font("Tajawal", 15F, System.Drawing.FontStyle.Bold);
            lblClose.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblClose.Location = new System.Drawing.Point(24, 18);
            lblClose.Name = "lblClose";
            lblClose.Size = new System.Drawing.Size(34, 34);
            lblClose.TabIndex = 0;
            lblClose.Text = "✕";
            lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listPanel
            // 
            listPanel.AutoScroll = true;
            listPanel.BackColor = System.Drawing.Color.White;
            listPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            listPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            listPanel.Location = new System.Drawing.Point(0, 70);
            listPanel.Name = "listPanel";
            listPanel.Padding = new System.Windows.Forms.Padding(24, 10, 24, 10);
            listPanel.Size = new System.Drawing.Size(850, 480);
            listPanel.TabIndex = 1;
            listPanel.WrapContents = false;
            // 
            // footerPanel
            // 
            footerPanel.BackColor = System.Drawing.Color.White;
            footerPanel.Controls.Add(summaryCard);
            footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            footerPanel.Location = new System.Drawing.Point(0, 550);
            footerPanel.Name = "footerPanel";
            footerPanel.Padding = new System.Windows.Forms.Padding(24, 10, 24, 20);
            footerPanel.Size = new System.Drawing.Size(850, 100);
            footerPanel.TabIndex = 2;
            // 
            // summaryCard
            // 
            summaryCard.BackColor = System.Drawing.Color.FromArgb(254, 242, 242);
            summaryCard.BorderColor = System.Drawing.Color.FromArgb(254, 226, 226);
            summaryCard.BorderRadius = 16;
            summaryCard.BorderSize = 1.5F;
            summaryCard.Controls.Add(lblTotalTitle);
            summaryCard.Controls.Add(lblTotalValue);
            summaryCard.Dock = System.Windows.Forms.DockStyle.Fill;
            summaryCard.Location = new System.Drawing.Point(24, 10);
            summaryCard.Name = "summaryCard";
            summaryCard.ShowShadow = false;
            summaryCard.Size = new System.Drawing.Size(802, 70);
            summaryCard.TabIndex = 0;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblTotalTitle.BackColor = System.Drawing.Color.Transparent;
            lblTotalTitle.Font = new System.Drawing.Font("Tajawal", 13F, System.Drawing.FontStyle.Bold);
            lblTotalTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblTotalTitle.Location = new System.Drawing.Point(598, 15);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new System.Drawing.Size(180, 40);
            lblTotalTitle.TabIndex = 0;
            lblTotalTitle.Text = "إجمالي الخسائر:";
            lblTotalTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalValue
            // 
            lblTotalValue.BackColor = System.Drawing.Color.Transparent;
            lblTotalValue.Font = new System.Drawing.Font("Tajawal", 16F, System.Drawing.FontStyle.Bold);
            lblTotalValue.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            lblTotalValue.Location = new System.Drawing.Point(24, 15);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new System.Drawing.Size(200, 40);
            lblTotalValue.TabIndex = 1;
            lblTotalValue.Text = "0 د.ل";
            lblTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DamagedGoodsDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(850, 650);
            Controls.Add(listPanel);
            Controls.Add(headerPanel);
            Controls.Add(footerPanel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "DamagedGoodsDialog";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            RightToLeftLayout = true;
            headerPanel.ResumeLayout(false);
            footerPanel.ResumeLayout(false);
            summaryCard.ResumeLayout(false);
            ResumeLayout(false);
        }

        public System.Windows.Forms.Panel headerPanel;
        public System.Windows.Forms.Panel iconPanel;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Label lblClose;
        public System.Windows.Forms.FlowLayoutPanel listPanel;
        public System.Windows.Forms.Panel footerPanel;
        public ActiveSpaceSystem.CustomItems.CustomPanel summaryCard;
        public System.Windows.Forms.Label lblTotalTitle;
        public System.Windows.Forms.Label lblTotalValue;
    }
}
