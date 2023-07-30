using ClassScheduler.API.Context;
using ClassScheduler.API.Context.DTOs;
using ClassScheduler.API.Service;
using ClassScheduler.API.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ClassScheduler.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService service;

        public TeacherController(ITeacherService service)
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
        public async Task<ApiResponse> Add([FromBody] TeacherDTO teacher)
        {
            return await service.AddAsync(teacher);
        }

        [HttpPost] 
        public async Task<ApiResponse> Update([FromBody] TeacherDTO teacher)
        {
            return await service.UpdateAsync(teacher);
        }

        [HttpDelete]
        public async Task<ApiResponse> Delete(int id)
        {
            return await service.DeleteAsync(id);
        }
    }
}
