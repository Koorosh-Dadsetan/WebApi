using Application.Model.Request;
using Application.Model.Response;
using AutoMapper;
using Domin.Contex;
using Domin.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TestDbContext _db;
        private readonly IMapper _mapper;
        public EmployeeRepository(TestDbContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }

        public async Task<EmployeeResponse> Add(EmployeeRequest employeeRequest)
        {
            var _em = _mapper.Map<EmployeeRequest, Employee>(employeeRequest);
            _db.Employees.Add(_em);
            await _db.SaveChangesAsync();

            var _entity = _mapper.Map<Employee, EmployeeResponse>(_em);
            return _entity;
        }

        public async Task<bool> Delete(int id)
        {
            var _employee = await _db.Employees.FindAsync(id);
            if (_employee != null)
            {
                _db.Employees.Remove(_employee);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<EmployeeResponse> Edit(int id, EmployeeRequest employeeRequest)
        {
            var _employee = await _db.Employees.FindAsync(id);
            if (_employee != null)
            {
                _employee.FullName = employeeRequest.FullName;
                _employee.Mobile = employeeRequest.Mobile;
                _employee.Age = employeeRequest.Age;
                _employee.Address = employeeRequest.Address;

                await _db.SaveChangesAsync();

                var _updated = _mapper.Map<Employee, EmployeeResponse>(_employee);
                return _updated;
            }
            return null;
        }

        public async Task<List<EmployeeResponse>> GetAll()
        {
            var _list = await _db.Employees.ToListAsync();
            var list = _mapper.Map<List<Employee>, List<EmployeeResponse>>(_list);
            return list;
        }

        public async Task<EmployeeResponse> GetEmployee(int id)
        {
            var _employee = await _db.Employees.FindAsync(id);
            var _entity = _mapper.Map<Employee, EmployeeResponse>(_employee);

            return _entity;
        }

        public async Task<List<EmployeeResponse>> Search(string Text)
        {
            var _list = await _db.Employees
                   .Where(a => a.FullName.Contains(Text) || a.Mobile.Contains(Text) || a.Age.ToString() == Text || a.Address.Contains(Text))
                     .ToListAsync();

            var _result = _mapper.Map<List<Employee>, List<EmployeeResponse>>(_list);
            return _result;
        }
    }
}
