using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sharff.ApiRest.Models;
using Sharff.Core.Services.Interfaces;
using Shartff.Shared.ApiRest.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharff.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : BaseController
    {

        private readonly ILogger<LogController> _logger;

        public readonly ILogService _logservice;

        public LogController(ILogger<LogController> logger, IMapper mapper, ILogService logService) : base(mapper)
        {
            this._logger = logger;

            this._logservice = logService;
        }

        [HttpGet("{fecha}")]
        public async Task<ActionResult<LogDto>> GetFech(DateTime? fecha)
        {
            var result = new ResultDto
            {
                StatusCode = 200
            };
            try
            {
                var resultService = await this._logservice.GetFechAsync(fecha);

                return Ok(resultService);
            }
            catch (System.Exception ex)
            {
                this._logger.LogError(ex.Message, ex.InnerException);
            }
            return BadRequest(result);
        }


    }
}
