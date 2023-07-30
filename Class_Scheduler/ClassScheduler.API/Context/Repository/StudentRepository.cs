using ClassScheduler.API.Context;
using ClassScheduler.API.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.API
{
    public class StudentRepository : Repository<Student>, IRepository<Student>
    {
        public StudentRepository(ClassSchedulerContext dbContext) : base(dbContext)
        {
        }
    }
}
