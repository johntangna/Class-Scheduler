using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using Class_Scheduler.Common.Models;
using Class_Scheduler.Common;
using Class_Scheduler.Extensions;
using Class_Scheduler.Service;
using System;
using Prism.Services.Dialogs;
using System.IO;
using ExcelDataReader;
using System.Data;
using Prism.Ioc;
using Prism.Events;
using Class_Scheduler.Common.Models.DTOs;
using ImTools;
using System.Linq;
using System.Xml.Linq;

namespace Class_Scheduler.ViewModels
{
    public class MainViewModel : BindableBase, IConfigureService
    {
        private readonly IRegionManager regionManager;
        private readonly IRepositoryService repositoryService;
        private readonly IDialogService dialogService;
        private readonly IContainerProvider containerProvider;
        private readonly IEventAggregator eventAggregator;
        private readonly IDialogSettingService dialogSettingService;

        private ObservableCollection<MenuItem> menuItems;

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return menuItems; }
            set { menuItems = value; RaisePropertyChanged(); }
        }

        #region Command
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand SettingCommand { get; private set; }
        public DelegateCommand NotifySizeChangeCommand { get; private set; }
        #endregion

        public MainViewModel(IRegionManager regionManager, IRepositoryService repositoryService, IDialogService dialogService, IDialogSettingService dialogSettingService, IContainerProvider containerProvider)
        {
            NavigateCommand = new DelegateCommand<string>(Navigate);
            SaveCommand = new DelegateCommand(SaveData);
            SettingCommand = new DelegateCommand(OpenSettingDialog);
            NotifySizeChangeCommand = new DelegateCommand(NotifySizeChange);

            this.containerProvider = containerProvider;
            this.regionManager = regionManager;
            this.repositoryService = repositoryService;
            this.dialogService = dialogService;
            this.eventAggregator = containerProvider.Resolve<IEventAggregator>();
            this.dialogSettingService = dialogSettingService;
        }

        private void NotifySizeChange()
        {
            dialogSettingService.DialogHeight = App.Current.MainWindow.Height;
            dialogSettingService.DialogWidth = App.Current.MainWindow.Width; 
        }

        private void OpenSettingDialog()
        {
            dialogService.ShowDialog(PrismManager.SettingsDialogName, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {
                    var settings = callback.Parameters.GetValue<UserSetting>("UserSetting");
                    if (settings.ImportDataPath != string.Empty && settings.ImportDataPath != null)
                    {
                        LoadData(settings);
                    }
                }          
            });
        }

        private void LoadData(UserSetting settings)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            FileStream stream = File.Open(settings.ImportDataPath, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            DataSet result = excelDataReader.AsDataSet();

            // Import data
            DataTableCollection tableCollection = result.Tables;

            // tableCollection[0] --> Students
            DataTable studentTable = tableCollection[0];
            for (int i = 1; i < studentTable.Rows.Count; i++)
            {
                Student student = new Student();

                if (repositoryService.Students.Count > 0)
                {
                    student.Id = repositoryService.Students[^1].Id + 1;
                }
                else
                {
                    if (int.TryParse(studentTable.Rows[i][0].ToString(), out int id))
                        student.Id = id;
                }

                student.Name = studentTable.Rows[i][1].ToString()!;
                student.GradeAndClass = studentTable.Rows[i][2].ToString()!;
                student.Sex = studentTable.Rows[i][3].ToString()!;
                student.EmailAddress = studentTable.Rows[i][4].ToString()!;

                bool flag = true;
                for (int j = 5; j < studentTable.Columns.Count; j++)
                {
                    if (flag)
                    {
                        student.SubjectSelected.Add(studentTable.Rows[i][j].ToString()!);
                    }
                    else
                    {
                        if (int.TryParse(studentTable.Rows[i][j].ToString(), out int score))
                            student.SubjectScores.Add(score);
                    }

                    flag = !flag;
                }
                
                //student.SubjectSelected.Add(studentTable.Rows[i][7].ToString()!);
                //student.SubjectSelected.Add(studentTable.Rows[i][9].ToString()!);
                //student.SubjectSelected.Add(studentTable.Rows[i][11].ToString()!);
                //student.SubjectSelected.Add(studentTable.Rows[i][13].ToString()!);
                //student.SubjectSelected.Add(studentTable.Rows[i][15].ToString()!);

                //if (int.TryParse(studentTable.Rows[i][6].ToString(), out int score1))
                //    student.SubjectScores.Add(score1);
                //if (int.TryParse(studentTable.Rows[i][8].ToString(), out int score2))
                //    student.SubjectScores.Add(score2);
                //if (int.TryParse(studentTable.Rows[i][10].ToString(), out int score3))
                //    student.SubjectScores.Add(score3);
                //if (int.TryParse(studentTable.Rows[i][12].ToString(), out int score4))
                //    student.SubjectScores.Add(score4);
                //if (int.TryParse(studentTable.Rows[i][14].ToString(), out int score5))
                //    student.SubjectScores.Add(score5);
                //if (int.TryParse(studentTable.Rows[i][16].ToString(), out int score6))
                //    student.SubjectScores.Add(score6);

                repositoryService.Students.Add(student);
            }
            repositoryService.StudentsCount = repositoryService.Students.Count;

            // tableCollection[1] --> Teachers
            DataTable teacherTable = tableCollection[1];
            for (int i = 1; i < teacherTable.Rows.Count; i++)
            {
                Teacher teacher = new Teacher();
                if (repositoryService.Teachers.Count > 0)
                {
                    teacher.Id = repositoryService.Teachers[repositoryService.Teachers.Count - 1].Id + 1;
                }
                else
                {
                    if (int.TryParse(teacherTable.Rows[i][0].ToString(), out int id))
                        teacher.Id = id;
                }

                teacher.Name = teacherTable.Rows[i][1].ToString()!;
                teacher.EmailAddress = teacherTable.Rows[i][2].ToString()!;
                string subjecStr = teacherTable.Rows[i][3].ToString()!;
                teacher.Subjects = subjecStr;
                string[] subjects = subjecStr.Split(',');
                teacher.SubjectList.AddRange(subjects);
                string[] times = teacherTable.Rows[i][4].ToString()!.Split(';');
                for (int j = 0; j < times.Length; j++)
                {

                    if (!(times[j].Length <= 0 || times[j] == "0"))
                    {
                        string[] slots = times[j].Split(',');
                        for (int z = 0; z < slots.Length; z++)
                        {
                            TimeSlot slot = new TimeSlot();
                            slot.Weekday = j;
                            if (int.TryParse(slots[z], out int num))
                                slot.Slot = num;
                            teacher.BusyTimeSlots.Add(slot);
                        }
                    }
                }

                repositoryService.Teachers.Add(teacher);
            }
            repositoryService.TeachersCount = repositoryService.Teachers.Count;

            // Subject 添加判断条件
            DataTable subjectTable = tableCollection[2];
            for (int i = 1; i < subjectTable.Rows.Count; i++)
            {
                Subject subject = new Subject();
                if (repositoryService.Subjects.Count > 0)
                {
                    subject.Id = repositoryService.Subjects[^1].Id + 1;
                }
                else
                {
                    if (int.TryParse(subjectTable.Rows[i][0].ToString(), out int id))
                        subject.Id = id;
                }

                subject.Name = subjectTable.Rows[i][1].ToString()!;
                string teacherNamesStr = subjectTable.Rows[i][2].ToString()!;
                subject.TeacherNames = teacherNamesStr;
                string[] teacherNames = teacherNamesStr.Split(',');
                for (int j = 0; j < teacherNames.Length; j++)
                {
                    var collection = repositoryService.Teachers.Where(obj => obj.Name.Equals(teacherNames[j]));
                    Teacher? teacher = null;
                    if (collection.Count() > 0)
                    {
                        teacher = collection.First();
                        subject.TeachersList.Add(teacher);
                    }
                }
                subject.SubjectGroup = subjectTable.Rows[i][3].ToString()!;
                if (int.TryParse(subjectTable.Rows[i][4].ToString()!, out int cnt))
                    subject.CountPerWeek = cnt;

                repositoryService.Subjects.Add(subject);
                repositoryService.SubjectAvailable.Add(subject.Name);
            }
            repositoryService.SubjectsCount = repositoryService.Subjects.Count;

            // Room
            DataTable roomTable = tableCollection[3];
            for (int i = 1; i < roomTable.Rows.Count; i++)
            {
                Room room = new Room();
                if (int.TryParse(roomTable.Rows[i][0].ToString(), out int id))
                    room.Id = id;
                room.Purpose = roomTable.Rows[i][1].ToString()!;

                repositoryService.Rooms.Add(room);
            }
            repositoryService.RoomsCount = repositoryService.Rooms.Count;

            excelDataReader.Close();
        }

        public void Navigate(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                // ToDo: 添加日志输出
                return;
            }

            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(target);
        }

        public void SaveData()
        {
            repositoryService.SaveData();
        }

        public void Configure()
        {
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("SchedulesView");
        }

        //public void Navigate(MenuItem menuItem)
        //{
        //    if (menuItem == null || string.IsNullOrEmpty(menuItem.NavigatedTarget))
        //    {
        //        // ToDo: 添加日志输出
        //        return;
        //    }

        //    regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(menuItem.NavigatedTarget);
        //}

        //private void CreateMenuItems()
        //{
        //    MenuItems.Add(new MenuItem() { Icon = "GoogleClassroom", Title = "Lessons", NavigatedTarget = "LessonsView" });
        //}
    }
}
