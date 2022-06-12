using BankApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly DbContextOptions _options;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            _options = options;
        }
       
        public DbSet<Accounts> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }
    }
   
}
