using System.Reflection;
using EShop.DataAccess.Entities;
using EShop.DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EShop.DataAccess.Contexts.EF
{
    public class EShopContext : DbContext
    {
        public DbSet<Gender> Genders { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public EShopContext()
        {
            
        }

        public EShopContext(DbContextOptions options) :base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EShop;User=sa;Password=Yaren#1998;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.SetDataType();
            base.OnModelCreating(modelBuilder);
        }
    }
}