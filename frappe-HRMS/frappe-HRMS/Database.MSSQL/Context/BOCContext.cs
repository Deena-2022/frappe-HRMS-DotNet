using BOC.Domain.DataEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.MSSQL.Context
{
    public class BOCContext : DbContext
    {
        public BOCContext()
        {
            
        }
        public BOCContext(DbContextOptions<BOCContext>options) : base(options)
        {
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=DESKTOP-9DKG81B;Initial Catalog=BOC_Sample_DB;Integrated Security=True;Trust Server Certificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
    }
}
