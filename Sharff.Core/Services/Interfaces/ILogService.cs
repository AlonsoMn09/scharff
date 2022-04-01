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
        Task<IEnumerable<Log>> GetFechAsync(DateTime? fecha);
        Task<IEnumerable<Log>> GetRangeFechAsync(DateTime? fecha_inicial, DateTime? fecha_final);


    }
}
