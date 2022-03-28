using Sharff.Core.Services.Interfaces;
using Sharff.Domain.Model.DbContexts;
using Sharff.Domain.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharff.Core.Services
{
    public class ResultService : IResultService
    {
      
        public async Task<bool> CreateAsync(TblLog model)
        {
            using (var context = new RepositoryManager(new SharffDbContext()))
            {
                var result = await context.LogRepository.Add(model);
                return result > 0;
            }
        }
    }
}
