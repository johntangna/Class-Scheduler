using AutoMapper;
using Class_Scheduler.Common.Evolution;
using Class_Scheduler.Common.Models;
using Class_Scheduler.Common.Models.ClassScheduling;
using Class_Scheduler.Common.Models.DTOs;
using Class_Scheduler.Extensions;
using ImTools;
using MaterialDesignThemes.Wpf.Converters;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Class_Scheduler.Service
{
    public class RepositoryService : BindableBase, IRepositoryService
    {
        private readonly IMapper mapper;

        private ObservableCollection<Subject> subjects;
        public ObservableCollection<Subject> Subjects 
        { 
            get 
            {
                if (subjects == null)
                    subjects = new ObservableCollection<Subject>();
                return subjects; 
            }
            set 
            { 
                subjects = value; RaisePropertyChanged();   
            }
        }

        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get
            {
                if (students == null)
                    students = new ObservableCollection<Student>();
                return students;
            }
            set { students = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Teacher> teachers;
        public ObservableCollection<Teacher> Teachers
        {
            get
            {
                if (teachers == null)
                    teachers = new ObservableCollection<Teacher>();
                return teachers;
            }
            set { teachers = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Room> rooms;
        public ObservableCollection<Room> Rooms
        {
            get
            {
                if (rooms == null)
                    rooms = new ObservableCollection<Room>();
                return rooms;
            }
            set { rooms = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<CourseClass> courseClasses;

        public ObservableCollection<CourseClass> CourseClasses
        {
            get
            {
                if (courseClasses == null)
                    courseClasses = new ObservableCollection<CourseClass>();
                return courseClasses;
            }
            set { courseClasses = value; RaisePropertyChanged(); }
        }

        private List<string> subjectAvailable;

        public List<string> SubjectAvailable
        {
            get
            {
                return subjectAvailable;
            }
            set
            {
                subjectAvailable = value; RaisePropertyChanged();
            }
        }

        private UserSetting userSetting;
        public UserSetting UserSetting { get => userSetting; set => userSetting = value; }

        private Schedule schedule;

        public Schedule Schedule
        {
            get { return schedule; }
            set { schedule = value; RaisePropertyChanged(); }
        }

        private int studentsCount;
        public int StudentsCount 
        { 
            get { return studentsCount; }
            set { studentsCount = value; RaisePropertyChanged(); }
        }

        private int lessonsCount;

        public int SubjectsCount
        {
            get { return lessonsCount; }
            set { lessonsCount = value; RaisePropertyChanged(); }
        }

        private int roomsCount;

        public int RoomsCount
        {
            get { return roomsCount; }
            set { roomsCount = value; RaisePropertyChanged(); }
        }

        private int teachersCount;

        public int TeachersCount
        {
            get { return teachersCount; }
            set { teachersCount = value; RaisePropertyChanged(); }
        }

        private int courseClassCount;
        
        public int CourseClassCount
        {
            get { return courseClassCount; }
            set { courseClassCount = value; RaisePropertyChanged(); }
        }

        public RepositoryService(IMapper mapper)
        {
            subjectAvailable = new List<string>();
            UserSetting = new UserSetting();
            Schedule = new Schedule();
            this.mapper = mapper;

            LoadData();
            LoadUserSetting();
            InitSchedules();
            StudentsCount = Students.Count;
            TeachersCount = Teachers.Count;
            RoomsCount = Rooms.Count;
            SubjectsCount = Subjects.Count;
        }

        public void SaveData()
        {
            SavableObject savableObject = new SavableObject();
            savableObject.Teachers = mapper.Map<List<TeacherDTO>>(Teachers.ToList());
            savableObject.Students = mapper.Map<List<StudentDTO>>(Students.ToList());
            savableObject.Rooms = mapper.Map<List<RoomDTO>>(Rooms.ToList());
            savableObject.Subjects = mapper.Map<List<SubjectDTO>>(Subjects.ToList());
            
            savableObject.DateTime = DateTime.Now;

            XmlSerializeManager.XmlSerialize<SavableObject>(PrismManager.SavedPath, savableObject);
        }
        
        public void LoadData()
        {
            SavableObject savableObject = XmlSerializeManager.XmlDeserializer<SavableObject>(PrismManager.SavedPath);
            if (savableObject == null)
                return;

            Teachers.AddRange(mapper.Map<List<Teacher>>(savableObject.Teachers));
            Students.AddRange(mapper.Map<List<Student>>(savableObject.Students));
            Rooms.AddRange(mapper.Map<List<Room>>(savableObject.Rooms));
            Subjects.AddRange(mapper.Map<List<Subject>>(savableObject.Subjects));         
        }

        public void GenerateCourseClasses()
        {
            CourseClasses.Clear();
            CourseClassGenerator classGenerator = new CourseClassGenerator(Students.ToList(), Subjects.ToList(), userSetting.ClassDivisionBaseline);
            List<CourseClass> courseClassesTmp = classGenerator.GenerateCourseClass();
            CourseClasses.AddRange(courseClassesTmp);
            CourseClassCount = CourseClasses.Count;
        }

        public void GenerateScheduledClasses()
        {
            if (CourseClasses.Count <= 0)
                return; // 提示信息

            foreach (Slot slot in Schedule.Slots)
                slot.ScheduledClasses.Clear();

            ClassEvolution classEvolution = new ClassEvolution(UserSetting.PopulationSize, UserSetting.MutationProb, 10);
            List<ScheduledClass> classes = new List<ScheduledClass>();

            for (int i = 0; i < CourseClasses.Count; i++)
            {
                for (int j = 0; j < CourseClasses[i].CountPerWeek; j++)
                    classes.Add(new ScheduledClass(CourseClasses[i]));
            }
                

            List<ScheduledClass> scheduledClasses = classEvolution.Evolution(classes, Rooms.ToList());

            // Add all scheduledClasses to the Schedule Object
            foreach (Slot slot in Schedule.Slots)
            {
                foreach (var course in scheduledClasses)
                {
                    if (course.WeekDay == slot.Weekday && course.Slot == slot.SlotNum)
                        slot.ScheduledClasses.Add(course);
                }
            }
        }

        public void SaveUserSetting()
        {
            UserSettingDTO userSettingSaved = mapper.Map<UserSettingDTO>(UserSetting);
            XmlSerializeManager.XmlSerialize<UserSettingDTO>(PrismManager.UserSettingSavedPath, userSettingSaved);
        }

        public void LoadUserSetting()
        {
            UserSettingDTO userSettingSaved = XmlSerializeManager.XmlDeserializer<UserSettingDTO>(PrismManager.UserSettingSavedPath);
            if (userSettingSaved == null)
            {
                return;
            }   

            UserSetting = mapper.Map<UserSetting>(userSettingSaved);
        }

        public void InitSchedules()
        {
            for (int i = 0; i < 43; i++)
            {
                Slot slot = new Slot();
                slot.Weekday = i / 9 + 1;
                slot.SlotNum = i % 9 + 1;
                Schedule.Slots.Add(slot);
            }
        }
    }
}
