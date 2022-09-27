using Microsoft.EntityFrameworkCore;
using RespayMLS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Data
{
    public class RespayMLSDbContext : DbContext
    {
        public RespayMLSDbContext(DbContextOptions<RespayMLSDbContext> options) : base(options)
        {

        }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<ItemType> ItemTypes { get; set; }

        public DbSet<ItemSubType> ItemSubTypes { get; set; }

        public DbSet<ItemFeature> ItemFeatures { get; set; }

        public DbSet<ItemSubFeature> ItemSubFeatures { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<PlanType> PlanTypes { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Sector> Sectors { get; set; }

        public DbSet<Frequency> Frequencies { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ListingType> ListingTypes { get; set; }
    }
}
