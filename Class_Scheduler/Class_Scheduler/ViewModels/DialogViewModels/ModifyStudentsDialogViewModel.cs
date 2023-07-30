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
    public class ModifyStudentsDialogViewModel : BindableBase, IDialogAware
    {
        public string Title => "Modify student's data";

        public event Action<IDialogResult> RequestClose;

        public Student Student { get; set; }
        public Student InputStd { get; set; }

        public string[] Sexes { get; set; }

        public DelegateCommand SubmitCommand { get; private set; }

        public DelegateCommand CancelCommand { get; private set; }

        public ModifyStudentsDialogViewModel() 
        {
            Sexes = new string[] { "Male", "Female" };

            SubmitCommand = new DelegateCommand(SubmitData);
            CancelCommand = new DelegateCommand(Cancel);

            InputStd = new Student();
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
            Student = parameters.GetValue<Student>("Student");
            InputStd = Student.Copy();
        }

        private void SubmitData()
        {
            DialogParameters keys = new DialogParameters
            {
                { "Student", InputStd }
            };
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, keys));
        }

        private void Cancel()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }

        private void onCancel()
        {

        }
    }
}
