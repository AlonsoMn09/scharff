using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharff.ApiRest.Models
{
    public class LogDto
    {
        public object log_carga { get; set; }
        public string message { get; set; }

        public DateTime fecha { get; set; }
    }
}
