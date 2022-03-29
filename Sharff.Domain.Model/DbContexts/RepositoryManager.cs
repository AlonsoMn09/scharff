using Sharff.Domain.Model.DbContexts.Interfaces;
using Sharff.Domain.Model.DbModel;
using SKJ.Shared.Data.Repositories;
using SKJ.Shared.Data.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Sharff.Domain.Model.DbContexts
{
    public class RepositoryManager : IDataManager
    {
        #region Fields

        private readonly SharffDbContext Context;

        #endregion

        #region Repositories

        private readonly IRepository<TblGuiaInboundFedex> _guiaInboundFedexRepository;

        #endregion

        public RepositoryManager(SharffDbContext context)
        {
            this.Context = context;
        }

        public IRepository<TblGuiaInboundFedex> GuiaInboundFedexRepository => _guiaInboundFedexRepository ?? new Respository<TblGuiaInboundFedex>(this.Context);

        public void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }

        public async Task<int> SaveChanges()
        {
            return await this.Context.SaveChangesAsync();
        }
    }
}
