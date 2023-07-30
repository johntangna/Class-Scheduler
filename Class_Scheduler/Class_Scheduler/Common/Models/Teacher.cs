using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Common.Models
{
	/// <summary>
	/// 添加老师不同时间段的数据
	/// </summary>
    public class Teacher : UserBase
    {

		private string emailAddress;

		public string EmailAddress
		{
			get { return emailAddress; }
			set { emailAddress = value; RaisePropertyChanged(); }
		}

		private List<string> subjectList = new List<string>();

		public List<string> SubjectList
		{
			get { return subjectList; }
			set { subjectList = value; }
		}

		private string subjects;
		public string Subjects
		{
			get { return subjects; }
			set { subjects = value; RaisePropertyChanged(); }
		}

		private List<TimeSlot> busyTimeSlots = new List<TimeSlot>(5);

		public List<TimeSlot> BusyTimeSlots
        { 
			get { return busyTimeSlots; } 
		}
    }
}
