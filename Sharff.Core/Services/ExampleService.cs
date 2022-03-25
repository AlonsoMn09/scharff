using Sharff.Core.Services.Interfaces;
using Sharff.Domain.Model.Model;
using System.Threading.Tasks;

namespace Sharff.Core.Services
{
    public class ExampleService : IExampleService
    {
        public async Task<Example> GetExampleAsync()
        {
            return new Example { Id = 1, Description = "Test"};
        }

        public async Task<Example> GetExampleByIdAsync(Example example)
        {
            return new Example { Id = 2, Description = "Test2" };
        }
    }
}
