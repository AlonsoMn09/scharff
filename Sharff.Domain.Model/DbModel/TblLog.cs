using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharff.Domain.Model.DbModel
{
    public partial class TblLog
    {
        public object Payload { get; set; }

        public int StatusCode { get; set; }

        public string Message { get; set; }

    }
}
