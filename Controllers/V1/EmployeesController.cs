using Microsoft.AspNetCore.Mvc;
using Application.Services;

namespace WebApi.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _service;

        public EmployeesController(IEmployeeRepository contex)
        {
            _service = contex;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            return Ok(await _service.GetEmployee(id));
        }
    }
}
