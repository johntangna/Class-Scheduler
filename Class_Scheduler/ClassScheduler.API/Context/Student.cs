using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.API.Context
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
           
        public string EmailAddress { get; set; }

        public string GradeClass { get; set; }

        public string CourseSelected { get; set; }
    }
}
