using System;
using System.Windows.Forms;

namespace ActiveSpaceSystem.CustomItems
{
    public partial class DamagedItemControl : UserControl
    {
        public string ProductRef { get; set; } = string.Empty;
        
        public string ProductName
        {
            get => lblName.Text;
            set => lblName.Text = value;
        }

        public string CategoryName
        {
            get => lblCategory.Text;
            set => lblCategory.Text = value;
        }

        private int _damagedQuantity;
        public int DamagedQuantity
        {
            get => _damagedQuantity;
            set
            {
                _damagedQuantity = value;
                lblQtyValue.Text = value.ToString();
                UpdateLoss();
            }
        }

        private decimal _purchasePrice;
        public decimal PurchasePrice
        {
            get => _purchasePrice;
            set
            {
                _purchasePrice = value;
                UpdateLoss();
            }
        }

        private void UpdateLoss()
        {
            decimal loss = _damagedQuantity * _purchasePrice;
            lblLossValue.Text = $"{loss:0.##} د.ل";
        }

        public event EventHandler ReportClicked;
        public event EventHandler RemoveClicked;

        public DamagedItemControl()
        {
            InitializeComponent();
            SetupEvents();
        }

        private void SetupEvents()
        {
            btnReport.Click += (s, e) => ReportClicked?.Invoke(this, EventArgs.Empty);
            btnRemove.Click += (s, e) => RemoveClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
