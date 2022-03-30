using Sharff.Core.Services.Interfaces;
using Sharff.Domain.Model.DbModel;
using Sharff.Domain.Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sharff.Core.Services
{
    public class ExampleService : IExampleService
    {
        public async Task<IEnumerable<TblExampleFedex>> GetExampleAsync()
        {
            var lista = new List<TblExampleFedex> { 
                new TblExampleFedex() { Id = 1, Description = "Test" },
                new TblExampleFedex() { Id = 2, Description = "Test2" }};

            return lista;
        }
        public async Task<TblExampleFedex> GetExampleByIdAsync(string id)
        {
            return new TblExampleFedex { Id = 2, Description = "Test2" };            
        }
        public async Task<bool> CreateAsync(TblExampleFedex model)
        {
            return true;
        }
        public async Task<bool> UpdateAsync(string id, TblExampleFedex model)
        {
            return true;

        }
        public async Task<bool> DeleteAsync(string id)
        {
            return true;
        }
    }
}
