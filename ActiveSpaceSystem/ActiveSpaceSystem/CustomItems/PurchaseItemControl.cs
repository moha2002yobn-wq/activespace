using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ActiveSpace.Models;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Models;

namespace ActiveSpaceSystem.CustomItems
{
    public partial class PurchaseItemControl : UserControl
    {
        private int _index = 1;
        public event EventHandler DeleteClicked;

        public bool ShowDeleteButton
        {
            get => btnDelete.Visible;
            set => btnDelete.Visible = value;
        }

        public int Index
        {
            get => _index;
            set
            {
                _index = value;
                lblIndex.Text = $"الصنف {_index}";
                AdjustLayout();
            }
        }

        public string CategoryName
        {
            get => cmbCategory.Text.Trim();
            set => cmbCategory.Text = value;
        }

        public string ItemName
        {
            get => txtItemName.Texts.Trim();
            set => txtItemName.Texts = value;
        }

        public int Quantity
        {
            get => int.TryParse(txtQuantity.Texts.Trim(), out int qty) ? qty : 0;
            set => txtQuantity.Texts = value.ToString();
        }

        public decimal UnitPrice
        {
            get => decimal.TryParse(txtUnitPrice.Texts.Trim(), out decimal price) ? price : 0m;
            set => txtUnitPrice.Texts = value.ToString("0.##");
        }

        public decimal SellingPrice
        {
            get => decimal.TryParse(txtSellingPrice.Texts.Trim(), out decimal price) ? price : 0m;
            set => txtSellingPrice.Texts = value.ToString("0.##");
        }

        public int UsageType
        {
            get
            {
                bool forSale = chkForSale.Checked;
                bool forRental = chkForRental.Checked;
                if (forSale && forRental) return 3; // كلاهما
                if (forRental) return 2; // للإيجار
                return 1; // للبيع (default)
            }
            set
            {
                // Temporarily detach events to avoid recursive triggering
                chkForSale.CheckedChanged -= chkUsageType_CheckedChanged;
                chkForRental.CheckedChanged -= chkUsageType_CheckedChanged;

                switch (value)
                {
                    case 2: // للإيجار
                        chkForSale.Checked = false;
                        chkForRental.Checked = true;
                        break;
                    case 3: // كلاهما
                        chkForSale.Checked = true;
                        chkForRental.Checked = true;
                        break;
                    default: // 1 = للبيع
                        chkForSale.Checked = true;
                        chkForRental.Checked = false;
                        break;
                }

                chkForSale.CheckedChanged += chkUsageType_CheckedChanged;
                chkForRental.CheckedChanged += chkUsageType_CheckedChanged;

                ApplyUsageTypeState();
            }
        }

        public decimal RentalRate
        {
            get => decimal.TryParse(txtRentalRate.Texts.Trim(), out decimal rate) ? rate : 0m;
            set => txtRentalRate.Texts = value.ToString("0.##");
        }

        public bool ManualMinQuantity
        {
            get => chkManualMinQty.Checked;
            set
            {
                chkManualMinQty.Checked = value;
                ApplyMinQuantityState();
            }
        }

        public int MinQuantity
        {
            get => int.TryParse(txtMinQuantity.Texts.Trim(), out int qty) ? qty : 5;
            set
            {
                txtMinQuantity.Texts = value.ToString();
                if (value != 5)
                {
                    ManualMinQuantity = true;
                }
            }
        }

        public void ApplyMinQuantityState()
        {
            txtMinQuantity.Enabled = chkManualMinQty.Checked;
            if (!chkManualMinQty.Checked)
            {
                txtMinQuantity.Texts = "5";
            }
        }

        public string CourtTypeName
        {
            get => cmbCourtType.Text;
            set => cmbCourtType.Text = value;
        }

        public string CourtName
        {
            get => cmbCourt.Text;
            set => cmbCourt.Text = value;
        }

        public PurchaseItemControl()
        {
            InitializeComponent();
            SetupEvents();
            LoadData();
        }

