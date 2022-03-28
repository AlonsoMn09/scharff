using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sharff.ApiRest.Models;
using Sharff.Core.Services.Interfaces;
using Sharff.Domain.Model.DbModel;
using Shartff.Shared.ApiRest.Base;
using System.Collections.Generic;
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

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<GuiaInboundFedexDto>>> GetAll()
        {
            var result = new ResultDto
            {
                StatusCode = 200
            };

            try
            {
                var resultService = await this._guiaService.GetAllAsync();
                result.Payload = this._mapper.Map<IEnumerable<GuiaInboundFedexDto>>(resultService);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                this._logger.LogError(ex.Message, ex.InnerException);
                result.StatusCode = 500;
                result.Message = ex.Message;
            }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuiaInboundFedexDto>> GetById(string id)
        {
            var result = new ResultDto
            {
                StatusCode = 200
            };

            try
            {
                var resultService = await this._guiaService.GetByIdAsync(id);
                result.Payload = this._mapper.Map<IEnumerable<GuiaInboundFedexDto>>(resultService);
                this._logger.LogWarning($"La guia de ID {id} no ha sido encontrada");
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                this._logger.LogError(ex.Message, ex.InnerException);
                result.StatusCode = 500;
                result.Message = ex.Message;
            }
            return BadRequest(result);
        }

        [HttpPost()]
        public async Task<ActionResult<ResultDto>> Create([FromBody] GuiaInboundFedexDto dto)
        {
            var result = new ResultDto
            {
                StatusCode = 200
            };

            try
            {
                var resultService = await this._guiaService.CrateAsync(this._mapper.Map<TblGuiaInboundFedex>(dto));
                result.Payload = resultService;
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                this._logger.LogError(ex.Message, ex.InnerException);
                result.StatusCode = 500;
                result.Message = ex.Message;
            }
            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResultDto>> Update(string id, [FromBody] GuiaInboundFedexDto dto)
        {
            var result = new ResultDto
            {
                StatusCode = 200
            };

            try
            {
                var resultService = await this._guiaService.UpdateAsync(id, this._mapper.Map<TblGuiaInboundFedex>(dto));
                result.Payload = resultService;
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                this._logger.LogError(ex.Message, ex.InnerException);
                result.StatusCode = 500;
                result.Message = ex.Message;
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultDto>> Delete(string id)
        {
            var result = new ResultDto
            {
                StatusCode = 200
            };

            try
            {
                var resultService = await this._guiaService.DeleteAsync(id);
                result.Payload = resultService;
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                this._logger.LogError(ex.Message, ex.InnerException);
                result.StatusCode = 500;
                result.Message = ex.Message;
            }
            return BadRequest(result);
        }
    }
}
