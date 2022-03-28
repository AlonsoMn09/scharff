using Microsoft.EntityFrameworkCore;
using Sharff.Domain.Model.DbModel;
using SKJ.Shared.Data.Repositories;
using SKJ.Shared.Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Sharff.Domain.Model.DbContexts
{
    public class RepositoryManager : IRepositoryManager
    {
        #region Fields

        private readonly SharffDbContext Context;

        #endregion

        #region Repositories

        public IRepository<TblGuiaInboundFedex> GuiaInboundFedexRepository { get; private set; }
        public IRepository<TblLog> LogRepository { get; private set; }
        #endregion

        public RepositoryManager(DbContext context)
        {
            this.Context = context as SharffDbContext;

            this.GuiaInboundFedexRepository = new Respository<TblGuiaInboundFedex>(this.Context);

            this.LogRepository = new Respository<TblLog>(this.Context);
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }

        public async Task<int> SaveChanges()
        {
            return await this.Context.SaveChangesAsync();
        }
    }
}