        private void SetupEvents()
        {
            cmbCourtType.SelectedIndexChanged += new EventHandler(cmbCourtType_SelectedIndexChanged);
            chkForSale.CheckedChanged += chkUsageType_CheckedChanged;
            chkForRental.CheckedChanged += chkUsageType_CheckedChanged;
            chkManualMinQty.CheckedChanged += chkManualMinQty_CheckedChanged;
            btnAddCategory.Click += new EventHandler(btnAddCategory_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            this.SizeChanged += new EventHandler(PurchaseItemControl_SizeChanged);
        }

        private void PurchaseItemControl_SizeChanged(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void chkManualMinQty_CheckedChanged(object sender, EventArgs e)
        {
            ApplyMinQuantityState();
        }

        private void cmbCourtType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCourts();
        }

        private void chkUsageType_CheckedChanged(object sender, EventArgs e)
        {
            // Prevent unchecking both - at least one must be checked
            if (!chkForSale.Checked && !chkForRental.Checked)
            {
                // Re-check the one that was just unchecked
                ((CheckBox)sender).Checked = true;
                return;
            }
            ApplyUsageTypeState();
        }

        private void ApplyUsageTypeState()
        {
            bool forSale = chkForSale.Checked;
            bool forRental = chkForRental.Checked;

            // Selling Price field
            txtSellingPrice.Enabled = forSale;
            lblSellingPrice.Enabled = forSale;
            if (!forSale) txtSellingPrice.Texts = "0";

            // Rental Rate field
            txtRentalRate.Enabled = forRental;
            lblRentalRate.Enabled = forRental;
            if (!forRental) txtRentalRate.Texts = "0";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        private void AdjustLayout()
        {
            int W = this.Width;
            if (W < 300) return;

            // Two columns layout for ROW 1, ROW 3, and ROW 4
            int colWidth = (W - 60) / 2;
            int rightX = W - colWidth - 20;
            int leftX = 20;

            // HEADER
            this.lblIndex.Location = new Point(W - 20 - this.lblIndex.Width, 15);
            this.btnDelete.Location = new Point(20, 10);

            // ROW 1: (Category & AddBtn on Right, ItemName on Left)
            this.lblCategory.Location = new Point(W - 20 - this.lblCategory.Width, 50);
            this.btnAddCategory.Location = new Point(rightX, 80);
            this.panelCategory.Location = new Point(rightX + 58, 80);
            this.panelCategory.Size = new Size(colWidth - 58, 48);
            this.cmbCategory.Size = new Size(colWidth - 58 - 20, 31);

            this.lblItemName.Location = new Point(leftX + colWidth - this.lblItemName.Width, 50);
            this.txtItemName.Location = new Point(leftX, 80);
            this.txtItemName.Size = new Size(colWidth, 48);

            // ROW 2: (UsageType checkboxes on Right, Quantity in Middle, UnitPrice on Left)
            int colWidth3 = (W - 80) / 3;
            int rightCol3X = W - colWidth3 - 20;
            int middleCol3X = W - (colWidth3 * 2) - 40;
            int leftCol3X = 20;

            this.lblUsageType.Location = new Point(W - 20 - this.lblUsageType.Width, 140);
            this.chkForSale.Location = new Point(rightCol3X + colWidth3 - this.chkForSale.Width, 172);
            this.chkForRental.Location = new Point(rightCol3X + colWidth3 - this.chkForSale.Width - this.chkForRental.Width - 15, 172);

            this.lblQuantity.Location = new Point(middleCol3X + colWidth3 - this.lblQuantity.Width, 140);
            this.txtQuantity.Location = new Point(middleCol3X, 170);
            this.txtQuantity.Size = new Size(colWidth3, 48);

            this.lblUnitPrice.Location = new Point(leftCol3X + colWidth3 - this.lblUnitPrice.Width, 140);
            this.txtUnitPrice.Location = new Point(leftCol3X, 170);
            this.txtUnitPrice.Size = new Size(colWidth3, 48);

            // ROW 3: (SellingPrice on Right, RentalRate in Middle, MinQuantity on Left)
            this.lblSellingPrice.Location = new Point(rightCol3X + colWidth3 - this.lblSellingPrice.Width, 230);
            this.txtSellingPrice.Location = new Point(rightCol3X, 260);
            this.txtSellingPrice.Size = new Size(colWidth3, 48);

            this.lblRentalRate.Location = new Point(middleCol3X + colWidth3 - this.lblRentalRate.Width, 230);
            this.txtRentalRate.Location = new Point(middleCol3X, 260);
            this.txtRentalRate.Size = new Size(colWidth3, 48);

            this.chkManualMinQty.Location = new Point(leftCol3X + colWidth3 - this.chkManualMinQty.Width, 230);
            this.txtMinQuantity.Location = new Point(leftCol3X, 260);
            this.txtMinQuantity.Size = new Size(colWidth3, 48);

            // ROW 5: Note Panel
            this.panelNote.Location = new Point(20, 415);
            this.panelNote.Size = new Size(W - 40, 80);

            // ROW 4: (CourtType on Right, Court on Left)
            this.lblCourtType.Location = new Point(W - 20 - this.lblCourtType.Width, 320);
            this.panelCourtType.Location = new Point(rightX, 350);
            this.panelCourtType.Size = new Size(colWidth, 48);
            this.cmbCourtType.Size = new Size(colWidth - 20, 31);

            this.lblCourt.Location = new Point(leftX + colWidth - this.lblCourt.Width, 320);
            this.panelCourt.Location = new Point(leftX, 350);
            this.panelCourt.Size = new Size(colWidth, 48);
            this.cmbCourt.Size = new Size(colWidth - 20, 31);
        }

        public void LoadData()
        {
            // CheckBoxes default: "للبيع" is checked, "للتأجير" is unchecked
            chkForSale.Checked = true;
            chkForRental.Checked = false;
            ApplyUsageTypeState();
            chkManualMinQty.Checked = false;
            ApplyMinQuantityState();

            LoadCategories();
            LoadCourtTypes();
            LoadCourts();
        }

        public void LoadCategories()
        {
            cmbCategory.Items.Clear();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT category_name FROM INVENTORY_CATEGORIES";
                    using (var cmd = new SqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbCategory.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch { }

            if (cmbCategory.Items.Count == 0)
            {
                cmbCategory.Items.Add("معدات رياضية");
                cmbCategory.Items.Add("مبيعات مقهى");
                cmbCategory.Items.Add("نظافة");
            }
            cmbCategory.SelectedIndex = 0;
        }

        private void LoadCourtTypes()
        {
            try
            {
                cmbCourtType.DataSource = null;
                cmbCourtType.Items.Clear();

                var list = new List<string>();
                list.Add("جميع أنواع الملاعب");
                foreach (var ct in CourtType.GetFakeData())
                {
                    list.Add(ct.TypeName);
                }

                cmbCourtType.DataSource = list;
                cmbCourtType.SelectedIndex = 0;
            }
            catch { }
        }

        private void LoadCourts()
        {
            try
            {
                string selectedType = cmbCourtType.Text;

                cmbCourt.DataSource = null;
                cmbCourt.Items.Clear();

                if (selectedType == "جميع أنواع الملاعب")
                {
                    cmbCourt.Items.Add("جميع الملاعب");
                    cmbCourt.SelectedIndex = 0;
                    panelCourt.Enabled = false;
                }
                else
                {
                    panelCourt.Enabled = true;

                    var list = new List<string>();
                    list.Add($"جميع ملاعب {selectedType}");

                    var courts = Court.GetAll()
                        .Where(c => c.SportType == selectedType)
                        .Select(c => c.CourtName)
                        .ToList();

                    list.AddRange(courts);

                    cmbCourt.DataSource = list;
                    cmbCourt.SelectedIndex = 0;
                }
            }
            catch { }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            using (var form = new Forms.DialogForms.AddCategoryForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadCategories();
                    cmbCategory.Text = form.AddedCategoryName;
                }
            }
        }
    }
}
