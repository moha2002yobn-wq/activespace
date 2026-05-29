using System.Drawing;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.DialogForms
{
    partial class AddCategoryForm
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
            btnClose = new Button();
            lblTitle = new Label();
            lblCategoryName = new Label();
            txtCategoryName = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            btnSave = new ActiveSpaceSystem.CustomItems.RoundedButton();
            btnCancel = new ActiveSpaceSystem.CustomItems.RoundedButton();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(243, 244, 246);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(243, 244, 246);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(107, 114, 128);
            btnClose.Location = new Point(20, 20);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(32, 32);
            btnClose.TabIndex = 4;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Tajawal", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(29, 53, 87);
            lblTitle.Location = new Point(160, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = RightToLeft.Yes;
            lblTitle.Size = new Size(300, 35);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "إضافة فئة جديدة";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            lblCategoryName.ForeColor = Color.FromArgb(70, 80, 95);
            lblCategoryName.Location = new Point(366, 75);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.RightToLeft = RightToLeft.Yes;
            lblCategoryName.Size = new Size(97, 24);
            lblCategoryName.TabIndex = 3;
            lblCategoryName.Text = "اسم الفئة *";
            // 
            // txtCategoryName
            // 
            txtCategoryName.BackColor = Color.White;
            txtCategoryName.BorderColor = Color.FromArgb(209, 213, 219);
            txtCategoryName.BorderRadius = 10;
            txtCategoryName.Icon = null;
            txtCategoryName.IconLocation = HorizontalAlignment.Left;
            txtCategoryName.IconSize = 20;
            txtCategoryName.Location = new Point(20, 105);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.passwordChar = "\0";
            txtCategoryName.PlaceholderText = "مثال: معدات تدريب";
            txtCategoryName.RightToLeft = RightToLeft.Yes;
            txtCategoryName.Size = new Size(440, 48);
            txtCategoryName.TabIndex = 0;
            txtCategoryName.Texts = "";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(130, 223, 192);
            btnSave.BorderColor = Color.Transparent;
            btnSave.BorderRadius = 10;
            btnSave.BorderSize = 0;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Tajawal", 10.5F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(250, 175);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(210, 45);
            btnSave.TabIndex = 1;
            btnSave.Text = "+ إضافة الفئة";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.BorderColor = Color.FromArgb(209, 213, 219);
            btnCancel.BorderRadius = 10;
            btnCancel.BorderSize = 1;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Tajawal", 10.5F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(107, 114, 128);
            btnCancel.Location = new Point(20, 175);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(210, 45);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "إلغاء";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddCategoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(480, 240);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtCategoryName);
            Controls.Add(lblCategoryName);
            Controls.Add(lblTitle);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddCategoryForm";
            ShowInTaskbar = false;
            Text = "AddCategoryForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCategoryName;
        private ActiveSpaceSystem.CustomItems.AbdulTextBox txtCategoryName;
        private ActiveSpaceSystem.CustomItems.RoundedButton btnSave;
        private ActiveSpaceSystem.CustomItems.RoundedButton btnCancel;
    }
}
