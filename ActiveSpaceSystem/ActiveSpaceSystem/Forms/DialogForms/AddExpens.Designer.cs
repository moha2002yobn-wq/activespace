using System.Drawing;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.DialogForms
{
    partial class AddExpens
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
            panelDateInfo = new ActiveSpaceSystem.CustomItems.CustomPanel();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            lblExpensesHeader = new Label();
            btnAddItem = new ActiveSpaceSystem.CustomItems.RoundedButton();
            flowItems = new FlowLayoutPanel();
            panelTotal = new ActiveSpaceSystem.CustomItems.CustomPanel();
            lblTotalAmount = new Label();
            btCancel = new ActiveSpaceSystem.CustomItems.RoundedButton();
            btSave = new ActiveSpaceSystem.CustomItems.RoundedButton();
            panelDateInfo.SuspendLayout();
            panelTotal.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Tajawal", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(29, 53, 87);
            lblTitle.Location = new Point(690, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(211, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "إضافة مصروفات";
            // 
            // buttonClose
            // 
            buttonClose.Cursor = Cursors.Hand;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonClose.ForeColor = Color.DimGray;
            buttonClose.Location = new Point(27, 31);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(47, 54);
            buttonClose.TabIndex = 1;
            buttonClose.Text = "✕";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // panelDateInfo
            // 
            panelDateInfo.BackColor = Color.FromArgb(251, 251, 252);
            panelDateInfo.BorderColor = Color.FromArgb(240, 242, 245);
            panelDateInfo.BorderRadius = 15;
            panelDateInfo.BorderSize = 1F;
            panelDateInfo.Controls.Add(lblDate);
            panelDateInfo.Controls.Add(dtpDate);
            panelDateInfo.Location = new Point(40, 110);
            panelDateInfo.Name = "panelDateInfo";
            panelDateInfo.ShowShadow = false;
            panelDateInfo.Size = new Size(870, 115);
            panelDateInfo.TabIndex = 2;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Tajawal", 9.5F, FontStyle.Bold);
            lblDate.ForeColor = Color.FromArgb(100, 110, 125);
            lblDate.Location = new Point(770, 18);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(65, 24);
            lblDate.TabIndex = 0;
            lblDate.Text = "التاريخ *";
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Tajawal", 11F);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(27, 55);
            dtpDate.Name = "dtpDate";
            dtpDate.RightToLeft = RightToLeft.Yes;
            dtpDate.RightToLeftLayout = true;
            dtpDate.Size = new Size(808, 33);
            dtpDate.TabIndex = 1;
            // 
            // lblExpensesHeader
            // 
            lblExpensesHeader.Font = new Font("Tajawal", 13F, FontStyle.Bold);
            lblExpensesHeader.ForeColor = Color.FromArgb(29, 53, 87);
            lblExpensesHeader.Location = new Point(590, 252);
            lblExpensesHeader.Name = "lblExpensesHeader";
            lblExpensesHeader.RightToLeft = RightToLeft.Yes;
            lblExpensesHeader.Size = new Size(320, 32);
            lblExpensesHeader.TabIndex = 3;
            lblExpensesHeader.Text = "المصروفات (1)";
            lblExpensesHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnAddItem
            // 
            btnAddItem.BackColor = Color.FromArgb(16, 185, 129);
            btnAddItem.BorderColor = Color.FromArgb(16, 185, 129);
            btnAddItem.BorderRadius = 10;
            btnAddItem.BorderSize = 0;
            btnAddItem.Cursor = Cursors.Hand;
            btnAddItem.FlatStyle = FlatStyle.Flat;
            btnAddItem.Font = new Font("Tajawal", 11F, FontStyle.Bold);
            btnAddItem.ForeColor = Color.White;
            btnAddItem.Location = new Point(40, 244);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(210, 45);
            btnAddItem.TabIndex = 4;
            btnAddItem.Text = "+ إضافة مصروف آخر";
            btnAddItem.UseVisualStyleBackColor = false;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // flowItems
            // 
            flowItems.AutoScroll = true;
            flowItems.FlowDirection = FlowDirection.TopDown;
            flowItems.Location = new Point(40, 305);
            flowItems.Name = "flowItems";
            flowItems.Size = new Size(870, 420);
            flowItems.TabIndex = 5;
            flowItems.WrapContents = false;
            // 
            // panelTotal
            // 
            panelTotal.BackColor = Color.FromArgb(240, 253, 250);
            panelTotal.BorderColor = Color.FromArgb(130, 223, 192);
            panelTotal.BorderRadius = 10;
            panelTotal.BorderSize = 1F;
            panelTotal.Controls.Add(lblTotalAmount);
            panelTotal.Location = new Point(40, 745);
            panelTotal.Name = "panelTotal";
            panelTotal.ShowShadow = false;
            panelTotal.Size = new Size(870, 60);
            panelTotal.TabIndex = 6;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.Dock = DockStyle.Fill;
            lblTotalAmount.Font = new Font("Tajawal", 12F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(13, 148, 136);
            lblTotalAmount.Location = new Point(0, 0);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Padding = new Padding(15, 0, 15, 0);
            lblTotalAmount.RightToLeft = RightToLeft.Yes;
            lblTotalAmount.Size = new Size(870, 60);
            lblTotalAmount.TabIndex = 0;
            lblTotalAmount.Text = "إجمالي المصروفات: 0 د.ل";
            lblTotalAmount.TextAlign = ContentAlignment.MiddleLeft;
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
            btCancel.Location = new Point(40, 830);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(420, 55);
            btCancel.TabIndex = 7;
            btCancel.Text = "إلغاء";
            btCancel.UseVisualStyleBackColor = false;
            btCancel.Click += btCancel_Click;
            // 
            // btSave
            // 
            btSave.BackColor = Color.FromArgb(130, 223, 192);
            btSave.BorderColor = Color.FromArgb(130, 223, 192);
            btSave.BorderRadius = 10;
            btSave.BorderSize = 0;
            btSave.Cursor = Cursors.Hand;
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Tajawal", 13F, FontStyle.Bold);
            btSave.ForeColor = Color.White;
            btSave.Location = new Point(490, 830);
            btSave.Name = "btSave";
            btSave.Size = new Size(420, 55);
            btSave.TabIndex = 8;
            btSave.Text = "+ حفظ جميع المصروفات";
            btSave.UseVisualStyleBackColor = false;
            btSave.Click += btSave_Click;
            // 
            // AddExpens
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(950, 915);
            Controls.Add(lblTitle);
            Controls.Add(buttonClose);
            Controls.Add(panelDateInfo);
            Controls.Add(lblExpensesHeader);
            Controls.Add(btnAddItem);
            Controls.Add(flowItems);
            Controls.Add(panelTotal);
            Controls.Add(btCancel);
            Controls.Add(btSave);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddExpens";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إضافة مصروفات";
            Load += AddExpens_Load;
            Paint += AddExpens_Paint;
            panelDateInfo.ResumeLayout(false);
            panelDateInfo.PerformLayout();
            panelTotal.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button buttonClose;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelDateInfo;
        private System.Windows.Forms.Label lblDate;
        public System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblExpensesHeader;
        private ActiveSpaceSystem.CustomItems.RoundedButton btnAddItem;
        public System.Windows.Forms.FlowLayoutPanel flowItems;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelTotal;
        private System.Windows.Forms.Label lblTotalAmount;
        private ActiveSpaceSystem.CustomItems.RoundedButton btCancel;
        private ActiveSpaceSystem.CustomItems.RoundedButton btSave;
    }
}