﻿using Aguas.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aguas.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Contract> Contracts { get; set; }

        public DbSet<ContractType> ContractTypes { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Locality> Locality { get; set; }

        public DbSet<Meter> Meters { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
