using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public class AppDBContext :DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> dbContextOptions)

            : base(dbContextOptions)
        {

        }

        public DbSet<TimeBuild> Times { get; set; }
    }
}
