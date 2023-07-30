using Class_Scheduler.Common.Models;
using Class_Scheduler.Service;
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
    public class AddStudentsDialogViewModel : BindableBase, IDialogAware
    {
        private readonly IRepositoryService repositoryService;

        public string Title => "Add student data";

        public event Action<IDialogResult> RequestClose;

        public Student Student { get; set; }

        public string[] Sexes { get; set; }
        public int[] Scores { get; set; }

        public DelegateCommand SubmitCommand { get; private set; }

        public DelegateCommand CancelCommand { get; private set; }

        public IRepositoryService RepositoryService { get { return repositoryService; } }

        public AddStudentsDialogViewModel(IRepositoryService repositoryService) 
        {
            this.repositoryService = repositoryService;

            Sexes = new string[] { "Male", "Female" };
            Scores = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            SubmitCommand = new DelegateCommand(SubmitData);
            CancelCommand = new DelegateCommand(Cancel);
            Student = new Student();
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
            System.Diagnostics.Debug.WriteLine(repositoryService.SubjectAvailable.Count());

            DialogParameters keys = new DialogParameters
            {
                { "Student", Student }
            };
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, keys));
        }

        private void Cancel()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }
    }
}
