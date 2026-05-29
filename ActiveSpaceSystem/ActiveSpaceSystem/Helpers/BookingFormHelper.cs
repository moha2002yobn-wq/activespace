using ActiveSpace.Models;
using ActiveSpaceSystem.Data;
using System;
using System.Linq;

namespace ActiveSpaceSystem.Helpers
{
    public static class BookingFormHelper
    {
        public static bool IsDateTimeInPast(DateTime date, TimeSpan start, out string warningMessage)
        {
            warningMessage = string.Empty;
            DateTime now = DateTime.Now;

            if (date.Date < now.Date)
            {
                warningMessage = "لا يمكن حجز موعد في تاريخ قد مضى. يرجى اختيار تاريخ اليوم أو تاريخ مستقبلي.";
                return true;
            }

            if (date.Date == now.Date)
            {
                DateTime bookingStartDateTime = date.Date.Add(start);

                if (bookingStartDateTime < now)
                {
                    string currentTimeStr = now.ToString(@"HH:mm");
                    warningMessage = $"الوقت المختار قد مضى! نحن الآن في الساعة {currentTimeStr}. يرجى اختيار وقت مستقبلي.";
                    return true;
                }
            }

            return false;
        }

        public static bool IsCourtReserved(Court court, DateTime date, TimeSpan start, TimeSpan end, out string warningMessage)
        {
            warningMessage = string.Empty;

            if (start >= end)
            {
                warningMessage = "تنبيه: وقت بداية الحجز يجب أن يكون قبل وقت النهاية.";
                return true;
            }

            if (IsDateTimeInPast(date, start, out string pastWarning))
            {
                warningMessage = pastWarning;
                return true;
            }

            TimeSpan courtOpen = court.OpenTime;
            TimeSpan courtClose = court.CloseTime;

            if (courtClose <= courtOpen)
            {
                courtClose = courtClose.Add(TimeSpan.FromHours(24));
            }

            TimeSpan adjustedEnd = end;
            if (adjustedEnd <= start)
            {
                adjustedEnd = adjustedEnd.Add(TimeSpan.FromHours(24));
            }

            if (start < courtOpen || adjustedEnd > courtClose)
            {
                string openStr = court.OpenTime.ToString(@"hh\:mm");
                string closeStr = court.CloseTime.ToString(@"hh\:mm");

                warningMessage = $"خارع أوقات العمل! هذا الملعب ({court.CourtName}) " +
                                 $"يستقبل الحجوزات فقط من الساعة {openStr} صباحاً حتى الساعة {closeStr} مساءً.";
                return true;
            }

            // Fetch from database
            bool isReserved = Booking.GetAll().Any(b =>
                b.CourtName == court.CourtName &&
                b.BookingDate.Date == date.Date &&
                start < b.EndTime &&
                end > b.StartTime
            );

            if (isReserved)
            {
                warningMessage = "هذا الملعب محجوز بالفعل في الفترة الزمنية المحددة. الرجاء اختيار وقت آخر.";
            }

            return isReserved;
        }

        public static bool TryValidateFinancials(double totalAmount, double deposit, out string warningMessage)
        {
            warningMessage = string.Empty;

            if (deposit <= 0)
            {
                warningMessage = "قيمة العربون غير مقبولة، يجب دفع قيمة أكبر من الصفر لتأكيد الحجز.";
                return false;
            }

            if (deposit > totalAmount)
            {
                warningMessage = "لا يمكن أن تكون قيمة العربون أكبر من قيمة المبلغ الإجمالي للحجز.";
                return false;
            }

            return true;
        }
    }
}