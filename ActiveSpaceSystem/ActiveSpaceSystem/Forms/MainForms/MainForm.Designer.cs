namespace ActiveSpaceSystem.Forms.MainForms
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            btnInventory = new Button();
            btnSales = new Button();
            btExpense = new Button();
            panel5 = new Panel();
            pictureBox1 = new PictureBox();
            LabelRole = new Label();
            LabelUser = new Label();
            btSettings = new Button();
            btReports = new Button();
            btCustomers = new Button();
            btContract = new Button();
            btPayment = new Button();
            btScheduling = new Button();
            btBooking = new Button();
            btMain = new Button();
            panel4 = new Panel();
            pictureBox3 = new PictureBox();
            panel2 = new Panel();
            lblDate = new Label();
            btLogout = new Button();
            PanelContaint = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            btnEmployees = new Button();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(31, 41, 55);
            panel1.Controls.Add(btnEmployees);
            panel1.Controls.Add(btnInventory);
            panel1.Controls.Add(btnSales);
            panel1.Controls.Add(btExpense);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(btSettings);
            panel1.Controls.Add(btReports);
            panel1.Controls.Add(btCustomers);
            panel1.Controls.Add(btContract);
            panel1.Controls.Add(btPayment);
            panel1.Controls.Add(btScheduling);
            panel1.Controls.Add(btBooking);
            panel1.Controls.Add(btMain);
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.RightToLeft = RightToLeft.No;
            panel1.Size = new Size(240, 919);
            panel1.TabIndex = 0;
            // 
            // btnInventory
            // 
            btnInventory.FlatAppearance.BorderSize = 0;
            btnInventory.FlatStyle = FlatStyle.Flat;
            btnInventory.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold);
            btnInventory.ForeColor = Color.White;
            btnInventory.Image = Properties.Resources.icons8_box_64__1_;
            btnInventory.ImageAlign = ContentAlignment.MiddleRight;
            btnInventory.Location = new Point(17, 625);
            btnInventory.Margin = new Padding(4);
            btnInventory.Name = "btnInventory";
            btnInventory.Padding = new Padding(10, 0, 10, 0);
            btnInventory.Size = new Size(212, 46);
            btnInventory.TabIndex = 17;
            btnInventory.Text = "المخزون";
            btnInventory.TextAlign = ContentAlignment.MiddleRight;
            btnInventory.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnInventory.UseVisualStyleBackColor = false;
            // 
            // btnSales
            // 
            btnSales.FlatAppearance.BorderSize = 0;
            btnSales.FlatStyle = FlatStyle.Flat;
            btnSales.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold);
            btnSales.ForeColor = Color.White;
            btnSales.Image = Properties.Resources.icons8_shopping_cart_50__1_;
            btnSales.ImageAlign = ContentAlignment.MiddleRight;
            btnSales.Location = new Point(17, 571);
            btnSales.Margin = new Padding(4);
            btnSales.Name = "btnSales";
            btnSales.Padding = new Padding(10, 0, 10, 0);
            btnSales.Size = new Size(212, 46);
            btnSales.TabIndex = 16;
            btnSales.Text = "المشتريات";
            btnSales.TextAlign = ContentAlignment.MiddleRight;
            btnSales.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnSales.UseVisualStyleBackColor = false;
            // 
            // btExpense
            // 
            btExpense.FlatAppearance.BorderSize = 0;
            btExpense.FlatStyle = FlatStyle.Flat;
            btExpense.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold);
            btExpense.ForeColor = Color.White;
            btExpense.Image = Properties.Resources.icons8_payment_32;
            btExpense.ImageAlign = ContentAlignment.MiddleRight;
            btExpense.Location = new Point(17, 514);
            btExpense.Margin = new Padding(4);
            btExpense.Name = "btExpense";
            btExpense.Padding = new Padding(10, 0, 10, 0);
            btExpense.Size = new Size(212, 46);
            btExpense.TabIndex = 15;
            btExpense.Text = "المصروفات";
            btExpense.TextAlign = ContentAlignment.MiddleRight;
            btExpense.TextImageRelation = TextImageRelation.TextBeforeImage;
            btExpense.UseVisualStyleBackColor = false;
            btExpense.Click += button10_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(pictureBox1);
            panel5.Controls.Add(LabelRole);
            panel5.Controls.Add(LabelUser);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 839);
            panel5.Margin = new Padding(4);
            panel5.Name = "panel5";
            panel5.Size = new Size(240, 80);
            panel5.TabIndex = 14;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(197, 18);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 55);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // LabelRole
            // 
            LabelRole.AutoSize = true;
            LabelRole.Font = new Font("Microsoft Sans Serif", 9.799999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelRole.ForeColor = Color.Silver;
            LabelRole.Location = new Point(55, 53);
            LabelRole.Name = "LabelRole";
            LabelRole.Size = new Size(50, 20);
            LabelRole.TabIndex = 1;
            LabelRole.Text = "موظف";
            // 
            // LabelUser
            // 
            LabelUser.AutoSize = true;
            LabelUser.Font = new Font("Microsoft Sans Serif", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelUser.ForeColor = Color.White;
            LabelUser.Location = new Point(44, 18);
            LabelUser.Name = "LabelUser";
            LabelUser.Size = new Size(90, 25);
            LabelUser.TabIndex = 0;
            LabelUser.Text = "احمد محمد";
            // 
            // btSettings
            // 
            btSettings.FlatAppearance.BorderSize = 0;
            btSettings.FlatStyle = FlatStyle.Flat;
            btSettings.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold);
            btSettings.ForeColor = Color.White;
            btSettings.Image = (Image)resources.GetObject("btSettings.Image");
            btSettings.ImageAlign = ContentAlignment.MiddleRight;
            btSettings.Location = new Point(17, 780);
            btSettings.Margin = new Padding(4);
            btSettings.Name = "btSettings";
            btSettings.Padding = new Padding(10, 0, 10, 0);
            btSettings.Size = new Size(212, 46);
            btSettings.TabIndex = 13;
            btSettings.Text = "الإعدادات";
            btSettings.TextAlign = ContentAlignment.MiddleRight;
            btSettings.TextImageRelation = TextImageRelation.TextBeforeImage;
            btSettings.UseVisualStyleBackColor = false;
            // 
            // btReports
            // 
            btReports.FlatAppearance.BorderSize = 0;
            btReports.FlatStyle = FlatStyle.Flat;
            btReports.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold);
            btReports.ForeColor = Color.White;
            btReports.Image = (Image)resources.GetObject("btReports.Image");
            btReports.ImageAlign = ContentAlignment.MiddleRight;
            btReports.Location = new Point(17, 726);
            btReports.Margin = new Padding(4);
            btReports.Name = "btReports";
            btReports.Padding = new Padding(10, 0, 10, 0);
            btReports.Size = new Size(212, 46);
            btReports.TabIndex = 12;
            btReports.Text = "التقارير";
            btReports.TextAlign = ContentAlignment.MiddleRight;
            btReports.TextImageRelation = TextImageRelation.TextBeforeImage;
            btReports.UseVisualStyleBackColor = false;
            // 
            // btCustomers
            // 
            btCustomers.FlatAppearance.BorderSize = 0;
            btCustomers.FlatStyle = FlatStyle.Flat;
            btCustomers.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold);
            btCustomers.ForeColor = Color.White;
            btCustomers.Image = (Image)resources.GetObject("btCustomers.Image");
            btCustomers.ImageAlign = ContentAlignment.MiddleRight;
            btCustomers.Location = new Point(17, 314);
            btCustomers.Margin = new Padding(4);
            btCustomers.Name = "btCustomers";
            btCustomers.Padding = new Padding(10, 0, 10, 0);
            btCustomers.Size = new Size(212, 46);
            btCustomers.TabIndex = 11;
            btCustomers.Text = "العملاء";
            btCustomers.TextAlign = ContentAlignment.MiddleRight;
            btCustomers.TextImageRelation = TextImageRelation.TextBeforeImage;
            btCustomers.UseVisualStyleBackColor = false;
            // 
            // btContract
            // 
            btContract.FlatAppearance.BorderSize = 0;
            btContract.FlatStyle = FlatStyle.Flat;
            btContract.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold);
            btContract.ForeColor = Color.White;
            btContract.Image = (Image)resources.GetObject("btContract.Image");
            btContract.ImageAlign = ContentAlignment.MiddleRight;
            btContract.Location = new Point(17, 381);
            btContract.Margin = new Padding(4);
            btContract.Name = "btContract";
            btContract.Padding = new Padding(10, 0, 10, 0);
            btContract.Size = new Size(212, 46);
            btContract.TabIndex = 10;
            btContract.Text = "العقود الشهرية";
            btContract.TextAlign = ContentAlignment.MiddleRight;
            btContract.TextImageRelation = TextImageRelation.TextBeforeImage;
            btContract.UseVisualStyleBackColor = false;
            // 
            // btPayment
            // 
            btPayment.FlatAppearance.BorderSize = 0;
            btPayment.FlatStyle = FlatStyle.Flat;
            btPayment.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold);
            btPayment.ForeColor = Color.White;
            btPayment.Image = (Image)resources.GetObject("btPayment.Image");
            btPayment.ImageAlign = ContentAlignment.MiddleRight;
            btPayment.Location = new Point(17, 447);
            btPayment.Margin = new Padding(4);
            btPayment.Name = "btPayment";
            btPayment.Padding = new Padding(10, 0, 10, 0);
            btPayment.Size = new Size(212, 46);
            btPayment.TabIndex = 9;
            btPayment.Text = "المدفوعات";
            btPayment.TextAlign = ContentAlignment.MiddleRight;
            btPayment.TextImageRelation = TextImageRelation.TextBeforeImage;
            btPayment.UseVisualStyleBackColor = false;
            // 
            // btScheduling
            // 
            btScheduling.FlatAppearance.BorderSize = 0;
            btScheduling.FlatStyle = FlatStyle.Flat;
            btScheduling.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold);
            btScheduling.ForeColor = Color.White;
            btScheduling.Image = (Image)resources.GetObject("btScheduling.Image");
            btScheduling.ImageAlign = ContentAlignment.MiddleRight;
            btScheduling.Location = new Point(17, 248);
            btScheduling.Margin = new Padding(4);
            btScheduling.Name = "btScheduling";
            btScheduling.Padding = new Padding(10, 0, 10, 0);
            btScheduling.Size = new Size(212, 46);
            btScheduling.TabIndex = 8;
            btScheduling.Text = "الجدولة";
            btScheduling.TextAlign = ContentAlignment.MiddleRight;
            btScheduling.TextImageRelation = TextImageRelation.TextBeforeImage;
            btScheduling.UseVisualStyleBackColor = false;
            // 
            // btBooking
            // 
            btBooking.FlatAppearance.BorderSize = 0;
            btBooking.FlatStyle = FlatStyle.Flat;
            btBooking.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold);
            btBooking.ForeColor = Color.White;
            btBooking.Image = (Image)resources.GetObject("btBooking.Image");
            btBooking.ImageAlign = ContentAlignment.MiddleRight;
            btBooking.Location = new Point(17, 182);
            btBooking.Margin = new Padding(4);
            btBooking.Name = "btBooking";
            btBooking.Padding = new Padding(10, 0, 10, 0);
            btBooking.Size = new Size(212, 46);
            btBooking.TabIndex = 7;
            btBooking.Text = "إدارة الحجوزات";
            btBooking.TextAlign = ContentAlignment.MiddleRight;
            btBooking.TextImageRelation = TextImageRelation.TextBeforeImage;
            btBooking.UseVisualStyleBackColor = false;
            // 
            // btMain
            // 
            btMain.FlatAppearance.BorderSize = 0;
            btMain.FlatStyle = FlatStyle.Flat;
            btMain.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold);
            btMain.ForeColor = Color.White;
            btMain.Image = (Image)resources.GetObject("btMain.Image");
            btMain.ImageAlign = ContentAlignment.MiddleRight;
            btMain.Location = new Point(17, 115);
            btMain.Margin = new Padding(4);
            btMain.Name = "btMain";
            btMain.Padding = new Padding(10, 0, 10, 0);
            btMain.Size = new Size(212, 46);
            btMain.TabIndex = 6;
            btMain.Text = "الرئيسية";
            btMain.TextAlign = ContentAlignment.MiddleRight;
            btMain.TextImageRelation = TextImageRelation.TextBeforeImage;
            btMain.UseVisualStyleBackColor = false;
            btMain.Click += btMain_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(pictureBox3);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new Size(240, 107);
            panel4.TabIndex = 4;
            // 
            // pictureBox3
            // 
            pictureBox3.Dock = DockStyle.Right;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(44, 0);
            pictureBox3.Margin = new Padding(4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(196, 107);
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblDate);
            panel2.Controls.Add(btLogout);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(240, 0);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1022, 70);
            panel2.TabIndex = 1;
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top;
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold);
            lblDate.ForeColor = Color.FromArgb(64, 64, 64);
            lblDate.Location = new Point(482, 26);
            lblDate.Margin = new Padding(4, 0, 4, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(65, 29);
            lblDate.TabIndex = 16;
            lblDate.Text = "label3";
            // 
            // btLogout
            // 
            btLogout.Anchor = AnchorStyles.Left;
            btLogout.FlatAppearance.BorderSize = 0;
            btLogout.FlatStyle = FlatStyle.Flat;
            btLogout.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold);
            btLogout.ForeColor = Color.Black;
            btLogout.Image = (Image)resources.GetObject("btLogout.Image");
            btLogout.ImageAlign = ContentAlignment.MiddleRight;
            btLogout.Location = new Point(39, 9);
            btLogout.Margin = new Padding(4);
            btLogout.Name = "btLogout";
            btLogout.Size = new Size(212, 57);
            btLogout.TabIndex = 15;
            btLogout.Text = "تسجيل خروج";
            btLogout.TextAlign = ContentAlignment.MiddleRight;
            btLogout.TextImageRelation = TextImageRelation.TextBeforeImage;
            btLogout.UseVisualStyleBackColor = false;
            btLogout.Click += button9_Click_1;
            // 
            // PanelContaint
            // 
            PanelContaint.Dock = DockStyle.Fill;
            PanelContaint.Location = new Point(240, 70);
            PanelContaint.Margin = new Padding(4);
            PanelContaint.Name = "PanelContaint";
            PanelContaint.Size = new Size(1022, 849);
            PanelContaint.TabIndex = 2;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // btnEmployees
            // 
            btnEmployees.FlatAppearance.BorderSize = 0;
            btnEmployees.FlatStyle = FlatStyle.Flat;
            btnEmployees.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold);
            btnEmployees.ForeColor = Color.White;
            btnEmployees.Image = Properties.Resources.icons8_employee_50__1_;
            btnEmployees.ImageAlign = ContentAlignment.MiddleRight;
            btnEmployees.Location = new Point(15, 674);
            btnEmployees.Margin = new Padding(4);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Padding = new Padding(10, 0, 10, 0);
            btnEmployees.Size = new Size(212, 46);
            btnEmployees.TabIndex = 18;
            btnEmployees.Text = "إدارة الموظفين";
            btnEmployees.TextAlign = ContentAlignment.MiddleRight;
            btnEmployees.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnEmployees.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1262, 919);
            Controls.Add(PanelContaint);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            Name = "MainForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel PanelContaint;
        private Panel panel4;
        private Button btMain;
        private Button btBooking;
        private Button btCustomers;
        private Button btContract;
        private Button btPayment;
        private Button btScheduling;
        private Button btSettings;
        private Button btReports;
        private Panel panel5;
        private Label LabelRole;
        private Label LabelUser;
        private PictureBox pictureBox1;
        private Button btLogout;
        private System.Windows.Forms.Timer timer1;
        private Label lblDate;
        private PictureBox pictureBox3;
        private Button btExpense;
        private Button btnSales;
        private Button btnInventory;
        private Button btnEmployees;
    }
}