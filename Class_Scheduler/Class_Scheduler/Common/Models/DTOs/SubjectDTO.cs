using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Class_Scheduler.Common.Models.DTOs
{
    [XmlType(TypeName = "Subject")]
    public class SubjectDTO
    {
        [XmlAttribute]
        public int Id { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string TeacherNames { get; set; }

        [XmlArray]
        public List<TeacherDTO> TeachersList { get; set; }

        [XmlAttribute]
        public string SubjectGroup { get; set; }

        [XmlAttribute]
        public int CountPerWeek { get; set; } 
    }
}
