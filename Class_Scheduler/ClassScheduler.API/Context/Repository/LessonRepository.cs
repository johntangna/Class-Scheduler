using ClassScheduler.API.Context;
using ClassScheduler.API.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.API
{
    public class LessonRepository : Repository<Lesson>, IRepository<Lesson>
    {
        public LessonRepository(ClassSchedulerContext dbContext) : base(dbContext)
        {
        }
    }
}
