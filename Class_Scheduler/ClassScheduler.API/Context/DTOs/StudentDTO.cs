using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.API.Context.DTOs
{
    public class StudentDTO : BaseDTO
    {
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string GradeClass { get; set; }

        public string CourseSelected { get; set; }
    }
}
