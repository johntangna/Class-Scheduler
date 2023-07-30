using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Common.Models
{
	/// <summary>
	/// 随机选择颜色
	/// </summary>
    public class Student : UserBase
    {

		private string gradeAndClass;

		public string GradeAndClass
		{
			get { return gradeAndClass; }
			set { gradeAndClass = value; RaisePropertyChanged(); }
		}

		public string sex;

		public string Sex
		{
			get { return sex; }
			set { sex = value; RaisePropertyChanged(); }
		}

		private string emailAddress;

		public string EmailAddress
		{
			get { return emailAddress; }
			set { emailAddress = value; RaisePropertyChanged(); }	
		}

		private List<int> subjectScores;

		public List<int> SubjectScores
		{
			get 
			{ 
				if (subjectScores == null)
					subjectScores = new List<int>();
				return subjectScores; 
			}
			set { subjectScores = value; RaisePropertyChanged(); }
		}

		private List<string> subjectsSelected;

		public List<string> SubjectSelected
		{
			get 
			{
                if (subjectsSelected == null)
                    subjectsSelected = new List<string>();
                return subjectsSelected; 
			}
			set { subjectsSelected = value; RaisePropertyChanged(); }
		}

		public Student Copy()
		{
			Student student = new Student();
			student.Id = Id;
			student.Name = Name;
			student.EmailAddress = EmailAddress;
			student.SubjectSelected = SubjectSelected;
			student.Sex = Sex;
			student.GradeAndClass = GradeAndClass;
			student.SubjectScores = SubjectScores;
			return student;
		}

    }
}
