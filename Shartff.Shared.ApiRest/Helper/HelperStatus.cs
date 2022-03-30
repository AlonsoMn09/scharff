using System.Net;

namespace Sharff.Domain.Model.Model
{
    public static class HelperStatus
    {
        public static ResultDto<T> RespuestaHelper<T>(T payload, HttpStatusCode codEstado = HttpStatusCode.OK, string message ="")
        {
            return new ResultDto<T>(payload)
            {
                StatusCode = codEstado,
                Message = message
            };            
        }
    }
}
