using Class_Scheduler.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace Class_Scheduler.ViewModels.DialogViewModels
{
    public class ModifyRoomsDialogViewModel : BindableBase, IDialogAware
    {
        public string Title => "Edit Room";

        public event Action<IDialogResult> RequestClose;

        public Room Room { get; set; }

        public string[] usingPurpose { get; set; }

        public DelegateCommand SubmitCommand { get; private set; }

        public DelegateCommand CancelCommand { get; private set; }

        public ModifyRoomsDialogViewModel()
        {
            usingPurpose = new string[] { "For holding classes", "For working" };

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
            Room = parameters.GetValue<Room>("Room");
        }

        private void SubmitData()
        {
            DialogParameters keys = new DialogParameters
            {
                { "Room", Room }
            };
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, keys));
        }

        private void Cancel()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }
    }
}
