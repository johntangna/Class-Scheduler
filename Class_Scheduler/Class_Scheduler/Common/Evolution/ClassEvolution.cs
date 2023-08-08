using Class_Scheduler.Common.Models;
using Class_Scheduler.Common.Models.ClassScheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Class_Scheduler.Common.Evolution
{
    public class ClassEvolution
    {
        private int totalSlotsPerDay = 9; // 设置每天的时间段数量为9个
        private int population_size;

        private double mutation_prob;

        private int elite_count;

        private int iteration_count;

        private Random random;

        public int Population_size { get => population_size; set => population_size = value; }
        public double Mutation_prob { get => mutation_prob; set => mutation_prob = value; }
        public int Elite_count { get => elite_count; set => elite_count = value; }
        public int Iteration_count { get => iteration_count; set => iteration_count = value; }

        public ClassEvolution(int population_size, double mutation_prob, int elite_count)
        {
            random = new Random();
            Population_size = population_size;
            Mutation_prob = mutation_prob;
            Elite_count = elite_count;
            iteration_count = 500;
        }

        private List<List<ScheduledClass>> InitPopulation(List<ScheduledClass> schedules, List<Room> rooms)
        {
            List<List<ScheduledClass>> population = new List<List<ScheduledClass>>();
            for (int i = 0; i < Population_size; i++)
            {
                List<ScheduledClass> entities = new List<ScheduledClass>();
                foreach (var schedule in schedules)
                {
                    schedule.Random_Init(rooms);
                    entities.Add(schedule.DeepCopy());
                }
                population.Add(entities);
            }

            return population;
        }

        public List<int> argsort(List<int> list)
        {
            Dictionary<int, int> indexDict = new Dictionary<int, int>();
            List<int> indexList = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                indexDict.Add(i, list[i]);
            }
            var orderedDict = indexDict.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (var key in orderedDict.Keys)
            {
                indexList.Add(key);
            }
            return indexList;
        }

        private int checkSoftConflict1(ScheduledClass courseI, ScheduledClass courseJ)
        {
            // 假设一个教师每天上课的时段数不超过 5
            int maxDailySlots = 5;

            // 如果课程 I 和课程 J 是同一个老师的课程
            if (courseI.Course.Teacher.Id == courseJ.Course.Teacher.Id)
            {
                // 统计当天老师已安排的课程时段数
                Dictionary<int, int> dailySlotsCount = new Dictionary<int, int>();
                for (int i = 0; i < totalSlotsPerDay; i++)
                {
                    dailySlotsCount[i] = 0;
                }

                // 统计当前课程 I 的一天内每个时段的课程数
                foreach (ScheduledClass course in new List<ScheduledClass> { courseI, courseJ })
                {
                    dailySlotsCount[course.Slot]++;
                }
                // 计算超过阈值的时段数量
                int overLimitSlots = 0;
                foreach (int count in dailySlotsCount.Values)
                {
                    if (count > maxDailySlots)
                    {
                        overLimitSlots += count - maxDailySlots;
                    }
                }

                // 软性冲突评估值为超过阈值的时段数量
                return overLimitSlots;
            }

            return 0; // 如果课程 I 和课程 J 不是同一个老师的课程，返回 0
        }

        private int checkSoftConflict2(ScheduledClass courseI, ScheduledClass courseJ)
        {
            // 假设课程 I 和课程 J 是同一门课程的不同时间段
            if (courseI.Course.Id == courseJ.Course.Id && courseI.WeekDay == courseJ.WeekDay)
            {
                // 假设一个课程的上下午连堂差别为 1
                int continuousThreshold = 1;

                int slotDiff = Math.Abs(courseI.Slot - courseJ.Slot);

                // 如果连堂差别大于阈值，返回连堂差别
                if (slotDiff > continuousThreshold)
                {
                    return slotDiff;
                }
            }

            return 0; // 如果课程 I 和课程 J 不满足连堂条件，返回 0
        }

        public Tuple<List<int>, int> Fitness(List<List<ScheduledClass>> population, int elite)
        {
            List<int> conflicts = new List<int>();
            List<int> index = new List<int>();
            List<int> bestResultIndex = new List<int>();
            int n = population[0].Count;
            ScheduledClass scheduledClassInstance = new ScheduledClass(); // 创建 ScheduledClass 类的实例
            int[] encodedPopulation = scheduledClassInstance.EncodePopulation(population); // 使用对象调用方法

            // 提前获取老师和学生的时间冲突信息
            Dictionary<int, Dictionary<(int, int), int>> teacherBusySlots = new Dictionary<int, Dictionary<(int, int), int>>();
            Dictionary<(int, int), List<int>> slotStudentMap = new Dictionary<(int, int), List<int>>();

            foreach (var schedule in population[0])
            {
                var courseId = schedule.Course.Id;
                var teacherId = schedule.Course.Teacher.Id;
                var roomId = schedule.RoomId;
                var weekDay = schedule.WeekDay;
                var slot = schedule.Slot;

                if (!teacherBusySlots.ContainsKey(teacherId))
                {
                    teacherBusySlots[teacherId] = new Dictionary<(int, int), int>();
                }

                if (!teacherBusySlots[teacherId].ContainsKey((weekDay, slot)))
                {
                    teacherBusySlots[teacherId][(weekDay, slot)] = 0;
                }

                teacherBusySlots[teacherId][(weekDay, slot)]++;

                var slotKey = (weekDay, slot);
                if (!slotStudentMap.ContainsKey(slotKey))
                {
                    slotStudentMap[slotKey] = new List<int>();
                }

                foreach (var student in schedule.Course.Students)
                {
                    if (!slotStudentMap[slotKey].Contains(student.Id))
                    {
                        slotStudentMap[slotKey].Add(student.Id);
                    }
                }
            }

            foreach (List<ScheduledClass> schedule in population)
            {
                int conflict = 0;
                int softConflict1 = 0; // 软性冲突1：教师一天最多5节课
                int softConflict2 = 0; // 软性冲突2：课程的连堂情况
                double stdDeviation = 0; // 用于存储课程分布的标准差

                // 两两比较
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        var courseI = schedule[i];
                        var courseJ = schedule[j];
                        var slotKeyI = (courseI.WeekDay, courseI.Slot);
                        var slotKeyJ = (courseJ.WeekDay, courseJ.Slot);

                        // 对于当前年级，同一个老师在同一时间段只能上一节课
                        if (courseI.Course.Teacher.Id == courseJ.Course.Teacher.Id && courseI.Slot == courseJ.Slot && courseI.WeekDay == courseJ.WeekDay)
                            conflict++;

                        // 对于每个相同时间段的课程不能在同一个教室
                        if (courseI.RoomId == courseJ.RoomId && courseI.Slot == courseJ.Slot && courseI.WeekDay == courseJ.WeekDay)
                            conflict++;

                        // 每个学生不能在相同的slot出现两次
                        if (courseI.Slot == courseJ.Slot && courseI.WeekDay == courseJ.WeekDay)
                        {
                            var commonStudents = slotStudentMap[slotKeyI].Intersect(slotStudentMap[slotKeyJ]);
                            if (commonStudents.Count() > 0)
                                conflict++;
                        }
                    }
                }

                // 计算平均分布课程数量的冲突
                List<int> coursesPerSlot = new List<int>(new int[totalSlotsPerDay]); // 初始化每个时间段的课程数量为 0
                foreach (var course in schedule)
                {
                    coursesPerSlot[course.Slot]++;
                }
                // 计算平均课程数量
                double averageCourses = (double)coursesPerSlot.Sum() / totalSlotsPerDay;

                foreach (var coursesCount in coursesPerSlot)
                {
                    stdDeviation += Math.Pow(coursesCount - averageCourses, 2);
                }
                stdDeviation = Math.Sqrt(stdDeviation / totalSlotsPerDay);

                conflict += (int)stdDeviation;
                // 添加软性冲突1的计算
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        softConflict1 += checkSoftConflict1(schedule[i], schedule[j]);
                    }
                }

                // 添加软性冲突2的计算
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        softConflict2 += checkSoftConflict2(schedule[i], schedule[j]);
                    }
                }

                conflicts.Add(conflict);
                conflicts.Add(softConflict1);
                conflicts.Add(softConflict2); // 将软性冲突2计算结果加入到适应度函数中
            }

            index = argsort(conflicts);
            for (int i = 0; i < elite; i++)
            {
                bestResultIndex.Add(index[i]);
            }
            return Tuple.Create(bestResultIndex, conflicts[index[0]]);
        }

        private bool CheckTeacherAvailability(ScheduledClass scheduledClass, Dictionary<int, List<int>> teacherBusyTimeSlots)
        {
            int teacherId = scheduledClass.Course.Teacher.Id;
            int slotId = scheduledClass.WeekDay * totalSlotsPerDay + scheduledClass.Slot;

            if (teacherBusyTimeSlots.ContainsKey(teacherId) && teacherBusyTimeSlots[teacherId].Contains(slotId))
            {
                return false; // 时间冲突，返回false表示老师不可用
            }

            return true; // 没有时间冲突，返回true表示老师可用
        }

        public List<ScheduledClass> Evolution(List<ScheduledClass> scheduledClasses, List<Room> rooms, Dictionary<int, List<int>> teacherBusyTimeSlots)
        {
            int best_fit = 0;
            List<int> eliteIndices = new List<int>();
            List<ScheduledClass> bestSchedule = new List<ScheduledClass>();
            List<List<ScheduledClass>> population = new List<List<ScheduledClass>>();
            population = InitPopulation(scheduledClasses, rooms);
            int[] encodedPopulation = scheduledClasses[0].EncodePopulation(population); // Encode initial population

            for (int i = 0; i < iteration_count; i++)
            {
                Tuple<List<int>, int> scheduleFitness = Fitness(population, elite_count);

                eliteIndices = scheduleFitness.Item1;
                best_fit = scheduleFitness.Item2;
                System.Diagnostics.Debug.WriteLine($"Iteration {i} produce best fit of {best_fit}");

                if (best_fit == 0)
                {
                    bestSchedule = scheduledClasses[0].DecodePopulation(encodedPopulation, scheduledClasses, rooms)[eliteIndices[0]];
                    break;
                }

                List<List<ScheduledClass>> newPopulation = new List<List<ScheduledClass>>();
                foreach (int index in eliteIndices)
                {
                    newPopulation.Add(population[index]);
                }

                while (newPopulation.Count < population_size)
                {
                    List<ScheduledClass> newSpecies = new List<ScheduledClass>();
                    if (random.NextDouble() < mutation_prob)
                    {
                        // mutation
                        newSpecies = Mutate(newPopulation, rooms, teacherBusyTimeSlots);
                    }
                    else
                    {
                        newSpecies = Crossover(newPopulation);
                    }
                    newPopulation.Add(newSpecies);
                }

                encodedPopulation = scheduledClasses[0].EncodePopulation(newPopulation); // Update encoded population
            }

            return bestSchedule;
        }



        private List<ScheduledClass> Crossover(List<List<ScheduledClass>> newPopulation)
        {
            int eliteIndex1 = random.Next(0, elite_count);
            int eliteIndex2 = random.Next(0, elite_count);
            int selection = random.Next(0, 2);

            List<ScheduledClass> eliteSchedules1 = new List<ScheduledClass>();
            List<ScheduledClass> eliteSchedules2 = new List<ScheduledClass>();

            foreach (var item in newPopulation[eliteIndex1])
                eliteSchedules1.Add(item.DeepCopy());

            eliteSchedules2 = newPopulation[eliteIndex2];

            for (int i = 0; i < eliteSchedules1.Count; i++)
            {
                if (selection == 0)
                {
                    eliteSchedules1[i].WeekDay = eliteSchedules2[i].WeekDay;
                    eliteSchedules1[i].Slot = eliteSchedules2[i].Slot;
                }
                else
                {
                    eliteSchedules1[i].RoomId = eliteSchedules2[i].RoomId;
                }
            }

            return eliteSchedules1;
        }

        // 老师在该时间段不可用，进行重新安排
        // 这里可以实现一个逻辑，随机选择其他时间段进行安排，如果不行，就再随机配一个，直到分到一个可以的时间
        private void RescheduleIfTeacherNotAvailable(ScheduledClass scheduledClass, Dictionary<int, List<int>> teacherBusyTimeSlots, List<Room> rooms)
        {
            int teacherId = scheduledClass.Course.Teacher.Id;
            int originalSlot = scheduledClass.Slot;
            int originalWeekDay = scheduledClass.WeekDay;

            // Create a list of available time slots for the teacher
            List<(int, int)> availableSlots = new List<(int, int)>();
            for (int slot = 0; slot < totalSlotsPerDay; slot++)
            {
                int slotId = originalWeekDay * totalSlotsPerDay + slot;
                if (!teacherBusyTimeSlots.ContainsKey(teacherId) || !teacherBusyTimeSlots[teacherId].Contains(slotId))
                {
                    availableSlots.Add((originalWeekDay, slot));
                }
            }

            if (availableSlots.Count > 0)
            {
                // Choose a random available time slot
                int randomIndex = random.Next(0, availableSlots.Count);
                var newSlot = availableSlots[randomIndex];

                scheduledClass.WeekDay = newSlot.Item1;
                scheduledClass.Slot = newSlot.Item2;
            }
            else
            {
                // If no available slots on the same day, try another day and slot
                int attempts = 0;
                while (attempts < 10)  // You can adjust the number of attempts as needed
                {
                    int randomDay = random.Next(0, 5);  // Assuming weekdays are represented as 0 to 4
                    int randomSlot = random.Next(0, totalSlotsPerDay);

                    int slotId = randomDay * totalSlotsPerDay + randomSlot;
                    if (!teacherBusyTimeSlots.ContainsKey(teacherId) || !teacherBusyTimeSlots[teacherId].Contains(slotId))
                    {
                        scheduledClass.WeekDay = randomDay;
                        scheduledClass.Slot = randomSlot;
                        break;
                    }

                    attempts++;
                }
            }

            // Optionally, you can also check and update the room if necessary
            // ...
        }

        private List<ScheduledClass> Mutate(List<List<ScheduledClass>> population, List<Room> roomIds, Dictionary<int, List<int>> teacherBusyTimeSlots)
        {
            List<ScheduledClass> newSpecies = new List<ScheduledClass>();
            int elite_index = random.Next(0, elite_count);

            foreach (var item in population[elite_index])
            {
                newSpecies.Add(item.DeepCopy());
            }

            foreach (var item in newSpecies)
            {
                int prob = random.Next(0, 3);
                double upOrDown = random.NextDouble();
                if (prob == 0)
                {
                    item.RoomId = roomIds.ElementAt(random.Next(0, roomIds.Count - 1)).Id;
                }
                else if (prob == 1)
                {
                    item.Slot = ApplyPropVariation(item.Slot, 9, upOrDown > 0.5);
                }
                else
                {
                    item.WeekDay = ApplyPropVariation(item.WeekDay, 9, upOrDown > 0.5);
                }
                // 检查老师的可用性
                if (!CheckTeacherAvailability(item, teacherBusyTimeSlots))
                {
                    // 老师在该时间段不可用，进行重新安排
                    RescheduleIfTeacherNotAvailable(item, teacherBusyTimeSlots, roomIds);
                }
            }

            return newSpecies;
        }

        private int ApplyPropVariation(int val, int range, bool isPositive)
        {
            if (isPositive)
            {
                if (val < range) val++;
                else val--;
            }
            else
            {
                if (val - 1 > 0) val--;
                else val++;
            }

            return val;
        }
    }
}
