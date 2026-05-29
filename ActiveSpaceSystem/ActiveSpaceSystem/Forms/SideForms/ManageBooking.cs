using ActiveSpace.Models;
using ActiveSpaceSystem.CustomItems;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Forms.DialogForms;
using ActiveSpaceSystem.Forms.GridStyle;
using ActiveSpaceSystem.Forms.Views;
using ActiveSpaceSystem.Models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.SideForms
{
    public partial class ManageBooking : Form
    {
        private BindingList<BookingViewModel> bookingsList;
        private ImageList actionImageList;
        private BookingGridRenderer gridRenderer;
        private Employee currentUser;

        public ManageBooking(Employee user)
        {
            InitializeComponent();
            this.TopLevel = false;
            InitializeActionImages();
            SetupGrid();
            this.Load += ManageBooking_Load;
            currentUser = user;
        }

        private void InitializeActionImages()
        {
            actionImageList = new ImageList();
            actionImageList.ImageSize = new Size(32, 32);
            actionImageList.ColorDepth = ColorDepth.Depth32Bit;
            gridRenderer = new BookingGridRenderer(actionImageList);

            try
            {
                var assembly = typeof(ManageBooking).Assembly;

                using (var editStream = assembly.GetManifestResourceStream("ActiveSpaceSystem.Resources.icons8-edit-48.png"))
                {
                    if (editStream != null)
                    {
                        var editImage = Image.FromStream(editStream);
                        actionImageList.Images.Add("edit", editImage);
                    }
                }

                using (var deleteStream = assembly.GetManifestResourceStream("ActiveSpaceSystem.Resources.icons8-delete-48.png"))
                {
                    if (deleteStream != null)
                    {
                        var deleteImage = Image.FromStream(deleteStream);
                        actionImageList.Images.Add("delete", deleteImage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطاء في تحميل الصور", "تحدير", MessageBoxButtons.OK);
            }
        }

        private void SetupGrid()
        {
            dgvBookings.DataSource = null;
            dgvBookings.Rows.Clear();

            dgvBookings.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvBookings.EditMode = DataGridViewEditMode.EditProgrammatically;

            dgvBookings.CellPainting += DgvBookings_CellPainting;
            dgvBookings.CellClick += DgvBookings_CellClick;
            AddColumns();
        }

        private void AddColumns()
        {
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerName",
                HeaderText = "اسم العميل",
                Name = "CustomerName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True }
            });

            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "رقم الهاتف",
                Width = 110
            });

            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Court",
                HeaderText = "الملعب",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True }
            });

            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Date",
                HeaderText = "التاريخ",
                Width = 95
            });

            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Time",
                HeaderText = "الوقت",
                Width = 120
            });

            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Amount",
                HeaderText = "المبلغ",
                Width = 80
            });

            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "الحالة",
                Name = "Status",
                Width = 130
            });

            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Actions",
                HeaderText = "الإجراءات",
                Width = 120
            });
        }

        private void ManageBooking_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvBookings.ClearSelection();
        }

        public void LoadData()
        {
            var dateToday = dtpManageBooking.Value.Date;

            // جلب الحجوزات لليوم المحدد من قاعدة البيانات
            var bookings = Booking.GetAll()
                .Where(d => d.BookingDate.Date == dateToday)
                .ToList();

            // تحويل الحجوزات إلى ViewModels
            var viewModels = bookings.Select(BookingViewModel.FromBooking).ToList();

            bookingsList = new BindingList<BookingViewModel>(viewModels);
            dgvBookings.DataSource = bookingsList;

            if (dgvBookings.Columns["BookingID"] != null)
            {
                dgvBookings.Columns["BookingID"].Visible = false;
            }
        }

        private void DgvBookings_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvBookings.Columns[e.ColumnIndex].Name == "Status")
            {
                BookingStatus status = (BookingStatus)e.Value;
                gridRenderer.RenderStatusCell(e, status);
            }
            else if (dgvBookings.Columns[e.ColumnIndex].Name == "Actions")
            {
                gridRenderer.RenderActionsCell(e);
            }
        }

        private void DgvBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvBookings.Columns[e.ColumnIndex].Name == "Actions")
            {
                var item = dgvBookings.Rows[e.RowIndex].DataBoundItem as BookingViewModel;
                if (item == null)
                    return;

                var cellRect = dgvBookings.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var mousePos = dgvBookings.PointToClient(Cursor.Position);
                int relativeX = mousePos.X - cellRect.X;

                var (isEdit, isDelete) = gridRenderer.GetClickedButton(cellRect, relativeX);

                if (isEdit)
                    HandleEditClick(e.RowIndex);
                else if (isDelete)
                    HandleDeleteClick(e.RowIndex);
            }
        }

        private void HandleEditClick(int rowIndex)
        {
            if (currentUser.Role != UserRole.Admin)
            {
                MessageBox.Show("عذرًا، لا تمتلك صلاحية تعديل الحجوزات.", "صلاحيات غير كافية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rowIndex < 0 || rowIndex >= bookingsList.Count)
                return;

            var item = dgvBookings.Rows[rowIndex].DataBoundItem as BookingViewModel;
            if (item == null) return;

            // فتح واجهة التعديل وإرسال بيانات الحجز إليها
            using (var frm = new AddBookingForm(item))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadData();
                    dgvBookings.ClearSelection();
                }
            }
        }

        private void HandleDeleteClick(int rowIndex)
        {
            if (currentUser.Role != UserRole.Admin)
            {
                MessageBox.Show("عذرًا، لا تمتلك صلاحية حذف الحجوزات.", "صلاحيات غير كافية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("هل أنت متأكد من حذف هذا الحجز؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (rowIndex >= 0 && rowIndex < bookingsList.Count)
                {
                    string bookingId = bookingsList[rowIndex].BookingID;

                    // حذف الحجز والمدفوعات المتعلقة به من قاعدة البيانات
                    Booking.Delete(bookingId);

                    // تحديث القائمة المحلية للـ Grid الحالي
                    bookingsList.RemoveAt(rowIndex);

                    // تحديث واجهة العملاء إذا كانت مفتوحة
                    NotifyCustomerFormUpdate();
                }
            }
        }

        private void NotifyCustomerFormUpdate()
        {
            var customerForm = Application.OpenForms.OfType<MangeCustomers>().FirstOrDefault();
            if (customerForm != null)
            {
                customerForm.LoadData();
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            AddBookingForm frm = new AddBookingForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                dgvBookings.ClearSelection();
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtsearch.Texts.Trim().ToLower();

            if (searchTerm.Length == 10)
            {
                var filteredData = Booking.GetAll()
                    .Where(b => b.Customer.Phone.Contains(searchTerm))
                    .Select(BookingViewModel.FromBooking)
                    .ToList();
                bookingsList = new BindingList<BookingViewModel>(filteredData);
                dgvBookings.DataSource = bookingsList;
            }
            else
            {
                DateTime selectedDate = dtpManageBooking.Value.Date;
                var filteredData = Booking.GetAll()
                    .Where(b => b.Customer.Phone.Contains(searchTerm) && b.BookingDate.Date == selectedDate)
                    .Select(BookingViewModel.FromBooking)
                    .ToList();
                bookingsList = new BindingList<BookingViewModel>(filteredData);
                dgvBookings.DataSource = bookingsList;
            }
        }

        private void btnBackDate_Click(object sender, EventArgs e)
        {
            dtpManageBooking.Value = dtpManageBooking.Value.AddDays(-1);
        }

        private void btnForwardDate_Click(object sender, EventArgs e)
        {
            dtpManageBooking.Value = dtpManageBooking.Value.AddDays(1);
        }

        private void dtpManageBooking_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpManageBooking.Value.Date;
            string searchTerm = txtsearch.Texts.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                var dailyData = Booking.GetAll()
                    .Where(b => b.BookingDate.Date == selectedDate)
                    .Select(BookingViewModel.FromBooking)
                    .ToList();

                UpdateGrid(dailyData);
            }
            else
            {
                var filteredData = Booking.GetAll()
                    .Where(b => b.Customer.Phone.Contains(searchTerm) && b.BookingDate.Date == selectedDate)
                    .Select(BookingViewModel.FromBooking)
                    .ToList();

                UpdateGrid(filteredData);
            }
        }

        private void UpdateGrid(List<BookingViewModel> data)
        {
            bookingsList = new BindingList<BookingViewModel>(data);
            dgvBookings.DataSource = bookingsList;
        }
    }
}
