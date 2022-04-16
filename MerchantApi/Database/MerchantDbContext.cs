using MerchantApi.Dto;
using MerchantApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MerchantApi.Database
{
    public class MerchantDbContext : DbContext
    {
      

        public MerchantDbContext(DbContextOptions<MerchantDbContext> options): base(options)
        {
           
        }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Store> Stores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Store>()
           //     .HasOne(p => p.MerchantCode)
           //     .WithMany(b => b.Stores);
        }
    }
}
