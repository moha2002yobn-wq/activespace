using ActiveSpace.Models;
using ActiveSpaceSystem.Models.enums;
using System.Linq;

namespace ActiveSpaceSystem.Forms.Views
{
    public class BookingViewModel
    {
        public string BookingID { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Court { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public double Amount { get; set; }
        public BookingStatus Status { get; set; }

        public static BookingViewModel FromBooking(Booking b)
        {
            return new BookingViewModel
            {
                BookingID = b.BookingID,
                CustomerName = b.Customer?.FullName ?? "غير معروف",
                Phone = b.Customer?.Phone ?? "غير معروف",
                Court = b.Court?.CourtName ?? "غير معروف",
                Date = b.BookingDate.ToString("yyyy-MM-dd"),
                Time = $"{b.StartTime:hh\\:mm} - {b.EndTime:hh\\:mm}",
                Amount = b.TotalAmount,
                Status = b.Status
            };
        }
    }
}