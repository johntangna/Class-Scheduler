using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Common.Models
{
	/// <summary>
	/// 具体的课，比如Math101
	/// TODO: 未来在加入数据库操作以后，把获得老师的方式变成一个下拉框的操作
	/// 添加学生的数据
	/// </summary>
    public class Subject : BindableBase
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private int countPerWeek;

		/// <summary>
		/// 一周上几节
		/// </summary>
		public int CountPerWeek
		{
			get { return countPerWeek; }
			set { countPerWeek = value; RaisePropertyChanged(); }
		}

		private string name;

		/// <summary>
		/// 课程名字
		/// </summary>
		public string Name	
		{
			get { return name; }
			set { name = value; RaisePropertyChanged(); }
		}

		private string teacherNames;

		/// <summary>
		/// 教该课程的老师名
		/// </summary>
		public string TeacherNames
        {
			get { return teacherNames; }
			set { teacherNames = value; RaisePropertyChanged(); }
		}

		private List<Teacher> teachersList = new List<Teacher>();

		public List<Teacher> TeachersList
		{
			get { return teachersList; }
			set { teachersList = value; RaisePropertyChanged(); }
		}


        private string roomNumber;

		/// <summary>
		/// 所使用的教室房间号
		/// </summary>
		public string RoomNum
		{
			get { return roomNumber; }
			set { roomNumber = value; RaisePropertyChanged(); }
		}

		private string subjectGroup;

		/// <summary>
		/// 学科组，分别为1 2 3 4 5 6
		/// </summary>
		public string SubjectGroup
		{
			get { return subjectGroup; }
			set { subjectGroup = value; RaisePropertyChanged(); }
		}

		public Subject Copy()
		{
			Subject subject = new Subject();
			subject.Id = Id;
			subject.Name = Name;
			subject.SubjectGroup = SubjectGroup;
			subject.TeacherNames = TeacherNames;
			subject.TeachersList = TeachersList;
			subject.RoomNum = RoomNum;
			subject.CountPerWeek = CountPerWeek;
			return subject;
		}
	}
}
