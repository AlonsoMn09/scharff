using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharff.Domain.Model.DbModel;


namespace Sharff.Core.Services.Interfaces
{
    public interface IResultService
    {
       Task<bool> CreateAsync(TblLog model);
    }
}
