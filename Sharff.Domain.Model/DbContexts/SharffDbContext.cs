using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharff.Domain.Model.DbContexts
{
    public class SharffDbContext : DbContext
    {
        protected readonly string ConnectionString;

        public SharffDbContext()
        {

        }

        public SharffDbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
    }
}
