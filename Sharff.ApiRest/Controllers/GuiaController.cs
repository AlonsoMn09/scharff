using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sharff.ApiRest.Models;
using Sharff.Core.Services.Interfaces;
using Sharff.Domain.Model.DbModel;
using Sharff.Domain.Model.Model;
using Shartff.Shared.ApiRest.Base;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Sharff.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuiaController : BaseController
    {
        #region Fields

        private readonly ILogger<GuiaController> _logger;

        public readonly IGuiaService _guiaService;

        #endregion

        public GuiaController(ILogger<GuiaController> logger, IMapper mapper, IGuiaService guiaService) : base(mapper)
        {
            this._logger = logger;
            this._guiaService = guiaService;
        }

        [HttpGet("{traceId}")]
        public async Task<ActionResult> GetAll(string traceId)
        {
            var result = HelperStatus.RespuestaHelper<IEnumerable<GuiaInboundFedexDto>>(new List<GuiaInboundFedexDto>());
            var resultService = await this._guiaService.GetAllAsync();

            if (resultService == null)
            {
                result = HelperStatus.RespuestaHelper<IEnumerable<GuiaInboundFedexDto>>(new List<GuiaInboundFedexDto>(), traceId, HttpStatusCode.NotFound, "vacio");
                return NotFound(result);
            }

            result = HelperStatus.RespuestaHelper<IEnumerable<GuiaInboundFedexDto>>(this._mapper.Map<IEnumerable<GuiaInboundFedexDto>>(resultService), traceId);
            return Ok(result);
        }

        [HttpGet("{traceId}/{id}")]
        public async Task<ActionResult> GetById(string traceId, string id)
        {
            var result = HelperStatus.RespuestaHelper<GuiaInboundFedexDto>(new GuiaInboundFedexDto());
            var resultService = await this._guiaService.GetByIdAsync(id);

            if (resultService == null)
            {
                result = HelperStatus.RespuestaHelper<GuiaInboundFedexDto>(new GuiaInboundFedexDto(), traceId, HttpStatusCode.NotFound, "vacio");
                return BadRequest(result);
            }

            result = HelperStatus.RespuestaHelper<GuiaInboundFedexDto>(this._mapper.Map<GuiaInboundFedexDto>(resultService), traceId);
            return Ok(result);
        }

        [HttpPost("{traceId}/{id}")]
        public async Task<ActionResult> Create(string traceId, [FromBody] GuiaInboundFedexDto dto)
        {
            var result = HelperStatus.RespuestaHelper<bool>(new bool());
            var resultService = await this._guiaService.CrateAsync(this._mapper.Map<TblGuiaInboundFedex>(dto));

            if (resultService == false)
            {
                result = HelperStatus.RespuestaHelper<bool>(false, traceId, HttpStatusCode.NotFound, "vacio");
                return NotFound(result);
            }

            result = HelperStatus.RespuestaHelper<bool>(resultService, traceId);
            return Ok(result);
        }

        [HttpPut("{traceId}/{id}")]
        public async Task<ActionResult> Update(string traceId, string id, [FromBody] GuiaInboundFedexDto dto)
        {
            var result = HelperStatus.RespuestaHelper<bool>(new bool());
            var resultService = await this._guiaService.UpdateAsync(id, this._mapper.Map<TblGuiaInboundFedex>(dto));

            if (resultService == false)
            {
                result = HelperStatus.RespuestaHelper<bool>(false, traceId, HttpStatusCode.NotFound, "vacio");
                return NotFound(result);
            }

            result = HelperStatus.RespuestaHelper<bool>(resultService, traceId);
            return Ok(result);
        }

        [HttpDelete("{traceId}/{id}")]
        public async Task<ActionResult> Delete(string traceId, string id)
        {
            var result = HelperStatus.RespuestaHelper<bool>(new bool());
            var resultService = await this._guiaService.DeleteAsync(id);

            if (resultService == false)
            {
                result = HelperStatus.RespuestaHelper<bool>(false, traceId, HttpStatusCode.NotFound, "vacio");
                return NotFound(result);
            }

            result = HelperStatus.RespuestaHelper<bool>(resultService, traceId);
            return Ok(result);
        }
    }
}
