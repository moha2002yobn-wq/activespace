using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using ActiveSpaceSystem.CustomItems;
using ActiveSpaceSystem.Models;
using ActiveSpace.Models;

namespace ActiveSpaceSystem.Forms.DialogForms
{
    public partial class DamagedGoodsDialog : Form
    {
        private Employee currentEmployee;
        private bool drag = false;
        private Point startPoint = new Point(0, 0);

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public DamagedGoodsDialog() : this(null) { }

        public DamagedGoodsDialog(Employee employee)
        {
            currentEmployee = employee;
            InitializeComponent();

            this.DoubleBuffered = true;

            // Apply modern smooth rounded corners to the form
            this.Load += (s, e) =>
            {
                this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 28, 28));
            };

            SetupEvents();
            LoadDamagedItems();
        }

        private void SetupEvents()
        {
            // Window dragging
            headerPanel.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    drag = true;
                    startPoint = new Point(e.X, e.Y);
                }
            };
            headerPanel.MouseMove += (s, e) =>
            {
                if (drag)
                {
                    Point p = PointToScreen(e.Location);
                    this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
                }
            };
            headerPanel.MouseUp += (s, e) => drag = false;

            // Custom paint exclamation point icon inside iconPanel
            iconPanel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, iconPanel.Width - 1, iconPanel.Height - 1);
                using (var brush = new SolidBrush(Color.FromArgb(239, 68, 68)))
                {
                    e.Graphics.FillEllipse(brush, rect);
                }
                using (var font = new Font("Tajawal", 15f, FontStyle.Bold))
                {
                    TextRenderer.DrawText(e.Graphics, "!", font, rect, Color.White,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
            };

            lblClose.MouseEnter += (s, e) => lblClose.ForeColor = Color.FromArgb(15, 23, 42);
            lblClose.MouseLeave += (s, e) => lblClose.ForeColor = Color.FromArgb(100, 116, 139);
            lblClose.Click += (s, e) => this.Close();

            // Set dynamic card width on resize
            listPanel.SizeChanged += (s, e) =>
            {
                foreach (Control ctrl in listPanel.Controls)
                {
                    ctrl.Width = listPanel.ClientSize.Width - listPanel.Padding.Horizontal - 6;
                }
            };
        }

        private void LoadDamagedItems()
        {
            listPanel.SuspendLayout();
            listPanel.Controls.Clear();

            try
            {
                var allItems = Inventory.GetInventoryItems();
                var damagedItems = allItems.Where(x => x.DamagedQuantity > 0).ToList();

                decimal totalLoss = 0;

                foreach (var item in damagedItems)
                {
                    var card = new DamagedItemControl
                    {
                        ProductRef = item.ProductRef,
                        ProductName = item.ProductName,
                        CategoryName = item.CategoryName,
                        DamagedQuantity = item.DamagedQuantity,
                        PurchasePrice = item.PurchasePrice,
                        Width = listPanel.ClientSize.Width - listPanel.Padding.Horizontal - 6
                    };

                    totalLoss += item.DamagedQuantity * item.PurchasePrice;

                    card.RemoveClicked += (s, e) =>
                    {
                        if (MessageBox.Show($"هل أنت متأكد من إزالة كمية التالف للصنف '{card.ProductName}' نهائياً من النظام؟",
                            "تأكيد إزالة التالف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                        {
                            try
                            {
                                Inventory.ClearDamagedQuantity(card.ProductRef, currentEmployee?.EmployeeID);
                                MessageBox.Show("تم إزالة كمية التالف وتحديث رصيد المخزون بنجاح.", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadDamagedItems(); // Reload
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("حدث خطأ أثناء إزالة التالف: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    };

                    card.ReportClicked += (s, e) =>
                    {
                        MessageBox.Show("سيتم تفعيل كود التبليغ لهذا الصنف قريباً.", "تبليغ البضائع التالفة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    };

                    listPanel.Controls.Add(card);
                }

                lblTotalValue.Text = $"{totalLoss:0.##} د.ل";
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البضائع التالفة: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            listPanel.ResumeLayout(true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 2))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}
