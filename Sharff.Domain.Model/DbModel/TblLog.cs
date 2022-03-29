using System;
using System.Collections.Generic;

#nullable disable

namespace Sharff.Domain.Model.DbModel
{
    public partial class TblLog
    {
        public int LogId { get; set; }
        public string LogMessage { get; set; }
        public string LogFecha { get; set; }
    }
}
