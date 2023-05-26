using Application.Model.Request;
using Application.Model.Response;
using AutoMapper;
using Domin.Contex;
using Domin.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
        public List<Employee>? _list { get; set; }

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

        public async Task<List<EmployeeResponse>> GetAll(Pagination? pagination, string? SearchText, Sort? sort)
        {
            if (pagination.PageIndex != null && pagination.PageSize != null)
            {
                if (SearchText != null)
                {
                    this._list = await Search(SearchText);

                    if (sort.Column != null || sort.Desc != null)
                    {
                        if (sort.Desc == true)
                        {
                            switch (sort.Column)
                            {
                                case "FullName":
                                    this._list = this._list.OrderByDescending(a => a.FullName).Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToList();
                                    break;
                                case "Mobile":
                                    this._list = this._list.OrderByDescending(a => a.Mobile).Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToList();
                                    break;
                                case "Age":
                                    this._list = this._list.OrderByDescending(a => a.Age)
                                        .Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToList();
                                    break;
                                case "Address":
                                    this._list = this._list.OrderByDescending(a => a.Address)
                                        .Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToList();
                                    break;
                                default:
                                    this._list = this._list.OrderByDescending(a => a.FullName)
                                        .Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToList();
                                    break;
                            }
                        }
                        else
                        {
                            switch (sort.Column)
                            {
                                case "FullName":
                                    this._list = this._list.OrderBy(a => a.FullName).Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToList();
                                    break;
                                case "Mobile":
                                    this._list = this._list.OrderBy(a => a.Mobile).Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToList();
                                    break;
                                case "Age":
                                    this._list = this._list.OrderBy(a => a.Age).Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToList();
                                    break;
                                case "Address":
                                    this._list = this._list.OrderBy(a => a.Address)
                                        .Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToList();
                                    break;
                                default:
                                    this._list = this._list.OrderBy(a => a.FullName)
                                        .Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToList();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        this._list = this._list.OrderBy(a => a.FullName)
                            .Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToList();
                    }

                }
                else
                {
                    if (sort.Column != null || sort.Desc != null)
                    {
                        if (sort.Desc == true)
                        {
                            switch (sort.Column)
                            {
                                case "FullName":
                                    this._list = await _db.Employees.OrderByDescending(a => a.FullName)
                                        .Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToListAsync();
                                    break;
                                case "Mobile":
                                    this._list = await _db.Employees.OrderByDescending(a => a.Mobile)
                                        .Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToListAsync();
                                    break;
                                case "Age":
                                    this._list = await _db.Employees.OrderByDescending(a => a.Age)
                                        .Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToListAsync();
                                    break;
                                case "Address":
                                    this._list = await _db.Employees.OrderByDescending(a => a.Address)
                                        .Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToListAsync();
                                    break;
                                default:
                                    this._list = await _db.Employees.OrderByDescending(a => a.FullName)
                                        .Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToListAsync();
                                    break;
                            }
                        }
                        else
                        {
                            switch (sort.Column)
                            {
                                case "FullName":
                                    this._list = await _db.Employees.OrderBy(a => a.FullName)
                                        .Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToListAsync();
                                    break;
                                case "Mobile":
                                    this._list = await _db.Employees.OrderBy(a => a.Mobile)
                                        .Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToListAsync();
                                    break;
                                case "Age":
                                    this._list = await _db.Employees.OrderBy(a => a.Age)
                                        .Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToListAsync();
                                    break;
                                case "Address":
                                    this._list = await _db.Employees.OrderBy(a => a.Address)
                                        .Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToListAsync();
                                    break;
                                default:
                                    this._list = await _db.Employees.OrderBy(a => a.FullName)
                                        .Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToListAsync();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        this._list = await _db.Employees.OrderBy(a => a.FullName)
                            .Skip((int)pagination.PageIndex * (int)pagination.PageSize).Take((int)pagination.PageSize).ToListAsync();
                    }
                }
            }
            else
            {
                if (SearchText != null)
                {
                    this._list = await Search(SearchText);

                    if (sort.Column != null || sort.Desc != null)
                    {
                        if (sort.Desc == true)
                        {
                            switch (sort.Column)
                            {
                                case "FullName":
                                    this._list = this._list.OrderByDescending(a => a.FullName).ToList();
                                    break;
                                case "Mobile":
                                    this._list = this._list.OrderByDescending(a => a.Mobile).ToList();
                                    break;
                                case "Age":
                                    this._list = this._list.OrderByDescending(a => a.Age).ToList();
                                    break;
                                case "Address":
                                    this._list = this._list.OrderByDescending(a => a.Address).ToList();
                                    break;
                                default:
                                    this._list = this._list.OrderByDescending(a => a.FullName).ToList();
                                    break;
                            }
                        }
                        else
                        {
                            switch (sort.Column)
                            {
                                case "FullName":
                                    this._list = this._list.OrderBy(a => a.FullName).ToList();
                                    break;
                                case "Mobile":
                                    this._list = this._list.OrderBy(a => a.Mobile).ToList();
                                    break;
                                case "Age":
                                    this._list = this._list.OrderBy(a => a.Age).ToList();
                                    break;
                                case "Address":
                                    this._list = this._list.OrderBy(a => a.Address).ToList();
                                    break;
                                default:
                                    this._list = this._list.OrderBy(a => a.FullName).ToList();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        this._list = this._list.OrderBy(a => a.FullName).ToList();
                    }
                }
                else
                {
                    if (sort.Column != null || sort.Desc != null)
                    {
                        if (sort.Desc == true)
                        {
                            switch (sort.Column)
                            {
                                case "FullName":
                                    this._list = await _db.Employees.OrderByDescending(a => a.FullName).ToListAsync();
                                    break;
                                case "Mobile":
                                    this._list = await _db.Employees.OrderByDescending(a => a.Mobile).ToListAsync();
                                    break;
                                case "Age":
                                    this._list = await _db.Employees.OrderByDescending(a => a.Age).ToListAsync();
                                    break;
                                case "Address":
                                    this._list = await _db.Employees.OrderByDescending(a => a.Address).ToListAsync();
                                    break;
                                default:
                                    this._list = await _db.Employees.OrderByDescending(a => a.FullName).ToListAsync();
                                    break;
                            }
                        }
                        else
                        {
                            switch (sort.Column)
                            {
                                case "FullName":
                                    this._list = await _db.Employees.OrderBy(a => a.FullName).ToListAsync();
                                    break;
                                case "Mobile":
                                    this._list = await _db.Employees.OrderBy(a => a.Mobile).ToListAsync();
                                    break;
                                case "Age":
                                    this._list = await _db.Employees.OrderBy(a => a.Age).ToListAsync();
                                    break;
                                case "Address":
                                    this._list = await _db.Employees.OrderBy(a => a.Address).ToListAsync();
                                    break;
                                default:
                                    this._list = await _db.Employees.OrderBy(a => a.FullName).ToListAsync();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        this._list = await _db.Employees.OrderBy(a => a.FullName).ToListAsync();
                    }
                }
            }

            var list = _mapper.Map<List<Employee>, List<EmployeeResponse>>(_list);
            return list;
        }

        public async Task<EmployeeResponse> GetEmployee(int id)
        {
            var _employee = await _db.Employees.FindAsync(id);
            var _entity = _mapper.Map<Employee, EmployeeResponse>(_employee);

            return _entity;
        }

        public async Task<List<Employee>> Search(string? Text)
        {
            return await _db.Employees
                      .Where(a => a.FullName.Contains(Text) || a.Mobile.Contains(Text) || a.Age.ToString().Contains(Text) || a.Address.Contains(Text))
                        .ToListAsync();
        }
    }
}
