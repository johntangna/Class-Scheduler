using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace Class_Scheduler.ViewModels.DialogViewModels
{
    public class AddMembersDialogViewModel : BindableBase, IDialogAware
    {
        public string Title => "Add Members";

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand<string> SubmitCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }

        public AddMembersDialogViewModel()
        {
            SubmitCommand = new DelegateCommand<string>(SubmitData);
            CancelCommand = new DelegateCommand(CancelWindow);
        }

        private void SubmitData(string input)
        {
            DialogParameters keys = new DialogParameters();
            keys.Add("Collections", input);
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, keys));
        }

        private void CancelWindow()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Abort));
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }
    }
}
