using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shartff.Shared.ApiRest.Models
{
    public class StatusDto
    {
        public StatusDto(HttpStatusCode HttpCode, string Message)
        {
            this.HttpCode = HttpCode;
            this.Message = Message;
        }

        public HttpStatusCode HttpCode { get; set; }
        public string Message { get; set; }
    }
}
