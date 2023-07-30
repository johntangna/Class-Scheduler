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

namespace Class_Scheduler.ViewModels
{
    public class ClassesViewModel : BindableBase
    {
        private readonly IDialogService dialogService;
        private readonly IRepositoryService repositoryService;

        public IRepositoryService RepositoryService
        {
            get { return repositoryService; }
        }

        public DelegateCommand GenerateClassesCommand { get; private set; }
        public DelegateCommand<CourseClass> ModifyClassCommand { get; private set; }
        public DelegateCommand<CourseClass> DeleteClassCommand {  get; private set; }
        public DelegateCommand AddClassCommand { get; private set; }

        public ClassesViewModel(IDialogService dialogService, IRepositoryService repositoryService)
        {
            this.dialogService = dialogService;
            this.repositoryService = repositoryService;

            GenerateClassesCommand = new DelegateCommand(GenerateClasses);
            ModifyClassCommand = new DelegateCommand<CourseClass>(ModifyClass);
            DeleteClassCommand = new DelegateCommand<CourseClass>(DeleteClass);
        }

        private void DeleteClass(CourseClass courseClass)
        {
            
        }
        
        private void ModifyClass(CourseClass courseClass)
        {
            
        }

        private void GenerateClasses()
        {
            repositoryService.GenerateCourseClasses();
        }
    }
}
