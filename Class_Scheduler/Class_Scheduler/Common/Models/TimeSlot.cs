using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Class_Scheduler.Common.Models
{
    public class TimeSlot
    {
        public int Weekday { get; set; }

        public int Slot { get; set; }
    }
}
