namespace ActiveSpaceSystem.CustomItems
{
    partial class NotificationCard
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            mainPanel = new ActiveSpaceSystem.CustomItems.CustomPanel();
            pnlIndicator = new System.Windows.Forms.Panel();
            pnlIconBack = new System.Windows.Forms.Panel();
            lblIcon = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            lblDescription = new System.Windows.Forms.Label();
            lblTime = new System.Windows.Forms.Label();
            mainPanel.SuspendLayout();
            pnlIconBack.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = System.Drawing.Color.White;
            mainPanel.BorderColor = System.Drawing.Color.FromArgb(240, 242, 245);
            mainPanel.BorderRadius = 15;
            mainPanel.BorderSize = 1F;
            mainPanel.Controls.Add(pnlIndicator);
            mainPanel.Controls.Add(pnlIconBack);
            mainPanel.Controls.Add(lblTitle);
            mainPanel.Controls.Add(lblDescription);
            mainPanel.Controls.Add(lblTime);
            mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            mainPanel.Location = new System.Drawing.Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new System.Windows.Forms.Padding(10);
            mainPanel.ShowShadow = false;
            mainPanel.Size = new System.Drawing.Size(320, 95);
            mainPanel.TabIndex = 0;
            // 
            // pnlIndicator
            // 
            pnlIndicator.BackColor = System.Drawing.Color.FromArgb(43, 127, 255);
            pnlIndicator.Dock = System.Windows.Forms.DockStyle.Right;
            pnlIndicator.Location = new System.Drawing.Point(315, 10);
            pnlIndicator.Name = "pnlIndicator";
            pnlIndicator.Size = new System.Drawing.Size(5, 75);
            pnlIndicator.TabIndex = 0;
            // 
            // pnlIconBack
            // 
            pnlIconBack.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            pnlIconBack.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            pnlIconBack.Controls.Add(lblIcon);
            pnlIconBack.Location = new System.Drawing.Point(265, 12);
            pnlIconBack.Name = "pnlIconBack";
            pnlIconBack.Size = new System.Drawing.Size(42, 42);
            pnlIconBack.TabIndex = 1;
            // 
            // lblIcon
            // 
            lblIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            lblIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 14F);
            lblIcon.Location = new System.Drawing.Point(0, 0);
            lblIcon.Name = "lblIcon";
            lblIcon.Size = new System.Drawing.Size(42, 42);
            lblIcon.TabIndex = 0;
            lblIcon.Text = "📅";
            lblIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblTitle.Font = new System.Drawing.Font("Tajawal Medium", 10.5F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblTitle.Location = new System.Drawing.Point(80, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            lblTitle.Size = new System.Drawing.Size(180, 24);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "حجز ملعب جديد";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescription
            // 
            lblDescription.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblDescription.Font = new System.Drawing.Font("Tajawal", 9F);
            lblDescription.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblDescription.Location = new System.Drawing.Point(10, 36);
            lblDescription.Name = "lblDescription";
            lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            lblDescription.Size = new System.Drawing.Size(250, 36);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "تم حجز الملعب الرئيسي لمباراة كرة قدم بواسطة محمد العريبي.";
            // 
            // lblTime
            // 
            lblTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblTime.AutoSize = true;
            lblTime.Font = new System.Drawing.Font("Tajawal Light", 8F);
            lblTime.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            lblTime.Location = new System.Drawing.Point(10, 72);
            lblTime.Name = "lblTime";
            lblTime.Size = new System.Drawing.Size(68, 19);
            lblTime.TabIndex = 4;
            lblTime.Text = "منذ 5 دقائق";
            lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NotificationCard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(mainPanel);
            Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            Name = "NotificationCard";
            Size = new System.Drawing.Size(320, 95);
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            pnlIconBack.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ActiveSpaceSystem.CustomItems.CustomPanel mainPanel;
        private System.Windows.Forms.Panel pnlIndicator;
        private System.Windows.Forms.Panel pnlIconBack;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblTime;
    }
}
