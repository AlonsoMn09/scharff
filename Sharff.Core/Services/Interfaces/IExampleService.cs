using Sharff.Domain.Model.DbModel;
using Sharff.Domain.Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sharff.Core.Services.Interfaces
{
    public interface IExampleService
    {
        Task<IEnumerable<TblExampleFedex>> GetExampleAsync();
        Task<TblExampleFedex> GetExampleByIdAsync(string id);
        Task<bool> CreateAsync(TblExampleFedex model);
        Task<bool> UpdateAsync(string id, TblExampleFedex model);
        Task<bool> DeleteAsync(string id);
    }
}
