using ActiveSpace.Models;
using ActiveSpaceSystem.Models.enums;
using System.Linq;
using System;

namespace ActiveSpaceSystem.Forms.Views
{
    public class ContractViewModel
    {
        public string ContractID { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string CourtName { get; set; }
        public string DayOfWeek { get; set; }
        public string TimeSlot { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }

        public static ContractViewModel FromContract(MonthlyContract mc)
        {
            return new ContractViewModel
            {
                ContractID = mc.ContractRef,
                CustomerName = mc.Customer?.FullName ?? "غير معروف",
                PhoneNumber = mc.Customer?.Phone ?? "غير معروف",
                CourtName = mc.CourtName ?? "غير معروف",
                DayOfWeek = GetArabicDay(mc.DayOfWeek),
                TimeSlot = $"{mc.FixedStartTime:hh\\:mm} - {mc.FixedEndTime:hh\\:mm}",
                StartDate = mc.StartDate.ToString("yyyy-MM-dd"),
                EndDate = mc.EndDate.ToString("yyyy-MM-dd"),
                Amount = (double)mc.MonthlyValue,
                Status = mc.Status.ToString()
            };
        }

        private static string GetArabicDay(string englishDay)
        {
            var days = new System.Collections.Generic.Dictionary<string, string> {
                {"Saturday", "السبت"}, {"Sunday", "الأحد"}, {"Monday", "الاثنين"},
                {"Tuesday", "الثلاثاء"}, {"Wednesday", "الأربعاء"}, {"Thursday", "الخميس"}, {"Friday", "الجمعة"}
            };
            return days.ContainsKey(englishDay) ? days[englishDay] : englishDay;
        }
    }
}