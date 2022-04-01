using Sharff.Core.Services.Interfaces;
using Sharff.Domain.Model.DbContexts;
using Sharff.Domain.Model.DbContexts.Interfaces;
using Sharff.Domain.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharff.Core.Services
{
    public class LogService : ILogService
    {
        private readonly IDataManager DataManager;

        public LogService(IDataManager dataManager)
        {
            this.DataManager = dataManager;
        }

        public async Task<IEnumerable<Log>> GetFechAsync(DateTime? fecha)
        {
            return await this.DataManager.LogRepository.Select(x => x.RaiseDate.Equals(fecha));
        }

        public async Task<IEnumerable<Log>> GetRangeFechAsync(DateTime? fecha_inicial, DateTime? fecha_final)
        {
            return await this.DataManager.LogRepository.SelectIncludes(x => x.RaiseDate >= fecha_inicial && x.RaiseDate <= fecha_final);
        }
        

    }
}
