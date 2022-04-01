using Shartff.Shared.ApiRest.Models;
using System.Net;

namespace Sharff.Domain.Model.Model
{
    public class ResultDto<T>
    {
        public ResultDto(T payload)
        {
            this.Payload = payload;
        }
        public TraceDto Trace { get; set; }
        public StatusDto Status { get; set; }
        public T Payload { get; set; }
    }
}