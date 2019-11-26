using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleApp.DataAccess.Entity;

namespace SimpleApp.DataAccess
{
    public class SimpleDbContext : IdentityDbContext<ApplicationUser>
    {
        public SimpleDbContext(DbContextOptions<SimpleDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
