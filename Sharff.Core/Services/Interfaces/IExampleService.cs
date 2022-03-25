using Sharff.Domain.Model.Model;
using System.Threading.Tasks;

namespace Sharff.Core.Services.Interfaces
{
    public interface IExampleService
    {
        Task<Example> GetExampleAsync();
        Task<Example> GetExampleByIdAsync(Example example);
    }
}
