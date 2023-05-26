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

        [HttpGet("Test")]
        public IActionResult Test()
        {
            List<TestModel> testModel = new List<TestModel>();
            testModel.Add(new TestModel() { Desc = null, Column = null });

            if (testModel.Count == 0)
            {
                testModel.Add(new TestModel() { Desc = false, Column = "FullName" });
            }

            testModel.Add(new TestModel() { Desc = true, Column = "Age" });
            testModel.Add(new TestModel() { Desc = true, Column = "Address" });
            testModel.Add(new TestModel() { Desc = null, Column = "Mobile" });

            List<TestModel> model2 = new List<TestModel>();

            foreach (var model in testModel)
            {
                model2.Add(model);
            }

            return Ok(model2);
        }
    }

    public class TestModel
    {
        public bool? Desc { get; set; }
        public string? Column { get; set; }
    }
}
