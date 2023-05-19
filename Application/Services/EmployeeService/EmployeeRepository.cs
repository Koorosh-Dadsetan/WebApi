using Application.Model.Response;
using Azure;
using Domin.Contex;
using Domin.Entity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection;

namespace Application.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TestDbContext _db;

        public EmployeeRepository(TestDbContext context)
        {
            _db = context;
        }

        public async Task<List<EmployeeResponse>> GetAll()
        {
            List<Employee> _list = await _db.Employees.ToListAsync();

            List<EmployeeResponse> employeeResponse = new List<EmployeeResponse>();

            foreach (var item in _list)
            {
                EmployeeResponse current = new EmployeeResponse()
                {
                    Id = item.Id,
                    FullName = item.FullName,
                    Mobile = item.Mobile,
                    Age = item.Age,
                    Address = item.Address
                };

                employeeResponse.Add(current);
            }

            return employeeResponse;
        }

        public async Task<EmployeeResponse> GetEmployee(int id)
        {
            var _employee = await _db.Employees.FindAsync(id);

            EmployeeResponse employeeResponse = new EmployeeResponse()
            {
                Id = _employee.Id,
                FullName = _employee.FullName,
                Mobile = _employee.Mobile,
                Age = _employee.Age,
                Address = _employee.Address,
            };

            return employeeResponse;
        }
    }
}
