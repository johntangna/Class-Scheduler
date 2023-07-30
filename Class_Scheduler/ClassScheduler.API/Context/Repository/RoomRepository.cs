using ClassScheduler.API.Context;
using ClassScheduler.API.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.API
{
    public class RoomRepository : Repository<Room>, IRepository<Room>
    {
        public RoomRepository(ClassSchedulerContext dbContext) : base(dbContext)
        {
        }
    }
}
