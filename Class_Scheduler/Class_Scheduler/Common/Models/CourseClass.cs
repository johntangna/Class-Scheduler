using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Class_Scheduler.Common.Models
{
    public class CourseClass : BindableBase
    {
        private int id;
        public int Id
        { 
            get { return id; }
            set { id = value; }
        }

        private string classCode;

        public string ClassCode 
        { 
            get { return classCode; }
            set { classCode = value; RaisePropertyChanged(); }
        }

        private string className;

        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }

        private int countPerWeek;

        public int CountPerWeek
        {
            get { return countPerWeek; }
            set { countPerWeek = value; }
        }

        private Teacher teacher;
        public Teacher Teacher
        {
            get { return teacher; }
            set { teacher = value; }
        }

        private List<Student> students = new List<Student>();

        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        private int studentCount;
        public int StudentCount
        {
            get { return studentCount; }
            set { studentCount = value; RaisePropertyChanged(); }
        }
    }
}
