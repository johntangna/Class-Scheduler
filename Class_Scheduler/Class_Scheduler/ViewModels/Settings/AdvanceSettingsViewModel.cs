using Class_Scheduler.Service;
using ExcelDataReader;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.ViewModels.Settings
{
    public class AdvanceSettingsViewModel : BindableBase, ISavableSettings
    {
        private readonly IDialogService dialogService;
        private readonly ISettingService settingService;

        private string importedDocPath;
        private int classDivisionBaseline;
        private int populationSize;
        private double mutationProb;

        public DelegateCommand ImportDataCommand { get; private set; }
        public string ImportedDocPath 
        {
            get { return importedDocPath; }
            set { importedDocPath = value; RaisePropertyChanged(); }
        }

        public int ClassDivisionBaseline
        {
            get { return classDivisionBaseline; }
            set { classDivisionBaseline = value; RaisePropertyChanged(); }
        }

        public int PopulationSize
        {
            get { return populationSize; }
            set { populationSize = value; RaisePropertyChanged(); }
        }

        public double MutationProb
        {
            get { return mutationProb; }
            set { mutationProb = value; RaisePropertyChanged(); }
        }


        public AdvanceSettingsViewModel(IDialogService dialogService, ISettingService settingService) 
        {
            this.dialogService = dialogService;
            this.settingService = settingService;

            ImportDataCommand = new DelegateCommand(ImportData);

            settingService.RegisterSettingInstance(this);
            ClassDivisionBaseline = settingService.UserSetting.ClassDivisionBaseline;
            PopulationSize = settingService.UserSetting.PopulationSize;
            MutationProb = settingService.UserSetting.MutationProb;
        }

        private void ImportData()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Customized File|*.xlsx|*.xls|Excel Workbook";
            if (openFileDialog.ShowDialog() == true)
            {
                ImportedDocPath = openFileDialog.FileName;
            }
        }

        public void OnSave()
        {
            settingService.RegisterData("ImportDataPath", ImportedDocPath);
            settingService.RegisterData("ClassDivisionBaseline", ClassDivisionBaseline);
            settingService.RegisterData("PopulationSize", PopulationSize);
            settingService.RegisterData("MutationProb", MutationProb);
        }
    }
}
