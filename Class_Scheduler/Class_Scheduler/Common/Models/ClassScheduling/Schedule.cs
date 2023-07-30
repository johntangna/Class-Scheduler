using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Common.Models.ClassScheduling
{
    public class Schedule : BindableBase
    {
        private ObservableCollection<Slot> slots = new ObservableCollection<Slot>();

        public ObservableCollection<Slot> Slots
        {
            get { return slots; }
            set { slots = value; RaisePropertyChanged(); }
        }

    }
}
