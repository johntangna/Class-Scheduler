namespace ClassScheduler.API.Service
{
    public interface IServiceBase<T>
    {
        Task<ApiResponse> GetAllAsync();

        Task<ApiResponse> GetAsync(int id);

        Task<ApiResponse> AddAsync(T entity);

        Task<ApiResponse> UpdateAsync(T entity);

        Task<ApiResponse> DeleteAsync(int id);
    }
}
