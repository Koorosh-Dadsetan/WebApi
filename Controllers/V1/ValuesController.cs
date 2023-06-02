using Domin.Contex;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ValuesController : ControllerBase
    {
        private readonly TestDbContext _db;
        public ValuesController(TestDbContext testDbContext)
        {
            _db = testDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is version One.");
        }

        [HttpGet("Test")]
        public IActionResult Test()
        {
            var ds = _db.Employees.FromSql($"SELECT * FROM Employees").ToList();
            return Ok(ds);
        }

        [HttpGet("AccBankBranch")]
        public IActionResult AccBankBranch()
        {
            return BadRequest("شعبه بانک یافت نشد");
        }
    }
}
