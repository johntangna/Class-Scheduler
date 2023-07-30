using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Class_Scheduler.Common.Models.DTOs
{
    [XmlType(TypeName = "TimeSlot")]
    public class TimeSlotDTO
    {
        [XmlAttribute]
        public int Weekday { get; set; }

        [XmlAttribute]
        public int Slot { get; set; }
    }
}
