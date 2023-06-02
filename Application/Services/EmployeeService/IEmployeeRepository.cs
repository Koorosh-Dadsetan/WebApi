using Application.Model.Request;
using Application.Model.Response;
using Domin.Entity;

namespace Application.Services
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeResponse>> GetAll(Pagination? pagination, string? SearchText, Sort? sort);
        Task<List<Employee>> Search(string? Text);
        Task<EmployeeResponse> GetEmployee(int id);
        Task<EmployeeResponse> Add(EmployeeRequest employeeRequest);
        Task<EmployeeResponse> Edit(int id, EmployeeRequest employeeRequest);
        Task<bool> Delete(int id);
    }
}
