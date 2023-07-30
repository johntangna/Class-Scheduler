using Class_Scheduler.Extensions;
using Class_Scheduler.Service;
using Class_Scheduler.Views.Settings;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Class_Scheduler.ViewModels
{
    public class SettingViewModel : BindableBase, IDialogAware
    {
        private IRegionManager regionManager;
        private readonly ISettingService settingService;
        private readonly IRepositoryService repositoryService;
            
        public IRegionManager RegionManager
        {
            get { return regionManager; }
            set { SetProperty(ref regionManager, value); } 
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand CloseCommand { get; private set; }
        public DelegateCommand CancelCommand {  get; private set; }
        public DelegateCommand SaveCommand { get; private set; }

        public string Title => "";

        public event Action<IDialogResult> RequestClose;

        public SettingViewModel(IRegionManager regionManager, ISettingService settingService, IRepositoryService repositoryService)
        {
            this.regionManager = regionManager;
            this.settingService = settingService;
            this.repositoryService = repositoryService;

            NavigateCommand = new DelegateCommand<string>(OnNavigate);
            CloseCommand = new DelegateCommand(OnDialogClosed);
            CancelCommand = new DelegateCommand(OnCancel);
            SaveCommand = new DelegateCommand(OnSave);
            this.repositoryService = repositoryService;
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            RegionManager.Regions.Remove(PrismManager.SettingViewRegionName);
            RequestClose?.Invoke(new DialogResult(ButtonResult.Abort));
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }

        public void OnNavigate(string target)
        {
            regionManager.Regions[PrismManager.SettingViewRegionName].RequestNavigate(target);
        }

        public void OnCancel()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }

        public void OnSave()
        {
            settingService.Save();
            repositoryService.UserSetting = settingService.UserSetting;
            repositoryService.SaveUserSetting();

            DialogParameters keys = new DialogParameters();
            keys.Add("UserSetting", settingService.UserSetting);
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, keys));
        }
    }
}
