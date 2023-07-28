using Invoicing.DTO;
using Invoicing.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoicing.DB
{
    public class ConnectMssql : DbContext
    {
        public ConnectMssql(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Seller> sellers { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Invoce> invoces{ get; set; }
        public DbSet<InvoceDB> invoceDBs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().Property(x => x.NIP).IsRequired();
            modelBuilder.Entity<Customer>().HasIndex(x => x.NIP).IsUnique();
            modelBuilder.Entity<Seller>().HasIndex(x => x.NIP).IsUnique();
        }
    }
}
