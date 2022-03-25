using Sharff.Domain.Model.DbModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sharff.Core.Services.Interfaces
{
    public interface IGuiaService
    {
        Task<IEnumerable<TblGuiaInboundFedex>> GetAllAsync();

        Task<TblGuiaInboundFedex> GetByIdAsync(string id);

        Task<bool> UpdateAsync(string id, TblGuiaInboundFedex model);

        Task<bool> CrateAsync(TblGuiaInboundFedex model);

        Task<bool> DeleteAsync(string id);
    }
}
