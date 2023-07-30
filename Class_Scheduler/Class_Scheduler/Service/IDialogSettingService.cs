using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Service
{
    public interface IDialogSettingService
    {
        double DialogHeight { get; set; }
        double DialogWidth { get; set; }
    }
}
