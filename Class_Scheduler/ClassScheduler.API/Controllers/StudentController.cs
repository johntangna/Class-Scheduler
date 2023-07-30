using ClassScheduler.API.Context.DTOs;
using ClassScheduler.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService service;

        public StudentController(IStudentService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ApiResponse> Get(int id)
        {
            return await service.GetAsync(id);
        }

        [HttpGet]
        public async Task<ApiResponse> GetAll()
        {
            return await service.GetAllAsync();
        }

        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] StudentDTO student)
        {
            return await service.AddAsync(student);
        }

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] StudentDTO student)
        {
            return await service.UpdateAsync(student);
        }

        [HttpDelete]
        public async Task<ApiResponse> Delete(int id)
        {
            return await service.DeleteAsync(id);
        }
    }
}
