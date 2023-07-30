using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.API.Context
{
    public class ClassSchedulerContext : DbContext
    {
        public ClassSchedulerContext(DbContextOptions<ClassSchedulerContext> options) : base(options) 
        {
        }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Room> Rooms { get; set; }

    }
}
