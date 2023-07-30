using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Service
{
    public class DialogSettingService : BindableBase, IDialogSettingService
    {
        private double dialogHeight;

        public double DialogHeight
        {
            get { return dialogHeight; }
            set { dialogHeight = value; RaisePropertyChanged(); }
        }

        private double dialogWidth;

        public double DialogWidth 
        { 
            get { return dialogWidth; } 
            set { dialogWidth = value; RaisePropertyChanged(); } 
        }

        public DialogSettingService()
        {
            DialogHeight = App.Current.MainWindow.ActualWidth;
            DialogWidth = App.Current.MainWindow.ActualHeight;
        }
    }
}
