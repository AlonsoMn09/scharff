using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharff.Domain.Model.DbModel;


namespace Sharff.Core.Services.Interfaces
{
    public interface ILogService
    {
        Task<Log> GetFechAsync(DateTime? fecha);
        Task<Log> GetRangeFechAsync(string fecha_inicial, string fecha_final);
        Task<Log> GetLevelAsync(string level);

    }
}
