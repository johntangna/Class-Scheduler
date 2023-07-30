using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Class_Scheduler.Common.Models
{
    public abstract class UserBase : BindableBase
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
            set { name = value; RaisePropertyChanged(); }
        }

        public string Character
        {
            get
            {
                string[] str = Name.Split(' ');
                return str[str.Length - 1][0] + "";
            }
        }
    }
}
