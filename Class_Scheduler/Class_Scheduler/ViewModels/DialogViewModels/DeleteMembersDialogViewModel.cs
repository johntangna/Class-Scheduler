using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace Class_Scheduler.ViewModels.DialogViewModels
{
    public class DeleteMembersDialogViewModel : BindableBase, IDialogAware
    {
        public string Title => "Delete Members";

        public event Action<IDialogResult> RequestClose;
        public DelegateCommand DeleteCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }

        public string ShownStatement { get; private set; }

        public DeleteMembersDialogViewModel()
        {
            DeleteCommand = new DelegateCommand(DeleteData);
            CancelCommand = new DelegateCommand(CancelWindow);
        }

        private void DeleteData()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
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
            ShownStatement = parameters.GetValue<string>("ShownData");
        }
    }
}
