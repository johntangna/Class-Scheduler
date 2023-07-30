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
using Class_Scheduler.Service;

namespace Class_Scheduler.ViewModels
{
    public class TeachersViewModel : BindableBase
    {
        private readonly IDialogService dialogService;
        private readonly IRepositoryService repositoryService;

        private int membersCount;

        public IRepositoryService RepositoryService { get { return repositoryService; } }

        public DelegateCommand AddMemberCommand { get; private set; }

        public DelegateCommand<Teacher> DeleteMemberCommand { get; private set; }

        public DelegateCommand<Teacher> ModifyMemberCommand { get; private set; }

        public TeachersViewModel(IDialogService dialogService, IRepositoryService repositoryService)
        {
            this.dialogService = dialogService;
            this.repositoryService = repositoryService;

            AddMemberCommand = new DelegateCommand(AddMember);
            DeleteMemberCommand = new DelegateCommand<Teacher>(DeleteMember);
            ModifyMemberCommand = new DelegateCommand<Teacher>(ModifyMember);
        }

        /// <summary>
        /// 通过在文本框里输入数据来添加
        /// </summary>
        /// <param name="commandStr"></param>
        public void AddMember(string commandStr)
        {
            string[] rowData = commandStr.Split("\r\n");

            // Add Teacher data

            /* Example Data for Teachers:  
             * Wengjuan Xu;xxx@email.com;Math
             * mushi Tang;xxx@email.com;LAL
             */
            for (int i = 0; i < rowData.Length; i++)
            {
                if (!string.IsNullOrEmpty(rowData[i]))
                {
                    string[] teacherData = rowData[i].Split(';');
                    RepositoryService.Teachers.Add(new Teacher() { Id = i, Name = teacherData[0], EmailAddress = teacherData[1], SubjectList = new List<string>() { teacherData[2] } });
                    
                }
            }
            repositoryService.TeachersCount = repositoryService.Teachers.Count;
        }

        private void AddMember()
        {
            dialogService.ShowDialog(PrismManager.AddTeachersDialogName, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {
                    string inputStr = callback.Parameters.GetValue<string>("Collections");
                    AddMember(inputStr);
                }
            });
        }

        private void DeleteMember(Teacher teacher)
        {
            DialogParameters keys = new DialogParameters();
            keys.Add("ShownData", "Are you sure you want to delete this member?\r\n");

            dialogService.ShowDialog(PrismManager.DeleteMemberDialogName, keys, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {
                    // Delete Members
                    if (!RepositoryService.Teachers.Remove(teacher))
                    {
                        // 日志输出
                    }
                    else
                    {
                        repositoryService.TeachersCount = repositoryService.Teachers.Count;
                    }
                }
            });
        }

        private void ModifyMember(Teacher teacher)
        {
            DialogParameters keys = new DialogParameters
            {
                { "Teacher", teacher }
            };
            dialogService.ShowDialog(PrismManager.ModifyTeacherDialogName, keys, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {
                    RepositoryService.Teachers[teacher.Id] = callback.Parameters.GetValue<Teacher>("Teacher");
                }
            });
        }
    }
}
