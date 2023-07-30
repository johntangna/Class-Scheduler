using ClassScheduler.API.Context;
using ClassScheduler.API.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.API
{
    public class TeacherRepository : Repository<Teacher>, IRepository<Teacher>
    {
        public TeacherRepository(ClassSchedulerContext dbContext) : base(dbContext)
        {
        }
    }
}
