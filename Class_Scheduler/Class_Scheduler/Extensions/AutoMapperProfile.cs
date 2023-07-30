using AutoMapper;
using Class_Scheduler.Common.Models;
using Class_Scheduler.Common.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Extensions
{
    public class AutoMapperProfile : MapperConfigurationExpression
    {
        public AutoMapperProfile() 
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Subject, SubjectDTO>().ReverseMap();
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<TimeSlot, TimeSlotDTO>().ReverseMap();    
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserSetting, UserSettingDTO>().ReverseMap();
            CreateMap<CourseClass, CourseClassDTO>().ReverseMap();  
        }
    }
}
