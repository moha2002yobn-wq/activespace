namespace ActiveSpaceSystem.Forms.DialogForms
{
    partial class StateForm
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
            customPanel2 = new ActiveSpaceSystem.CustomItems.CustomPanel();
            cmbState = new ComboBox();
            btnCancel = new ActiveSpaceSystem.CustomItems.RoundedButton();
            btnEdit = new ActiveSpaceSystem.CustomItems.RoundedButton();
            label3 = new Label();
            label1 = new Label();
            customPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // customPanel2
            // 
            customPanel2.BackColor = Color.White;
            customPanel2.BorderColor = Color.Black;
            customPanel2.BorderRadius = 10;
            customPanel2.BorderSize = 1F;
            customPanel2.Controls.Add(cmbState);
            customPanel2.Location = new Point(28, 61);
            customPanel2.Name = "customPanel2";
            customPanel2.ShowShadow = false;
            customPanel2.Size = new Size(500, 55);
            customPanel2.TabIndex = 52;
            // 
            // cmbState
            // 
            cmbState.FlatStyle = FlatStyle.Flat;
            cmbState.FormattingEnabled = true;
            cmbState.Location = new Point(18, 13);
            cmbState.Name = "cmbState";
            cmbState.RightToLeft = RightToLeft.Yes;
            cmbState.Size = new Size(397, 28);
            cmbState.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.WhiteSmoke;
            btnCancel.BorderColor = Color.PaleVioletRed;
            btnCancel.BorderRadius = 10;
            btnCancel.BorderSize = 0;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.GrayText;
            btnCancel.Location = new Point(89, 125);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(168, 47);
            btnCancel.TabIndex = 55;
            btnCancel.Text = "إلغاء";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(16, 185, 129);
            btnEdit.BorderColor = Color.PaleVioletRed;
            btnEdit.BorderRadius = 10;
            btnEdit.BorderSize = 0;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(263, 125);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(180, 47);
            btnEdit.TabIndex = 54;
            btnEdit.Text = "تعديل";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(451, 75);
            label3.Name = "label3";
            label3.Size = new Size(60, 25);
            label3.TabIndex = 7;
            label3.Text = "الحالة";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tajawal", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(224, 15);
            label1.Name = "label1";
            label1.Size = new Size(142, 33);
            label1.TabIndex = 56;
            label1.Text = "تعديل الحالة";
            // 
            // StateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(558, 180);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(btnCancel);
            Controls.Add(btnEdit);
            Controls.Add(customPanel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StateForm";
            Text = "StateForm";
            Load += StateForm_Load;
            customPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomItems.CustomPanel customPanel2;
        public ComboBox cmbState;
        private CustomItems.RoundedButton btnCancel;
        private CustomItems.RoundedButton btnEdit;
        private Label label3;
        private Label label1;
    }
}