using System.Net;

namespace Sharff.Domain.Model.Model
{
    public class ResultDto<T>
    {
        public ResultDto(T payload)
        {
            this.Payload = payload;
        }

        public T Payload { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }
    }
}