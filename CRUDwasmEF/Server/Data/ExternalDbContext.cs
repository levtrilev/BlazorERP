using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDwasmEF.Shared.Models;

namespace CRUDwasmEF.Server.Data
{
    public class ExternalDbContext : DbContext
    {
        public ExternalDbContext(DbContextOptions<ExternalDbContext> options) : base(options)
        {
        }
        public DbSet<SellOrder> SellOrders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SellOrder>()
                .ToTable("SellOrder", t => t.ExcludeFromMigrations());
        }
    }
}
