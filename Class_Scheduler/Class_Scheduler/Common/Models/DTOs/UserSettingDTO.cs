using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Class_Scheduler.Common.Models.DTOs
{
    [XmlType(TypeName = "UserSetting")]
    public class UserSettingDTO
    {
        [XmlElement]
        public UserDTO User { get; set; }

        [XmlAttribute]
        public string ImportDataPath { get; set; }

        [XmlAttribute]
        public int ClassDivisionBaseline { get; set; }

        [XmlAttribute]
        public int PopulationSize { get; set; }

        [XmlAttribute]
        public double MutationProb { get; set; }

    }
}
