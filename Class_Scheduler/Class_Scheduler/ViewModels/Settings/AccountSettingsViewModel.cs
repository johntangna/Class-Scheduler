using Class_Scheduler.Common.Models;
using Class_Scheduler.Service;
using Class_Scheduler.ViewModels.Settings;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.ViewModels
{
    public class AccountSettingsViewModel : BindableBase, ISavableSettings
    {
        private readonly IRepositoryService repositoryService;
        private readonly ISettingService settingService;

        public User User { get; set; }

        public AccountSettingsViewModel(IRepositoryService repositoryService, ISettingService settingService) 
        {
            this.repositoryService = repositoryService;
            this.settingService = settingService;

            User = new User();
            User.SchoolName = "Shangde";
            User.UserName = "Zhiyu Zhang";
            User.Password = "123456789";
            User.Email = "3314337281@qq.com";

            settingService.RegisterSettingInstance(this);
        }

        public void OnSave()
        {
            
        }
    }
}
