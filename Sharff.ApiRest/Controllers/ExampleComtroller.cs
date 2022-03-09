using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sharff.ApiRest.Models;
using Sharff.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace Sharff.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleComtroller : ControllerBase
    {
        public readonly IMapper _mapper;

        public readonly IExampleService _exampleService;

        public ExampleComtroller(IMapper mapper, IExampleService exampleService)
        {
            this._mapper = mapper;
            this._exampleService = exampleService;
        }

        [HttpGet()]
        public async Task<ActionResult<ExampleDto>> GetExample()
        {
            var result = await this._exampleService.GetExampleAsync();
            return Ok(this._mapper.Map<ExampleDto>(result));
        }
    }
}
