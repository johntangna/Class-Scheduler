using AutoMapper;
using ClassScheduler.API.Context;
using ClassScheduler.API.Context.DTOs;

namespace ClassScheduler.API.Extensions
{
    public class AutoMapperProfile : MapperConfigurationExpression
    {
        public AutoMapperProfile() 
        {
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
            CreateMap<Student,StudentDTO>().ReverseMap();
        }
    }
}
