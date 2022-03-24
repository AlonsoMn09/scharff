using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sharff.ApiRest.Models;
using Sharff.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace Sharff.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly ILogger<ExampleController> _logger;

        public readonly IMapper _mapper;

        public readonly IExampleService _exampleService;

        public ExampleController(ILogger<ExampleController> logger, IMapper mapper, IExampleService exampleService)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._exampleService = exampleService;
        }

        [HttpGet()]
        public async Task<ActionResult<ExampleDto>> GetExample()
        {
            var result = new ResultDto
            {
                StatusCode = 200
            };

            try
            {
                var resultService = await this._exampleService.GetExampleAsync();
                result.Payload = this._mapper.Map<ExampleDto>(resultService);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                this._logger.LogError(ex.Message, ex.InnerException);
            }
            return BadRequest(result);
        }
    }
}
