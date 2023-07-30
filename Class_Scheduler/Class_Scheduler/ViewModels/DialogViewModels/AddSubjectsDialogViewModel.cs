using Class_Scheduler.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace Class_Scheduler.ViewModels.DialogViewModels
{
    public class AddSubjectsDialogViewModel : BindableBase, IDialogAware
    {
        public string Title => "Add Course";

        public event Action<IDialogResult> RequestClose;

        public Subject Subject { get; set; }

        public int[] numPerWeek { get; set; }

        public string[] subjectGroup { get; set; }

        public DelegateCommand SubmitCommand { get; private set; }

        public DelegateCommand CancelCommand { get; private set; }

        public AddSubjectsDialogViewModel()
        {
            numPerWeek = new int[] { 1, 2, 3, 4, 5, 6 };
            subjectGroup = new string[] { "Studies in language and literature", "Language acquisition", "Individuals and societies", "Sciences", "Mathematics", "The arts" };

            SubmitCommand = new DelegateCommand(SubmitData);
            CancelCommand = new DelegateCommand(Cancel);

            Subject = new Subject();

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
            
        }

        private void SubmitData()
        {
            DialogParameters keys = new DialogParameters
            {
                { "Subject", Subject }
            };
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, keys));
        }

        private void Cancel()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }
    }
}
