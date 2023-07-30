using AutoMapper;
using ClassScheduler.API.Context;
using ClassScheduler.API.Context.DTOs;
using ClassScheduler.API.UnitOfWork;

namespace ClassScheduler.API.Service
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> AddAsync(StudentDTO entity)
        {
            try
            {
                var student = mapper.Map<Student>(entity);
                await unitOfWork.GetRepository<Student>().InsertAsync(student);
                if (await unitOfWork.SaveChangesAsync() > 0)
                    return new ApiResponse(true, entity);

                return new ApiResponse("Adding student data failed");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var repository = unitOfWork.GetRepository<Student>();
                var student = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id));
                repository.Delete(student);

                if (await unitOfWork.SaveChangesAsync() > 0)
                    return new ApiResponse(true, "");

                return new ApiResponse("Deleting student data failed");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> GetAsync(int id)
        {
            try
            {
                var repository = unitOfWork.GetRepository<Student>();
                var student = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id));
                return new ApiResponse(true, student);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> GetAllAsync()
        {
            try
            {
                var repository = unitOfWork.GetRepository<Student>();
                var student = await repository.GetAllAsync();
                return new ApiResponse(true, student);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> UpdateAsync(StudentDTO entity)
        {
            try
            {
                var repository = unitOfWork.GetRepository<Student>();
                var student = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(entity.Id));

                student.Name = entity.Name;
                student.EmailAddress = entity.EmailAddress;
                student.GradeClass = entity.GradeClass;
                student.CourseSelected = entity.CourseSelected;

                repository.Update(student);

                if (await unitOfWork.SaveChangesAsync() > 0)
                    return new ApiResponse(true, student);

                return new ApiResponse(false, "Updating student data failed");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message.ToString());
            }
        }
    }
}
