using System.Drawing;
using System.Windows.Forms;

namespace ActiveSpaceSystem.CustomItems
{
    partial class ExpenseItemControl
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
            containerPanel = new ActiveSpaceSystem.CustomItems.CustomPanel();
            lblIndex = new Label();
            btnDelete = new Button();
            lblCategory = new Label();
            panelCategory = new ActiveSpaceSystem.CustomItems.CustomPanel();
            cmbCategory = new ComboBox();
            lblAmount = new Label();
            txtAmount = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            lblDescription = new Label();
            txtDescription = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            containerPanel.SuspendLayout();
            panelCategory.SuspendLayout();
            SuspendLayout();
            // 
            // containerPanel
            // 
            containerPanel.BackColor = Color.FromArgb(249, 250, 251);
            containerPanel.BorderColor = Color.FromArgb(230, 233, 238);
            containerPanel.BorderRadius = 15;
            containerPanel.BorderSize = 1F;
            containerPanel.Controls.Add(lblIndex);
            containerPanel.Controls.Add(btnDelete);
            containerPanel.Controls.Add(lblCategory);
            containerPanel.Controls.Add(panelCategory);
            containerPanel.Controls.Add(lblAmount);
            containerPanel.Controls.Add(txtAmount);
            containerPanel.Controls.Add(lblDescription);
            containerPanel.Controls.Add(txtDescription);
            containerPanel.Dock = DockStyle.Fill;
            containerPanel.Location = new Point(5, 5);
            containerPanel.Name = "containerPanel";
            containerPanel.ShowShadow = false;
            containerPanel.Size = new Size(840, 270);
            containerPanel.TabIndex = 0;
            // 
            // lblIndex
            // 
            lblIndex.Font = new Font("Tajawal", 12F, FontStyle.Bold);
            lblIndex.ForeColor = Color.FromArgb(29, 53, 87);
            lblIndex.Location = new Point(550, 15);
            lblIndex.Name = "lblIndex";
            lblIndex.RightToLeft = RightToLeft.Yes;
            lblIndex.Size = new Size(260, 28);
            lblIndex.TabIndex = 0;
            lblIndex.Text = "مصروف رقم 1";
            lblIndex.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnDelete
            // 
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.MouseDownBackColor = Color.FromArgb(254, 226, 226);
            btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 226, 226);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDelete.ForeColor = Color.FromArgb(239, 68, 68);
            btnDelete.Location = new Point(20, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(32, 32);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "✕";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblCategory
            // 
            lblCategory.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            lblCategory.ForeColor = Color.FromArgb(100, 110, 125);
            lblCategory.Location = new Point(430, 50);
            lblCategory.Name = "lblCategory";
            lblCategory.RightToLeft = RightToLeft.Yes;
            lblCategory.Size = new Size(380, 24);
            lblCategory.TabIndex = 1;
            lblCategory.Text = "الفئة *";
            // 
            // panelCategory
            // 
            panelCategory.BackColor = Color.White;
            panelCategory.BorderColor = Color.FromArgb(209, 213, 219);
            panelCategory.BorderRadius = 10;
            panelCategory.BorderSize = 1F;
            panelCategory.Controls.Add(cmbCategory);
            panelCategory.Location = new Point(430, 78);
            panelCategory.Name = "panelCategory";
            panelCategory.ShowShadow = false;
            panelCategory.Size = new Size(380, 48);
            panelCategory.TabIndex = 2;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FlatStyle = FlatStyle.Flat;
            cmbCategory.Font = new Font("Tajawal", 11F);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(10, 8);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.RightToLeft = RightToLeft.Yes;
            cmbCategory.Size = new Size(360, 34);
            cmbCategory.TabIndex = 0;
            // 
            // lblAmount
            // 
            lblAmount.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            lblAmount.ForeColor = Color.FromArgb(100, 110, 125);
            lblAmount.Location = new Point(20, 50);
            lblAmount.Name = "lblAmount";
            lblAmount.RightToLeft = RightToLeft.Yes;
            lblAmount.Size = new Size(380, 24);
            lblAmount.TabIndex = 3;
            lblAmount.Text = "المبلغ (د.ل) *";
            // 
            // txtAmount
            // 
            txtAmount.BackColor = Color.White;
            txtAmount.BorderColor = Color.FromArgb(209, 213, 219);
            txtAmount.BorderRadius = 10;
            txtAmount.Font = new Font("Tajawal", 11F);
            txtAmount.Icon = null;
            txtAmount.IconLocation = HorizontalAlignment.Left;
            txtAmount.IconSize = 20;
            txtAmount.Location = new Point(20, 78);
            txtAmount.Name = "txtAmount";
            txtAmount.passwordChar = "\0";
            txtAmount.PlaceholderText = "0.00";
            txtAmount.RightToLeft = RightToLeft.Yes;
            txtAmount.Size = new Size(380, 48);
            txtAmount.TabIndex = 4;
            txtAmount.Texts = "";
            // 
            // lblDescription
            // 
            lblDescription.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            lblDescription.ForeColor = Color.FromArgb(100, 110, 125);
            lblDescription.Location = new Point(20, 137);
            lblDescription.Name = "lblDescription";
            lblDescription.RightToLeft = RightToLeft.Yes;
            lblDescription.Size = new Size(790, 24);
            lblDescription.TabIndex = 5;
            lblDescription.Text = "وصف المصروف *";
            // 
            // txtDescription
            // 
            txtDescription.BackColor = Color.White;
            txtDescription.BorderColor = Color.FromArgb(209, 213, 219);
            txtDescription.BorderRadius = 10;
            txtDescription.Font = new Font("Tajawal", 11F);
            txtDescription.Icon = null;
            txtDescription.IconLocation = HorizontalAlignment.Left;
            txtDescription.IconSize = 20;
            txtDescription.Location = new Point(20, 165);
            txtDescription.Name = "txtDescription";
            txtDescription.passwordChar = "\0";
            txtDescription.PlaceholderText = "وصف تفصيلي";
            txtDescription.RightToLeft = RightToLeft.Yes;
            txtDescription.Size = new Size(790, 80);
            txtDescription.TabIndex = 6;
            txtDescription.Texts = "";
            // 
            // ExpenseItemControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(containerPanel);
            Name = "ExpenseItemControl";
            Padding = new Padding(5);
            Size = new Size(850, 280);
            containerPanel.ResumeLayout(false);
            panelCategory.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ActiveSpaceSystem.CustomItems.CustomPanel containerPanel;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblCategory;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelCategory;
        public System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblAmount;
        private ActiveSpaceSystem.CustomItems.AbdulTextBox txtAmount;
        private System.Windows.Forms.Label lblDescription;
        private ActiveSpaceSystem.CustomItems.AbdulTextBox txtDescription;
    }
}
