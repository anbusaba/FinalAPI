using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartMonitoringSystem.Core.Entities;
using SmartMonitoringSystem.Core.Identity;

namespace SmartMonitoringSystem.Infrastructure.DBContext
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        // DbSet properties for your custom entity classes
        public DbSet<Admin> Admin { get; set; }
        public DbSet<BayInfo> BayInfo { get; set; }
        public DbSet<BayLiveData> bayLiveData { get; set; }
        public DbSet<DeviceInfo> DeviceInfo { get; set; }  
        public DbSet<Organisation> Organisation { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Additional configuration if needed
        }

    }
}
