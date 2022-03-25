using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sharff.ApiRest.Models;
using Sharff.Core.Services.Interfaces;
using Sharff.Domain.Model.Model;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Sharff.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : BaseController
    {
        private readonly ILogger<ExampleController> _logger;

        public readonly IExampleService _exampleService;

        public ExampleController(ILogger<ExampleController> logger, IMapper mapper, IExampleService exampleService) : base(mapper)
        {
            this._logger = logger;

            this._exampleService = exampleService;
        }

        [HttpGet()]
        public async Task<ActionResult<ExampleDto>> GetExample()
        {
            var result = new ResultDto();

            try
            {
                var resultService = await this._exampleService.GetExampleAsync();

                if (resultService == null)
                {
                    result = HelperStatus.RespuestaHelper(HttpStatusCode.NotFound, "vacio");
                    return BadRequest(result);
                }

                result.Payload = this._mapper.Map<ExampleDto>(resultService);
                result.StatusCode = HttpStatusCode.OK;
                result.Message = null;

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                this._logger.LogError(ex.Message, ex.InnerException);

                result = HelperStatus.RespuestaHelper(HttpStatusCode.ExpectationFailed, ex.Message);
                return BadRequest(result);
            }
        }

        [HttpPost()]
        public async Task<ActionResult<ExampleDto>> GetExampleById([FromBody] Example example)
        {
            var result = new ResultDto();

            try
            {
                var resultService = await this._exampleService.GetExampleByIdAsync(example);

                if (resultService == null)
                {
                    result = HelperStatus.RespuestaHelper(HttpStatusCode.NotFound, "vacio");
                    return BadRequest(result);
                }

                result.Payload = this._mapper.Map<ExampleDto>(resultService);
                result.StatusCode = HttpStatusCode.OK;
                result.Message = null;

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                this._logger.LogError(ex.Message, ex.InnerException);

                result = HelperStatus.RespuestaHelper(HttpStatusCode.ExpectationFailed, ex.Message);
                return BadRequest(result);
            }
        }
    }
}
