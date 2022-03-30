using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sharff.ApiRest.Models;
using Sharff.Core.Services.Interfaces;
using Sharff.Domain.Model.DbModel;
using Sharff.Domain.Model.Model;
using Shartff.Shared.ApiRest.Base;
using System;
using System.Collections.Generic;
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
        public async Task<ActionResult> GetExample()
        {
            var result = HelperStatus.RespuestaHelper<IEnumerable<ExampleDto>>(new List<ExampleDto>());
            var resultService = await this._exampleService.GetExampleAsync();

            if (resultService == null)
            {
                result = HelperStatus.RespuestaHelper<IEnumerable<ExampleDto>>(new List<ExampleDto>(), HttpStatusCode.NotFound, "vacio");
                return NotFound(result);
            }

            result = HelperStatus.RespuestaHelper<IEnumerable<ExampleDto>>(this._mapper.Map<IEnumerable<ExampleDto>>(resultService));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetExampleById(string id)
        {
            var result = HelperStatus.RespuestaHelper<ExampleDto>(new ExampleDto());
            var resultService = await this._exampleService.GetExampleByIdAsync(id);

            if (resultService == null)
            {
                result = HelperStatus.RespuestaHelper<ExampleDto>(new ExampleDto(), HttpStatusCode.NotFound, "vacio");
                return NotFound(result);
            }

            result = HelperStatus.RespuestaHelper<ExampleDto>(this._mapper.Map<ExampleDto>(resultService));
            return Ok(result);
        }

        [HttpPost()]
        public async Task<ActionResult> Create([FromBody] ExampleDto dto)
        {
            var result = HelperStatus.RespuestaHelper<bool>(new bool());
            var resultService = await this._exampleService.CreateAsync(this._mapper.Map<TblExampleFedex>(dto));

            if (resultService == false)
            {
                result = HelperStatus.RespuestaHelper<bool>(false, HttpStatusCode.NotFound, "vacio");
                return NotFound(result);
            }

            result = HelperStatus.RespuestaHelper<bool>(resultService);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] ExampleDto dto)
        {
            var result = HelperStatus.RespuestaHelper<bool>(new bool());
            var resultService = await this._exampleService.UpdateAsync(id, this._mapper.Map<TblExampleFedex>(dto));

            if (resultService == false)
            {
                result = HelperStatus.RespuestaHelper<bool>(false, HttpStatusCode.NotFound, "vacio");
                return NotFound(result);
            }

            result = HelperStatus.RespuestaHelper<bool>(resultService);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var result = HelperStatus.RespuestaHelper<bool>(new bool());
            var resultService = await this._exampleService.DeleteAsync(id);

            if (resultService == false)
            {
                result = HelperStatus.RespuestaHelper<bool>(false, HttpStatusCode.NotFound, "vacio");
                return NotFound(result);
            }

            result = HelperStatus.RespuestaHelper<bool>(resultService);
            return Ok(result);
        }
    }
}
