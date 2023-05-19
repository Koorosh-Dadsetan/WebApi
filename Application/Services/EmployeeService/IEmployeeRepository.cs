using Application.Model.Response;

namespace Application.Services
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeResponse>> GetAll();
        Task<EmployeeResponse> GetEmployee(int id);
    }
}
