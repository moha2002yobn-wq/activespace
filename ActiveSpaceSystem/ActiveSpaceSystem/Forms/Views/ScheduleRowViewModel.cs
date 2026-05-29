using ActiveSpace.Models;
using ActiveSpaceSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ActiveSpaceSystem.Forms.Views
{
    public class ScheduleRowViewModel
    {
        public string CourtID { get; set; }
        public string CourtName { get; set; }

        public Dictionary<string, string> HourlySlots { get; set; } = new Dictionary<string, string>();

        public static ScheduleRowViewModel BuildRow(Court court, DateTime targetDate)
        {
            var viewModel = new ScheduleRowViewModel
            {
                CourtID = court.CourtID,
                CourtName = court.CourtName
            };

            // جلب حجوزات هذا الملعب في اليوم المحدد من قاعدة البيانات
            var dayBookings = Booking.GetAll()
                .Where(b => b.CourtName == court.CourtName && b.BookingDate.Date == targetDate.Date)
                .ToList();

            for (int hour = 8; hour <= 23; hour++)
            {
                string colName = $"h{hour}";
                TimeSpan slotStart = new TimeSpan(hour, 0, 0);
                TimeSpan slotEnd = new TimeSpan(hour, 59, 59);

                TimeSpan actualClose = (court.CloseTime == TimeSpan.Zero) ? new TimeSpan(23, 59, 59) : court.CloseTime;

                if (slotStart < court.OpenTime || slotStart >= actualClose)
                {
                    viewModel.HourlySlots.Add(colName, "خارج وقت العمل");
                }
                else
                {
                    var booking = dayBookings.FirstOrDefault(b => (slotStart < b.EndTime && slotEnd > b.StartTime));
                    if (booking != null)
                    {
                        viewModel.HourlySlots.Add(colName, $"محجوز|{booking.Customer?.FullName ?? "عميل"}");
                    }
                    else
                    {
                        viewModel.HourlySlots.Add(colName, "متاح");
                    }
                }
            }

            return viewModel;
        }
    }
}