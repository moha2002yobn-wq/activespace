using ActiveSpace.Models;
using ActiveSpaceSystem.Models.enums;
using System;
using System.Linq;

namespace ActiveSpaceSystem.Forms.Views
{
    public class PaymentViewModel
    {
        public string BookingID { get; set; }
        public string CustomerName { get; set; }
        public string BookingDate { get; set; }
        public double TotalAmount { get; set; }
        public double PaidAmount { get; set; }
        public double Remaining { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime PaidAt { get; set; }
        public Booking Booking { get; set; } = new Booking();

        public static PaymentViewModel FromBooking(Payment p)
        {
            if (p.ContractRef != null)
            {
                var mc = MonthlyContract.GetByRef(p.ContractRef);
                double remaining = Payment.CalculateRemainingForContract(p.ContractRef);
                double contractTotal = mc != null ? (double)mc.MonthlyValue : 0;
                double contractPaid = contractTotal - remaining;

                return new PaymentViewModel
                {
                    BookingID = mc?.ContractRef ?? string.Empty,
                    CustomerName = mc?.Customer?.FullName ?? "غير معروف",
                    BookingDate = mc?.StartDate.ToString("yyyy-MM-dd") ?? "",
                    TotalAmount = contractTotal,
                    PaidAmount = contractPaid,
                    Remaining = remaining,
                    Status = (remaining <= 0) ? BookingStatus.Completed : BookingStatus.Confirmed,
                    PaidAt = p.PaidAt,
                    Booking = new Booking
                    {
                        BookingRef = mc?.ContractRef ?? string.Empty,
                        CustomerPhoneNumber = mc?.CustomerPhoneNumber ?? string.Empty,
                        CourtName = mc?.CourtName ?? string.Empty,
                        BookingDate = mc?.StartDate ?? DateTime.Today,
                        Price = mc?.MonthlyValue ?? 0,
                        Status = (remaining <= 0) ? BookingStatus.Completed : BookingStatus.Confirmed
                    }
                };
            }

            var b = p.Booking;

            // حساب إجمالي المدفوعات من قاعدة البيانات
            double paid = b != null ? Payment.CalculateRemaining(b.BookingRef) : 0;
            double totalAmt = b?.TotalAmount ?? 0;
            // Remaining from the helper returns (price - paid), so paid = totalAmt - remaining
            double actualPaid = totalAmt - paid;

            return new PaymentViewModel
            {
                BookingID = b?.BookingID ?? string.Empty,
                CustomerName = b?.Customer?.FullName ?? "غير معروف",
                BookingDate = b?.BookingDate.ToString("yyyy-MM-dd") ?? "",
                TotalAmount = totalAmt,
                PaidAmount = actualPaid,
                Remaining = paid,
                Status = b?.Status ?? BookingStatus.Confirmed,
                PaidAt = p.PaidAt,
                Booking = b ?? new Booking()
            };
        }
    }
}