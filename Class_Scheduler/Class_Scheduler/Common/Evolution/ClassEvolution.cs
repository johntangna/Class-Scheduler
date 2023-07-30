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

        public Tuple<List<int>, int> Fitness(List<List<ScheduledClass>> population, int elite)
        {
            List<int> conflicts = new List<int>();
            List<int> index = new List<int>();
            List<int> bestResultIndex = new List<int>();
            int n = population[0].Count;

            foreach (List<ScheduledClass> schedule in population)
            {
                int conflict = 0;

                // 每个被分配的课程的fitness计算
                //for (int i = 0; i < n; i++)
                //{
                //    // 对于老师的时间而言，同一个老师上的课不能与其他年级相冲突
                //    // 需要用teacher的Id拿到对象
                //    //var teacherObj = RepositoryFacade.GetInstance.TeacherRepository.Get(schedule[i].TeacherId);
                //    //if (teacherObj != null)
                //    //{
                //    //    if (teacherObj.BusyTimeSlots[schedule[i].WeekDay, schedule[i].Slot] == 1)
                //    //        conflict++;
                //    //}
                //}

                // 两两比较
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        // 对于当前年级，同一个老师在同一时间段只能上一节课
                        if (schedule[i].Course.Teacher.Id == schedule[j].Course.Teacher.Id && schedule[i].Slot == schedule[j].Slot && schedule[i].WeekDay == schedule[j].WeekDay)
                            conflict++;

                        // 对于每个相同时间段的课程不能在同一个教室
                        if (schedule[i].RoomId == schedule[j].RoomId && schedule[i].Slot == schedule[j].Slot && schedule[i].WeekDay == schedule[j].WeekDay)
                            conflict++;

                        // 每个学生不能在相同的slot出现两次
                        if (schedule[i].Slot == schedule[j].Slot && schedule[i].WeekDay == schedule[j].WeekDay)
                        {
                            HashSet<Student> studentSet = new HashSet<Student>();
                            foreach (var item in schedule[i].Course.Students)
                                studentSet.Add(item);

                            HashSet<Student> studentSet2 = new HashSet<Student>();
                            foreach (var item in schedule[j].Course.Students)
                                studentSet.Add(item);

                            studentSet.IntersectWith(studentSet2);
                            if (studentSet.Count > 0)
                                conflict++;
                        }
                    }
                }

                conflicts.Add(conflict);
            }

            index = argsort(conflicts);
            for (int i = 0; i < elite; i++)
            {
                bestResultIndex.Add(index[i]);
            }
            return Tuple.Create(bestResultIndex, conflicts[index[0]]);
        }

        public List<ScheduledClass> Evolution(List<ScheduledClass> scheduledClasses, List<Room> rooms)
        {
            int best_fit = 0;
            List<int> eliteIndices = new List<int>();
            List<ScheduledClass> bestSchedule = new List<ScheduledClass>();
            List<List<ScheduledClass>> population = new List<List<ScheduledClass>>();
            population = InitPopulation(scheduledClasses, rooms);

            for (int i = 0; i < iteration_count; i++)
            {
                Tuple<List<int>, int> scheduleFitness = Fitness(population, elite_count);
                eliteIndices = scheduleFitness.Item1;
                best_fit = scheduleFitness.Item2;
                System.Diagnostics.Debug.WriteLine($"Iteration {i} produce best fit of {best_fit}");

                if (best_fit == 0)
                {
                    bestSchedule = population[eliteIndices[0]];
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
                        newSpecies = Mutate(newPopulation, rooms);
                    }
                    else
                    {
                        newSpecies = Crossover(newPopulation);
                    }
                    newPopulation.Add(newSpecies);
                }
                population = newPopulation;
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

        private List<ScheduledClass> Mutate(List<List<ScheduledClass>> population, List<Room> roomIds)
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
