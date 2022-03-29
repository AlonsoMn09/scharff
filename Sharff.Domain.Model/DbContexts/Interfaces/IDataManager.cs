using Sharff.Domain.Model.DbModel;
using SKJ.Shared.Data.Repositories.Interfaces;

namespace Sharff.Domain.Model.DbContexts.Interfaces
{
    public interface IDataManager : IRepositoryManager
    {
        IRepository<TblGuiaInboundFedex> GuiaInboundFedexRepository { get; }
    }
}
