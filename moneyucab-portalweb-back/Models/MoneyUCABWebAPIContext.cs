using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace moneyucab_portalweb_back.Models
{
    public class MoneyUCABWebAPIContext: DbContext
    {
        public MoneyUCABWebAPIContext(DbContextOptions<MoneyUCABWebAPIContext> options):base(options)
        { }

        public DbSet<User> Users { get; set; }

    }
}
