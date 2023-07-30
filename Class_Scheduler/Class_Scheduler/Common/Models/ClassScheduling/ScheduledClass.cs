using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace Class_Scheduler.Common.Models.ClassScheduling
{
    public class ScheduledClass : BindableBase, ICloneable
    {
        private CourseClass course;
        public int Id { get; set; }
        public CourseClass Course
        {
            get { return course; }
            set { course = value; RaisePropertyChanged(); }
        }
        public int RoomId { get; set; }
        public int WeekDay { get; set; }
        public int Slot { get; set; }

        public ScheduledClass()
        {

        }

        public ScheduledClass(CourseClass course)
        {
            Course = course;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public void Random_Init(List<Room> roomIds)
        {
            Random random = new Random();
            RoomId = roomIds.ElementAt(random.Next(0, roomIds.Count - 1)).Id;
            WeekDay = random.Next(1, 6);
            Slot = random.Next(1, 10);
        }

        public ScheduledClass DeepCopy()
        {
            object retval;
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(ScheduledClass));
                ser.WriteObject(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                retval = ser.ReadObject(ms);
                ms.Close();
            }

            return (ScheduledClass)retval;
        }
    }
}
