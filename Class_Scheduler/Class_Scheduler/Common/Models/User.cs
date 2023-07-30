using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Class_Scheduler.Common.Models
{
    public class User
    {
        public string UserName { get; set; }

        public int Id { get; set; }

        public string Password { get; set; }

        public string SchoolName { get; set; }

        public string Email { get; set; }
    }
}
