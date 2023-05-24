using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Model.Request;
using Application.Model.Response;

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

        [HttpGet("Search{text}")]
        public async Task<IActionResult> Search(string text)
        {
            return Ok(await _service.Search(text));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            return Ok(await _service.GetEmployee(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeRequest employeeRequest)
        {
            return Ok(await _service.Add(employeeRequest));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, EmployeeRequest employeeRequest)
        {
            return Ok(await _service.Edit(id, employeeRequest));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
