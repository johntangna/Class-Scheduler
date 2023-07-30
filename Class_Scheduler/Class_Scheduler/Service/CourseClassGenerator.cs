using Class_Scheduler.Common.Evolution;
using Class_Scheduler.Common.Models;
using Class_Scheduler.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Service
{
    public class CourseClassGenerator
    {
        private List<Student> students;
        private List<Subject> subjects;
        private int studentCountBaseline = 0;

        public CourseClassGenerator(List<Student> students, List<Subject> lessons, int studentCountBaseline)
        {
            this.students = students;
            subjects = lessons;
            this.studentCountBaseline = studentCountBaseline;
        }

        public CourseClassGenerator(List<Student> students, List<Subject> lessons)
        {
            this.students = students;
            subjects = lessons;
            studentCountBaseline = 18;
        }

        public CourseClassGenerator() { }

        public List<CourseClass> GenerateCourseClass()
        {
            /*
             * 1. Distribute the student
             * 2. Distribute the teacher
             * 3. Set the Class Code (Original BusinessManagement SL) --> Bus SL
             */

            List<CourseClass> courseClasses = new List<CourseClass>();
            int classIndex = 0;
            foreach (var subject in subjects)
            {
                // Initialize the student set that contains all students who select a particular subject
                List<Student> studentSet = new List<Student>();
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].SubjectSelected.Contains(subject.Name))
                    {
                        studentSet.Add(students[i]);
                    }
                }

                if (studentSet.Count == 0)
                    continue;

                // Get the number of classes to divide
                List<CourseClass> subjectClasses = new List<CourseClass>();

                double stdCnt = studentSet.Count;
                double stdCntBase = studentCountBaseline;
                int classCnt = Convert.ToInt32(Math.Ceiling(stdCnt / stdCntBase));

                // Add the class to the subjectClassesList
                for (int i = 0; i <= classCnt; i++)
                {
                    subjectClasses.Add(new CourseClass()
                    {
                        ClassName = subject.Name,
                        ClassCode = subject.Name[..3] + (i + 1),
                        Id = classIndex,
                        CountPerWeek = subject.CountPerWeek
                    });
                    classIndex++;
                }

                // Start to distribute students
                // Sort the studentSet according to the subject score
                studentSet.Sort((std1, std2) =>
                {
                    return std1.SubjectScores[std1.SubjectSelected.IndexOf(subject.Name)].CompareTo(std2.SubjectScores[std2.SubjectSelected.IndexOf(subject.Name)]);
                });

                // Distribute student to different subjectClass in order of student score
                int subjectClassPtr = 0;
                foreach (var student in studentSet)
                {
                    subjectClasses[subjectClassPtr].Students.Add(student);
                    subjectClasses[subjectClassPtr].StudentCount++;
                    subjectClassPtr = (subjectClassPtr + 1) % subjectClasses.Count;
                }

                // Distribute teachers
                int classPerTeacher = subjectClasses.Count / subject.TeachersList.Count;

                // Random Sort the Teacher List
                List<Teacher> teachers = subject.TeachersList;
                RandomSortList(teachers);

                int teacherPtr = 0;
                for (int i = 0; i < subjectClasses.Count; i++)
                {
                    subjectClasses[i].Teacher = teachers[teacherPtr];
                    teacherPtr = (teacherPtr + 1) % teachers.Count;
                }

                courseClasses.AddRange(subjectClasses);
            }

            return courseClasses;
        }

        private List<T> RandomSortList<T>(List<T> ListT)
        {
            Random random = new Random();
            List<T> newList = new List<T>();
            foreach (T item in ListT)
            {
                newList.Insert(random.Next(newList.Count + 1), item);
            }
            return newList;
        }
    }
}
