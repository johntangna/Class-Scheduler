using Class_Scheduler.Common.Models;
using Class_Scheduler.Common.Models.ClassScheduling;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Service
{
    public interface IRepositoryService
    {
        ObservableCollection<Subject> Subjects { get; set; }

        ObservableCollection<Student> Students { get; set; }

        ObservableCollection<Teacher> Teachers { get; set; }    

        ObservableCollection<Room> Rooms { get; set; }

        ObservableCollection<CourseClass> CourseClasses { get; set; }

        UserSetting UserSetting { get; set; }

        Schedule Schedule { get; set; }

        List<string> SubjectAvailable { get; set; }
        
        int StudentsCount { get; set; }
        int SubjectsCount { get; set; }
        int RoomsCount { get; set; }
        int TeachersCount { get; set; }

        int CourseClassCount { get; set; }

        void SaveData();

        void LoadData();

        void SaveUserSetting();
        void LoadUserSetting();

        void GenerateCourseClasses();

        void GenerateScheduledClasses();

        void InitSchedules();
    }
}
