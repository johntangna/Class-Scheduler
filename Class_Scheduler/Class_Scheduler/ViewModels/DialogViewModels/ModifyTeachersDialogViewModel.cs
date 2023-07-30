using Class_Scheduler.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.ViewModels.DialogViewModels
{
    public class ModifyTeachersDialogViewModel : BindableBase, IDialogAware
    {
        public string Title => "Modify teacher's data";

        public event Action<IDialogResult> RequestClose;

        public Teacher Teacher { get; set; }

        public DelegateCommand SubmitCommand { get; private set; }

        public DelegateCommand CancelCommand { get; private set; }

        public ModifyTeachersDialogViewModel() 
        {
            SubmitCommand = new DelegateCommand(SubmitData);
            CancelCommand = new DelegateCommand(Cancel);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Teacher = parameters.GetValue<Teacher>("Teacher");
        }

        private void SubmitData()
        {
            DialogParameters keys = new DialogParameters
            {
                { "Teacher", Teacher }
            };
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, keys));
        }

        private void Cancel()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }
    }
}
