using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shartff.Shared.ApiRest.Models
{
    public class TraceDto
    {
        public TraceDto(string traceId)
        {
            this.traceId=traceId;
        }
        public string traceId { get; set; }
    }
}
