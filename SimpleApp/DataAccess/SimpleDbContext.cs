using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using SimpleApp.DataAccess.Entity;
using Microsoft.AspNetCore.Identity;

namespace SimpleApp.DataAccess
{
    public class SimpleDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public SimpleDbContext(DbContextOptions<SimpleDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
