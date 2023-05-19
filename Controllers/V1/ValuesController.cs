using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is version One.");
        }

        //[HttpGet]
        //public IActionResult GetV1()
        //{
        //    return Ok("This is version One.");
        //}
    }
}
