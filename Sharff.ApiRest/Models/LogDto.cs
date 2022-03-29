using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharff.ApiRest.Models
{
    public class LogDto
    {
        public int LogId { get; set; }
        public string LogMessage { get; set; }
        public string LogFecha { get; set; }
    }
}
