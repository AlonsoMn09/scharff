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

        public async Task<Log> GetFechAsync(DateTime? fecha)
        {
            return await this.DataManager.LogRepository.FirstOrDefault(x => x.RaiseDate.Equals(fecha));
        }

        public async Task<Log> GetRangeFechAsync(string fecha_inicial, string fecha_final)
        {
            return await this.DataManager.LogRepository.FirstOrDefault(x => x.RaiseDate.Equals(fecha_inicial));
        }

        public async Task<Log> GetLevelAsync(string level)
        {
            return await this.DataManager.LogRepository.FirstOrDefault(x => x.Level == level);
        }
    }
}
