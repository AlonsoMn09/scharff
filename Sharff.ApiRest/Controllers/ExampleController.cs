using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sharff.ApiRest.Models;
using Sharff.Core.Services.Interfaces;
using Sharff.Domain.Model.DbModel;

using Shartff.Shared.ApiRest.Base;
using System.Threading.Tasks;

namespace Sharff.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ExampleController : BaseController
    {
        private readonly ILogger<ExampleController> _logger;

        public readonly IExampleService _exampleService;

        public readonly ILogService _logService;

        public ExampleController(ILogger<ExampleController> logger, ILogService logService, IMapper mapper, IExampleService exampleService) : base(mapper)
        {
            this._logger = logger;
            this._logService = logService;
            this._exampleService = exampleService;
           
        }

        [HttpGet()]
        public async Task<ActionResult<ExampleDto>> GetExample()
        {
            var log = new LogDto
            { 
            LogFecha = System.DateTime.Now.ToString()
        };
            var result = new ResultDto
            {
                StatusCode = 200
            };
        
            try
            {
                var resultService = await this._exampleService.GetExampleAsync();

                
                await this._logService.CreateAsync(this._mapper.Map<TblLog>(log));
                
                result.Payload = this._mapper.Map<ExampleDto>(resultService);
                
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                this._logger.LogError(ex.Message, ex.InnerException);
                log.LogMessage = ex.Message;
                await this._logService.CreateAsync(this._mapper.Map<TblLog>(log));
            }
            return BadRequest(result);
        }
    }
}
