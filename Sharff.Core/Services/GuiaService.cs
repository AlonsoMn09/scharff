using Sharff.Core.Services.Interfaces;
using Sharff.Domain.Model.DbContexts;
using Sharff.Domain.Model.DbModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sharff.Core.Services
{
    public class GuiaService : IGuiaService
    {
        public async Task<IEnumerable<TblGuiaInboundFedex>> GetAllAsync()
        {
            using (var context = new RepositoryManager(new SharffDbContext()))
            {
                var result = await context.GuiaInboundFedexRepository.GetAll();
                return result;
            }
        }

        public async Task<TblGuiaInboundFedex> GetByIdAsync(string id)
        {
            using (var context = new RepositoryManager(new SharffDbContext()))
            {
                return await context.GuiaInboundFedexRepository.FirstOrDefault(x => x.AbHdr.Equals(id));
            }
        }

        public async Task<bool> UpdateAsync(string id, TblGuiaInboundFedex model)
        {
            using (var context = new RepositoryManager(new SharffDbContext()))
            {
                var entity = await this.GetByIdAsync(id);
                if(entity != null)
                {
                    var result = await context.GuiaInboundFedexRepository.Update(model);
                    return result > 0;
                }
                return false;
            }
        }

        public async Task<bool> CrateAsync(TblGuiaInboundFedex model)
        {
            using (var context = new RepositoryManager(new SharffDbContext()))
            {
                var result = await context.GuiaInboundFedexRepository.Add(model);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            using (var context = new RepositoryManager(new SharffDbContext()))
            {
                var entity = await this.GetByIdAsync(id);
                if (entity != null)
                {
                    var result = await context.GuiaInboundFedexRepository.DeleteAndReturn(entity);
                    return result > 0;
                }
                return false;
            }
        }
    }
}
