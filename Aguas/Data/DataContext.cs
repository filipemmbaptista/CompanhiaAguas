using Aguas.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aguas.Data
{
    public class DataContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<ContractType> ContractTypes { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Locality> Locality { get; set; }

        public DbSet<Meter> Meters { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Aguas;Integrated Security=True");
            }
        }
    }
}
