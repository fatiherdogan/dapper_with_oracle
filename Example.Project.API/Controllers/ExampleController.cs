using Example.Project.Dto.ExampleDto;
using Example.Project.Service.ExampleServices;
using Microsoft.AspNetCore.Mvc;

namespace Example.Project.API.Controllers
{
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IexampleService _iExampleService;

        public ExampleController(IexampleService iExampleService)
        {
            _iExampleService = iExampleService;
        }

        [HttpGet]
        [Route("api/example")]
        public IActionResult Get()
        {
            return Ok(_iExampleService.GetAllData());
        }

        [HttpGet]
        [Route("api/example/{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_iExampleService.GetSingleData(id));
        }

        [HttpPost]
        [Route("api/example")]
        public IActionResult Post(TestDto model)
        {
            return Ok(_iExampleService.InsertData(model));
        }
    }
}
