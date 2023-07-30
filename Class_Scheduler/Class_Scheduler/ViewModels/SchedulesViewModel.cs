using Class_Scheduler.Common.Models;
using Class_Scheduler.Common.Models.ClassScheduling;
using Class_Scheduler.Service;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Class_Scheduler.ViewModels
{
    public class SchedulesViewModel : BindableBase
    {
        private IRepositoryService repositoryService;

        public IRepositoryService RepositoryService
        {
            get { return repositoryService; }
            set {  repositoryService = value; }
        }

        private ObservableCollection<Slot> slots;

        public ObservableCollection<Slot> Slots
        {
            get { return slots; }
            set { slots = value; RaisePropertyChanged(); }
        }

        public DelegateCommand GenerateScheduleCommand { get; private set; }
        public DelegateCommand AddCourseCommand { get; private set; }

        public SchedulesViewModel(IRepositoryService repositoryService)
        {
            this.repositoryService = repositoryService;

            GenerateScheduleCommand = new DelegateCommand(GenerateSchedule);
            AddCourseCommand = new DelegateCommand(AddCourse);
        }

        private void AddCourse()
        {
            
        }

        private void GenerateSchedule()
        {
            repositoryService.GenerateScheduledClasses();
        }
    }
}
