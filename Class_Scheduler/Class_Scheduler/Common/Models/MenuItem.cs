using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Common.Models
{
    public class MenuItem : BindableBase
    {
        private string icon;

        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string navigatedTarget;

        public string NavigatedTarget
        {
            get { return navigatedTarget; }
            set { navigatedTarget = value; }
        }
    }
}
