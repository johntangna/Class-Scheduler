using Class_Scheduler.Common.Models;
using Class_Scheduler.Extensions;
using Class_Scheduler.Service;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.ViewModels
{
    public class SubjectsViewModel : BindableBase
    {
        private readonly IDialogService dialogService;
        private readonly IRepositoryService repositoryService;

        public IRepositoryService RepositoryService
        {
            get { return repositoryService; }
        }

        public DelegateCommand AddSubjectCommand { get; private set; }
        public DelegateCommand<Subject> DeleteSubjectCommand { get; private set; }
        public DelegateCommand<Subject> ModifySubjectCommand { get; private set; }

        public SubjectsViewModel(IDialogService dialogService, IRepositoryService repositoryService) 
        {
            this.dialogService = dialogService;
            this.repositoryService = repositoryService;

            AddSubjectCommand = new DelegateCommand(AddLesson);
            DeleteSubjectCommand = new DelegateCommand<Subject>(DeleteLesson);
            ModifySubjectCommand = new DelegateCommand<Subject>(ModifyCourse);
        }

        private void AddLesson()
        {
            dialogService.ShowDialog(PrismManager.AddSubjectDialogName, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {
                    var subject = callback.Parameters.GetValue<Subject>("Subject");
                    if (repositoryService.Subjects.Count > 0)
                        subject.Id = repositoryService.Subjects[repositoryService.Subjects.Count - 1].Id;
                    else
                        subject.Id = repositoryService.Subjects.Count;
                    repositoryService.Subjects.Add(subject);
                    repositoryService.SubjectAvailable.Add(subject.Name);
                    repositoryService.SubjectsCount = repositoryService.Subjects.Count;
                }
            });
        }

        private void DeleteLesson(Subject subject)
        {
            DialogParameters keys = new DialogParameters();
            keys.Add("ShownData", "Are you sure you want to delete this course?\r\n");
            dialogService.ShowDialog(PrismManager.DeleteMemberDialogName, keys, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {
                    // Delete Members
                    if (!repositoryService.Subjects.Remove(subject))
                    {
                        // 日志输出
                    }
                    else
                    {
                        repositoryService.SubjectsCount = repositoryService.Subjects.Count; 
                        repositoryService.SubjectAvailable.Remove(subject.Name);
                    }
                }
            });
        }

        private void ModifyCourse(Subject subject)
        {
            DialogParameters keys = new DialogParameters
            {
                { "Subject", subject }
            };
            dialogService.ShowDialog(PrismManager.ModifySubjectsDialogName, keys, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {
                    var tmp = callback.Parameters.GetValue<Subject>("Subject");

                    var found = repositoryService.Subjects.Where(item => item.Id.Equals(tmp.Id)).FirstOrDefault();
                    found.Name = tmp.Name;
                    found.RoomNum = tmp.RoomNum;
                    found.TeacherNames = tmp.TeacherNames;
                    found.SubjectGroup = tmp.SubjectGroup;
                    found.CountPerWeek = tmp.CountPerWeek;
                    repositoryService.SubjectAvailable.Remove(subject.Name);
                    repositoryService.SubjectAvailable.Add(tmp.Name);
                }
            });
        }
    }
}
