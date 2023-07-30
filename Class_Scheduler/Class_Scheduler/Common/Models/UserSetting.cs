using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Class_Scheduler.Common.Models
{
    public class UserSetting : BindableBase
    {
        private User user;
        public User User
        {
            get { return user; } 
            set { user = value; RaisePropertyChanged(); }
        }

        private string importDataPath;

        public string ImportDataPath
        {
            get { return importDataPath; }
            set { importDataPath = value; RaisePropertyChanged(); }
        }

        private int classDivisionBaseline;

        /// <summary>
        /// Maximum number of students in a class
        /// </summary>
        public int ClassDivisionBaseline
        {
            get { return classDivisionBaseline; }
            set { classDivisionBaseline = value; RaisePropertyChanged(); }
        }

        private int populationSize;

        public int PopulationSize
        {
            get { return populationSize; }
            set { populationSize = value; RaisePropertyChanged(); }
        }

        private double mutationProb;

        public double MutationProb
        {
            get { return mutationProb; }
            set { mutationProb = value; RaisePropertyChanged(); }
        }

    }
}
