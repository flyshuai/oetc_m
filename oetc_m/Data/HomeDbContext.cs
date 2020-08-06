using Microsoft.EntityFrameworkCore;
using oetc_m.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace oetc_m.Data
{
    public class HomeDbContext: DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ApplicationRecord> ApplicationRecords { get; set; }

        public HomeDbContext(DbContextOptions<HomeDbContext> options)
            : base(options)
        { }
    }
}
