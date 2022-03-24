using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sharff.ApiRest.Models;
using Sharff.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace Sharff.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        public readonly IMapper _mapper;

        public readonly IExampleService _exampleService;

        public ExampleController(IMapper mapper, IExampleService exampleService)
        {
            this._mapper = mapper;
            this._exampleService = exampleService;
        }

        [HttpGet()]
        public async Task<ActionResult<ExampleDto>> GetExample()
        {
            var resultService = await this._exampleService.GetExampleAsync();

            var result = new ResultDto
            {
                StatusCode = 200
            };
            result.Payload = this._mapper.Map<ExampleDto>(resultService);
            return Ok(result);
        }
    }
}
