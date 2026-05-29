using ActiveSpace.Models;
using System;
using System.Linq;

namespace ActiveSpaceSystem.Forms.Views
{
    public class CustomerViewModel
    {
        public string CustomerId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public double TotalDebt { get; set; }
        public int NoShowCount { get; set; }
        public string LastBookingDate { get; set; }


        public static CustomerViewModel FromCustomer(Customer c)
        {
            string lastBooking = "2023-10-15";

            return new CustomerViewModel
            {
                // هذا هو السطر الناقص الذي سيحل كل المشكلة
                CustomerId = c.CustomerID,

                FullName = c.FullName,
                Phone = c.Phone,
                TotalDebt = c.TotalDebt,
                LastBookingDate = lastBooking,
                // أضف هذه أيضاً إذا كنت تحتاجها في الجدول
                NoShowCount = 0
            };
        }
    }
}
