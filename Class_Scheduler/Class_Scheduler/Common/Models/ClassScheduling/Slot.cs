using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Common.Models.ClassScheduling
{
    public class Slot : BindableBase
    {
        private ObservableCollection<ScheduledClass> scheduledClasses = new ObservableCollection<ScheduledClass>();

        public ObservableCollection<ScheduledClass> ScheduledClasses
        {
            get { return scheduledClasses; }
            set { scheduledClasses = value; RaisePropertyChanged(); }
        }

        private int weekday;

        public int Weekday
        {
            get { return weekday; }
            set { weekday = value; RaisePropertyChanged(); }
        }

        private int slot;

        public int SlotNum
        {
            get { return slot; }
            set { slot = value; RaisePropertyChanged(); }
        }
    }
}
