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

        public ScheduledClass(CourseClass course, int weekDay, int slot, int roomId)
        {
            Course = course;
            WeekDay = weekDay;
            Slot = slot;
            RoomId = roomId;
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
        // 在 ClassEvolution 类中添加一个新的辅助方法，用于将 List<ScheduledClass> 转换为整数数组
        public int[] EncodePopulation(List<List<ScheduledClass>> population)
        {
            int[] encodedPopulation = new int[population.Count * 800];

            for (int i = 0; i < population.Count; i++)
            {
                foreach (var scheduledClass in population[i])
                {
                    int courseId = scheduledClass.Course.Id;
                    int slot = scheduledClass.Slot - 1; // 时段从1开始，需要减1转换为0开始
                    int weekDay = scheduledClass.WeekDay - 1; // 星期从1开始，需要减1转换为0开始
                    int roomId = scheduledClass.RoomId - 1; // 教室从1开始，需要减1转换为0开始

                    int index = i * 800 + weekDay * 160 + slot * 20 + roomId;
                    encodedPopulation[index] = 1; // 设置对应时间段和教室的标志位为1，表示已安排课程
                }
            }

            return encodedPopulation;
        }

        // 在 ClassEvolution 类中添加一个新的辅助方法，用于将整数数组转换为 List<ScheduledClass>
        public List<List<ScheduledClass>> DecodePopulation(int[] encodedPopulation, List<ScheduledClass> schedules, List<Room> rooms)
        {
            List<List<ScheduledClass>> population = new List<List<ScheduledClass>>();
            int individualSize = 800;

            for (int i = 0; i < encodedPopulation.Length; i += individualSize)
            {
                List<ScheduledClass> individual = new List<ScheduledClass>();
                for (int j = 0; j < individualSize; j++)
                {
                    if (encodedPopulation[i + j] == 1)
                    {
                        int weekDay = (j / 160) + 1; // Weekdays start from 1, so we add 1 to convert it to 1-based
                        int slot = (j % 160) / 20 + 1; // Slots start from 1, so we add 1 to convert it to 1-based
                        int roomId = (j % 160) % 20 + 1; // Room IDs start from 1, so we add 1 to convert it to 1-based

                        // Find the index of scheduledClasses
                        int scheduleIndex = i / individualSize;

                        // Get the corresponding course based on index
                        CourseClass course = schedules[j / 2].Course;

                        // Create a new ScheduledClass instance and add it to the individual
                        ScheduledClass scheduledClass = new ScheduledClass(course, weekDay, slot, roomId);
                        individual.Add(scheduledClass);
                    }
                }
                population.Add(individual);
            }

            return population;
        }
    }
}
