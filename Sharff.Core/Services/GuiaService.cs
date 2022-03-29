using Sharff.Core.Services.Interfaces;
using Sharff.Domain.Model.DbContexts.Interfaces;
using Sharff.Domain.Model.DbModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sharff.Core.Services
{
    public class GuiaService : IGuiaService
    {
        private readonly IDataManager DataManager;

        public GuiaService(IDataManager dataManager)
        {
            this.DataManager = dataManager;
        }

        public async Task<IEnumerable<TblGuiaInboundFedex>> GetAllAsync()
        {
            return await this.DataManager.GuiaInboundFedexRepository.GetAll();
        }

        public async Task<TblGuiaInboundFedex> GetByIdAsync(string id)
        {
            return await this.DataManager.GuiaInboundFedexRepository.FirstOrDefault(x => x.AbHdr.Equals(id));
        }

        public async Task<bool> UpdateAsync(string id, TblGuiaInboundFedex model)
        {
            var entity = await this.GetByIdAsync(id);
            if(entity != null)
            {
                var result = await this.DataManager.GuiaInboundFedexRepository.Update(model);
                return result > 0;
            }
            return false;
        }

        public async Task<bool> CrateAsync(TblGuiaInboundFedex model)
        {
            var result = await this.DataManager.GuiaInboundFedexRepository.Add(model);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await this.GetByIdAsync(id);
            if (entity != null)
            {
                var result = await this.DataManager.GuiaInboundFedexRepository.DeleteAndReturn(entity);
                return result > 0;
            }
            return false;
        }
    }
}
