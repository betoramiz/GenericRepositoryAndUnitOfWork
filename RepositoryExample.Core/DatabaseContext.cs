using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RepositoryExample.Core
{
    public class DatabaseContext : IdentityDbContext<UserProfile> 
    {
        public DatabaseContext() : base("name=ConnectionDev") { }

        public DbSet<Estate> Estate { get; set; }
        public DbSet<Town> Town { get; set; }

    }
}
