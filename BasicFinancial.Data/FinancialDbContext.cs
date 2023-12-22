using BasicFinancial.Core.Models;
using BasicFinancial.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFinancial.Data
{
    public class FinancialDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> User { get; set; }
        protected readonly IConfiguration Configuration;
         
        public FinancialDbContext(DbContextOptions<FinancialDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("BasicFinancial.Data"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new AccountConfiguration());

            builder
                .ApplyConfiguration(new CustomerConfiguration());
        }
    }
}
