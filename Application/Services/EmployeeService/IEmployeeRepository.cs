using Application.Model.Request;
using Application.Model.Response;

namespace Application.Services
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeResponse>> GetAll();
        Task<List<EmployeeResponse>> Search(string Text);
        Task<EmployeeResponse> GetEmployee(int id);
        Task<EmployeeResponse> Add(EmployeeRequest employeeRequest);
        Task<EmployeeResponse> Edit(int id, EmployeeRequest employeeRequest);
        Task<bool> Delete(int id);
    }
}
