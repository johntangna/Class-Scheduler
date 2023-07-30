using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Class_Scheduler.Common.Models.DTOs
{
    [XmlType(TypeName = "User")]
    public class UserDTO
    {
        [XmlAttribute]
        public string UserName { get; set; }

        [XmlAttribute]
        public int Id { get; set; }

        [XmlAttribute]
        public string Password { get; set; }

        [XmlAttribute]
        public string SchoolName { get; set; }

        [XmlAttribute]
        public string Email { get; set; }
    }
}
