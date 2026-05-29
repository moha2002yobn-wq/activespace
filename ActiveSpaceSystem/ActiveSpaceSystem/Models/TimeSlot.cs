using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveSpaceSystem.Models
{
    public class TimeSlot
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public bool IsBooked { get; set; }
        public string CustomerName { get; set; } = string.Empty;
    }
}
