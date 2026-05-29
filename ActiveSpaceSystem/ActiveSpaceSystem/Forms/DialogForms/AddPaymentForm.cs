using ActiveSpace.Models;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Helpers;
using ActiveSpaceSystem.Models.enums;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.DialogForms
{
    public partial class AddPaymentForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteObject(IntPtr hObject);

        private IntPtr _formRegionHandle;

        public AddPaymentForm()
        {
            InitializeComponent();
        }

        private void AddPaymentForm_Load(object sender, EventArgs e)
        {
            _formRegionHandle = CreateRoundRectRgn(0, 0, Width, Height, 30, 30);
            this.Region = System.Drawing.Region.FromHrgn(_formRegionHandle);
        }

        private void AddPaymentForm_Paint(object sender, PaintEventArgs e)
        {
            int lineY = 65;
            using (Pen linePen = new Pen(Color.FromArgb(229, 231, 235), 2))
            {
                e.Graphics.DrawLine(linePen, 0, lineY, this.Width, lineY);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string rawBookingValue = bookingInfoCard1.BookingNumberValue;
            bool isContract = rawBookingValue.StartsWith("MC-");

            if (isContract)
            {
                string contractRef = rawBookingValue.Substring(3); // Remove "MC-" prefix
                var contract = MonthlyContract.GetByRef(contractRef);
                if (contract == null)
                {
                    ShowWarning("عفواً، لم يتم العثور على بيانات هذا العقد.");
                    return;
                }

                if (!ValidationHelper.IsValidDecimalValue(abdulTextBox1.Texts, "القيمة المدفوعة", out double paid, out string depositError))
                {
                    ShowWarning(depositError);
                    return;
                }

                if (paid <= 0)
                {
                    ShowWarning("يرجى إدخال قيمة دفع أكبر من الصفر.");
                    return;
                }

                double remainingAmount = Payment.CalculateRemainingForContract(contract.ContractRef);
                if (paid > remainingAmount)
                {
                    ShowWarning($"القيمة المدخلة ({paid} د.ل) أكبر من المبلغ المتبقي المطلوب للعقد ({remainingAmount} د.ل).");
                    return;
                }

                // Create and save payment
                var payment = new Payment
                {
                    AmountPaid = paid,
                    PaidAt = DateTime.Now,
                    ContractRef = contract.ContractRef,
                    CustomerPhoneNumber = contract.CustomerPhoneNumber
                };
                payment.Save();

                // Update contract payment status
                double currentRemaining = Payment.CalculateRemainingForContract(contract.ContractRef);
                contract.PaymentStatus = (currentRemaining <= 0) ? "مدفوع" : "معلق";
                contract.Save();

                ShowInfo("تمت إضافة الدفعة وتحديث الحالة المالية للعقد بنجاح.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Search by full ref, or try stripping "B-" if present
                var booking = Booking.GetByRef(rawBookingValue);
                if (booking == null && rawBookingValue.StartsWith("B-"))
                {
                    booking = Booking.GetByRef(rawBookingValue.Substring(2));
                }

                if (booking == null)
                {
                    ShowWarning("عفواً، لم يتم العثور على بيانات هذا الحجز أو العقد.");
                    return;
                }

                if (!ValidationHelper.IsValidDecimalValue(abdulTextBox1.Texts, "القيمة المدفوعة", out double paid, out string depositError))
                {
                    ShowWarning(depositError);
                    return;
                }

                if (paid <= 0)
                {
                    ShowWarning("يرجى إدخال قيمة دفع أكبر من الصفر.");
                    return;
                }

                double remainingAmount = Payment.CalculateRemaining(booking.BookingRef);
                if (paid > remainingAmount)
                {
                    ShowWarning($"القيمة المدخلة ({paid} د.ل) أكبر من المبلغ المتبقي المطلوب للحجز ({remainingAmount} د.ل).");
                    return;
                }

                // Create and save payment
                var payment = new Payment
                {
                    AmountPaid = paid,
                    PaidAt = DateTime.Now,
                    BookingID = booking.BookingRef,
                    Booking = booking
                };
                payment.Save();

                // Update booking status if fully paid
                double currentRemaining = Payment.CalculateRemaining(booking.BookingRef);
                if (currentRemaining <= 0)
                {
                    booking.Status = BookingStatus.Completed;
                }
                else
                {
                    booking.Status = BookingStatus.Confirmed;
                }
                booking.Save();

                ShowInfo("تمت إضافة الدفعة وتحديث الحالة المالية للحجز بنجاح.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (_formRegionHandle != IntPtr.Zero)
            {
                DeleteObject(_formRegionHandle);
            }
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowInfo(string message)
        {
            MessageBox.Show(message, "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SetBookingData(string bookingId, string remainingAmount)
        {
            if (bookingId.StartsWith("MC-"))
            {
                bookingInfoCard1.BookingNumberValue = bookingId;
            }
            else
            {
                bookingInfoCard1.BookingNumberValue = bookingId.StartsWith("B-") ? bookingId : $"B-{bookingId}";
            }
            bookingInfoCard1.RemainingAmountValue = remainingAmount;
            abdulTextBox1.Texts = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}