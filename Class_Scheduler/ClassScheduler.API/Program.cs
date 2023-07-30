using ClassScheduler.API.Context;
using ClassScheduler.API;
using ClassScheduler.API.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using ClassScheduler.API.Service;
using AutoMapper;
using ClassScheduler.API.Extensions;

namespace ClassScheduler.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // https://blog.csdn.net/qq_41415294/article/details/104294871
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ClassSchedulerContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("ClassSchedulerConnection");
                options.UseSqlite(connectionString);
            }).AddUnitOfWork<ClassSchedulerContext>()
            .AddCustomRepository<Lesson, LessonRepository>()
            .AddCustomRepository<Room, RoomRepository>()
            .AddCustomRepository<Student, StudentRepository>()
            .AddCustomRepository<Teacher, TeacherRepository>();

            // Add services to the container.
            builder.Services.AddTransient<ITeacherService, TeacherService>();
            builder.Services.AddTransient<IStudentService, StudentService>();

            var autoMapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new AutoMapperProfile());
            });

            builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            
            app.MapControllers();

            app.Run();
        }
    }
}