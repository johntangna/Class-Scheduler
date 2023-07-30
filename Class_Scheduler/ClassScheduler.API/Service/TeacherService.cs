using AutoMapper;
using ClassScheduler.API.Context;
using ClassScheduler.API.Context.DTOs;
using ClassScheduler.API.UnitOfWork;

namespace ClassScheduler.API.Service
{

    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> AddAsync(TeacherDTO entity)
        {
            try
            {
                var teacher = mapper.Map<Teacher>(entity);
                await unitOfWork.GetRepository<Teacher>().InsertAsync(teacher);
                if (await unitOfWork.SaveChangesAsync() > 0)
                    return new ApiResponse(true, entity);

                return new ApiResponse("Adding teacher data failed");
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
                var repository = unitOfWork.GetRepository<Teacher>();
                var teacher = await repository.GetFirstOrDefaultAsync(predicate: x=>x.Id.Equals(id));
                repository.Delete(teacher);

                if (await unitOfWork.SaveChangesAsync() > 0)
                    return new ApiResponse(true, "");

                return new ApiResponse("Deleting teacher data failed");
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
                var repository = unitOfWork.GetRepository<Teacher>();
                var teacher = await repository.GetFirstOrDefaultAsync(predicate: x=>x.Id.Equals(id));
                return new ApiResponse(true, teacher);
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
                var repository = unitOfWork.GetRepository<Teacher>();
                var teachers = await repository.GetAllAsync();
                return new ApiResponse(true, teachers);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> UpdateAsync(TeacherDTO entity)
        {
            try
            {
                var repository = unitOfWork.GetRepository<Teacher>();
                var teacher = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(entity.Id));

                teacher.Subject = entity.Subject;
                teacher.EmailAddress = entity.EmailAddress;
                teacher.Name = entity.Name;

                repository.Update(teacher);

                if (await unitOfWork.SaveChangesAsync() > 0)
                    return new ApiResponse(true, teacher);

                return new ApiResponse(false, "Updating teacher data failed");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message.ToString());
            }
        }
    }
}
