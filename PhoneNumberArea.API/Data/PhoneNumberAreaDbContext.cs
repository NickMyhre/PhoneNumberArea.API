using Microsoft.EntityFrameworkCore;
using PhoneNumberArea.API.Data.Configurations;

namespace PhoneNumberArea.API.Data
{
    public class PhoneNumberAreaDbContext : DbContext
    {
        public PhoneNumberAreaDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<State> States { get; set; }
        public DbSet<AreaCode> AreaCodes { get; set; }
        public DbSet<County> Counties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StateConfiguration());
            modelBuilder.ApplyConfiguration(new AreaCodeConfiguration());
            modelBuilder.ApplyConfiguration(new CountyConfiguration());
            /* Alternate way to include configs in method
            new StateConfiguration().Configure(modelBuilder.Entity<State>());
            new AreaCodeConfiguration().Configure(modelBuilder.Entity<AreaCode>());
            new CountyConfiguration().Configure(modelBuilder.Entity<County>());*/
        }
    }
}
