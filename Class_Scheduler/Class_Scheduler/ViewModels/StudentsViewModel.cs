using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Scheduler.Common.Models;
using Prism.Commands;
using Class_Scheduler.Extensions;
using System.Configuration;
using Class_Scheduler.Service;
using Class_Scheduler.Common.Models.DTOs;
using AutoMapper;

namespace Class_Scheduler.ViewModels
{
    public class StudentsViewModel : BindableBase
    {
        private readonly IDialogService dialogService;
        private readonly IRepositoryService repositoryService;

        private int studentsCount;
        private bool isCheckedRow;

        public int StudentsCount
        {
            get { return studentsCount; }
            set { studentsCount = value; RaisePropertyChanged(); }
        }

        public bool IsCheckedRow
        {
            get { return isCheckedRow; }
            set { isCheckedRow = value; RaisePropertyChanged(); }
        }

        public IRepositoryService RepositoryService { get { return repositoryService; } }

        public DelegateCommand AddStudentCommand { get; private set; }
        //Zhiyu Zhang;11A;Male;33143@qq.com
        public DelegateCommand<Student> DeleteMemberCommand { get; private set; }

        public DelegateCommand<Student> ModifyMemberCommand { get; private set; }

        public StudentsViewModel(IDialogService dialogService, IRepositoryService repositoryService, IMapper mapper)
        {
            this.dialogService = dialogService;
            this.repositoryService = repositoryService;

            AddStudentCommand = new DelegateCommand(AddStudent);
            DeleteMemberCommand = new DelegateCommand<Student>(DeleteMember);
            ModifyMemberCommand = new DelegateCommand<Student>(ModifyMember);

            StudentsCount = repositoryService.Students.Count;
        }

        private void AddStudent()
        {
            dialogService.ShowDialog(PrismManager.AddStudentsDialogName, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {
                    var student = callback.Parameters.GetValue<Student>("Student");
                    if (repositoryService.Students.Count > 0)
                        student.Id = repositoryService.Students[repositoryService.Students.Count - 1].Id;
                    else
                        student.Id = repositoryService.Students.Count;
                    repositoryService.Students.Add(student);
                    repositoryService.StudentsCount = repositoryService.Students.Count;
                }
            });
        }

        private void DeleteMember(Student student)
        {
            DialogParameters keys = new DialogParameters();
            keys.Add("ShownData", "Are you sure you want to delete this member?\r\n");
            dialogService.ShowDialog(PrismManager.DeleteMemberDialogName, keys, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {
                    // Delete Members
                    if (!repositoryService.Students.Remove(student))
                    {
                        // 日志输出
                    }
                    else
                    {
                        repositoryService.StudentsCount = repositoryService.Students.Count;
                    }
                }
            });
        }

        private void ModifyMember(Student student)
        {
            DialogParameters keys = new DialogParameters
            {
                { "Student", student }
            };
            dialogService.ShowDialog(PrismManager.ModifyStudentDialogName, keys, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {
                    var std = callback.Parameters.GetValue<Student>("Student");

                    var found = repositoryService.Students.Where(obj => obj.Id.Equals(std.Id)).FirstOrDefault();
                    found.SubjectSelected = std.SubjectSelected;
                    found.Sex = std.Sex;
                    found.Name = std.Name;
                    found.EmailAddress = std.EmailAddress;
                }
            });
        }
    }
}
