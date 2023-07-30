using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Class_Scheduler.Common.Models.DTOs
{
    [XmlType(TypeName = "Teacher")]
    public class TeacherDTO
    {
        [XmlAttribute]
        public int Id { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string EmailAddress { get; set; }

        [XmlArray]
        public List<string> Subject { get; set; }

        [XmlArray]
        public List<TimeSlotDTO> BusyTimeSlots { get; set; }
    }
}
