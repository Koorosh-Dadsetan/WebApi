using Application.Model.Request;
using Application.Model.Response;
using AutoMapper;
using Domin.Entity;

namespace Application.Config.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<EmployeeRequest, Employee>();
        }
    }
}
