using Class_Scheduler.Common.Models;
using Class_Scheduler.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Service
{
    public interface ISettingService
    {
        UserSetting UserSetting { get; set; }
        void RegisterData<T>(string MemberName, T value);

        void RegisterSettingInstance(ISavableSettings savableSettings);

        void Save();
    }
}
