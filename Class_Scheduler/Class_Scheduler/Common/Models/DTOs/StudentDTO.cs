using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Class_Scheduler.Common.Models.DTOs
{
    [XmlType(TypeName = "Student")]
    public class StudentDTO
    {
        [XmlAttribute]
        public int Id { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string GradeAndClass { get; set; }

        [XmlAttribute]
        public string Sex { get; set; }

        [XmlAttribute]
        public string EmailAddress { get; set; }

        [XmlArray()]
        public List<int> SubjectScores { get; set; }

        [XmlArray()]
        public List<string> SubjectSelected { get; set; }
    }
}
