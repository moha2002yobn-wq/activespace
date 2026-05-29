namespace ActiveSpaceSystem.Forms.SideForms
{
    partial class StaduimSteting
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaduimSteting));
            panel1 = new Panel();
            roundedButton1 = new ActiveSpaceSystem.CustomItems.RoundedButton();
            label1 = new Label();
            dgvMonthlyContract = new ActiveSpaceSystem.CustomItems.CustomDataGridView();
            StdName = new DataGridViewTextBoxColumn();
            type = new DataGridViewTextBoxColumn();
            opentime = new DataGridViewTextBoxColumn();
            closeTime = new DataGridViewTextBoxColumn();
            EditColumn = new DataGridViewImageColumn();
            DeleteColumn = new DataGridViewImageColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonthlyContract).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(roundedButton1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(904, 85);
            panel1.TabIndex = 1;
            // 
            // roundedButton1
            // 
            roundedButton1.BackColor = Color.FromArgb(38, 191, 141);
            roundedButton1.BorderColor = Color.PaleVioletRed;
            roundedButton1.BorderRadius = 15;
            roundedButton1.BorderSize = 0;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.Font = new Font("Tajawal Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundedButton1.ForeColor = Color.White;
            roundedButton1.Image = Properties.Resources.icons8_add_50__1_;
            roundedButton1.ImageAlign = ContentAlignment.MiddleRight;
            roundedButton1.Location = new Point(12, 13);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Padding = new Padding(20, 10, 20, 10);
            roundedButton1.Size = new Size(258, 55);
            roundedButton1.TabIndex = 9;
            roundedButton1.Text = "إضافة ملعب جديد";
            roundedButton1.TextAlign = ContentAlignment.MiddleLeft;
            roundedButton1.UseVisualStyleBackColor = false;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Tajawal", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(575, 14);
            label1.Name = "label1";
            label1.Size = new Size(317, 44);
            label1.TabIndex = 0;
            label1.Text = "إدارة الملاعب والأسعار";
            // 
            // dgvMonthlyContract
            // 
            dgvMonthlyContract.AllowUserToAddRows = false;
            dgvMonthlyContract.AllowUserToResizeRows = false;
            dgvMonthlyContract.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonthlyContract.BackgroundColor = Color.White;
            dgvMonthlyContract.BorderRadius = 15;
            dgvMonthlyContract.BorderStyle = BorderStyle.None;
            dgvMonthlyContract.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMonthlyContract.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.Font = new Font("Tajawal", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMonthlyContract.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMonthlyContract.ColumnHeadersHeight = 50;
            dgvMonthlyContract.Columns.AddRange(new DataGridViewColumn[] { StdName, type, opentime, closeTime, EditColumn, DeleteColumn });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Tajawal", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(240, 245, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvMonthlyContract.DefaultCellStyle = dataGridViewCellStyle4;
            dgvMonthlyContract.Dock = DockStyle.Fill;
            dgvMonthlyContract.EnableHeadersVisualStyles = false;
            dgvMonthlyContract.GridColor = Color.FromArgb(230, 230, 230);
            dgvMonthlyContract.HeaderBackColor = Color.FromArgb(243, 244, 246);
            dgvMonthlyContract.HeaderForeColor = Color.FromArgb(33, 37, 41);
            dgvMonthlyContract.Location = new Point(0, 85);
            dgvMonthlyContract.MultiSelect = false;
            dgvMonthlyContract.Name = "dgvMonthlyContract";
            dgvMonthlyContract.RightToLeft = RightToLeft.Yes;
            dgvMonthlyContract.RowHeadersVisible = false;
            dgvMonthlyContract.RowHeadersWidth = 51;
            dgvMonthlyContract.RowHeight = 50;
            dgvMonthlyContract.RowTemplate.Height = 50;
            dgvMonthlyContract.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMonthlyContract.Size = new Size(904, 326);
            dgvMonthlyContract.TabIndex = 6;
            dgvMonthlyContract.CellContentClick += dgvMonthlyContract_CellContentClick;
            // 
            // StdName
            // 
            StdName.DataPropertyName = "CourtName";
            StdName.HeaderText = "اسم الملعب";
            StdName.MinimumWidth = 8;
            StdName.Name = "StdName";
            // 
            // type
            // 
            type.DataPropertyName = "TypeName";
            type.HeaderText = "النوع";
            type.MinimumWidth = 8;
            type.Name = "type";
            // 
            // opentime
            // 
            opentime.DataPropertyName = "OpenTime";
            dataGridViewCellStyle2.Format = "hh\\:mm";
            opentime.DefaultCellStyle = dataGridViewCellStyle2;
            opentime.HeaderText = "وقت الفتح";
            opentime.MinimumWidth = 8;
            opentime.Name = "opentime";
            // 
            // closeTime
            // 
            closeTime.DataPropertyName = "CloseTime";
            dataGridViewCellStyle3.Format = "hh\\:mm";
            closeTime.DefaultCellStyle = dataGridViewCellStyle3;
            closeTime.HeaderText = " وقت الاغلاق";
            closeTime.MinimumWidth = 8;
            closeTime.Name = "closeTime";
            // 
            // EditColumn
            // 
            EditColumn.HeaderText = "تعديل";
            EditColumn.Image = (Image)resources.GetObject("EditColumn.Image");
            EditColumn.MinimumWidth = 6;
            EditColumn.Name = "EditColumn";
            // 
            // DeleteColumn
            // 
            DeleteColumn.HeaderText = "حذف";
            DeleteColumn.Image = (Image)resources.GetObject("DeleteColumn.Image");
            DeleteColumn.MinimumWidth = 6;
            DeleteColumn.Name = "DeleteColumn";
            // 
            // StaduimSteting
            // 
            AutoScaleDimensions = new SizeF(8F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(904, 411);
            Controls.Add(dgvMonthlyContract);
            Controls.Add(panel1);
            Font = new Font("Tajawal", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "StaduimSteting";
            Text = "StaduimSteting";
            Load += StaduimSteting_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonthlyContract).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private CustomItems.CustomDataGridView dgvMonthlyContract;
        private CustomItems.RoundedButton roundedButton1;
        private DataGridViewTextBoxColumn StdName;
        private DataGridViewTextBoxColumn type;
        private DataGridViewTextBoxColumn opentime;
        private DataGridViewTextBoxColumn closeTime;
        private DataGridViewImageColumn EditColumn;
        private DataGridViewImageColumn DeleteColumn;
    }
}