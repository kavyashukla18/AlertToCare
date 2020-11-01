using AlertToCare.Models;
using Microsoft.EntityFrameworkCore;

namespace AlertToCare.Repository
{
    public class DbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {

        }
        public DbSet<PatientDataModel> PatientInfo { get; set; }
        public DbSet<BedInformation> BedInformation { get; set; }
        public DbSet<MedicalDevice> MedicalDevice { get; set; }
        public DbSet<BedOnAlert> BedOnAlert { get; set; }
        public DbSet<IcuWardInformation> IcuWardInformation { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
