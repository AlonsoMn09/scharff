using Shartff.Shared.ApiRest.Models;
using System.Net;

namespace Sharff.Domain.Model.Model
{
    public static class HelperStatus
    {
        public static ResultDto<T> RespuestaHelper<T>(T payload, string traceId= "", HttpStatusCode codEstado = HttpStatusCode.OK, string message ="")
        {
            return new ResultDto<T>(payload)
            {
                Trace = new TraceDto(traceId),
                Status = new StatusDto(codEstado, message)
            };            
        }
    }
}
