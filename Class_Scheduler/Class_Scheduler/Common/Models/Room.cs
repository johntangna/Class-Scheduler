using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Common.Models
{
    public class Room
    {
        private int id;
        
        public int Id 
        { 
            get { return id; } 
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string purpose;

        public string Purpose
        {
            get { return purpose; }
            set { purpose = value; }
        }

        private int ownerId;
        
        public int OwnerId
        {
            get { return ownerId; }
            set { ownerId = value; }
        }
    }
}
