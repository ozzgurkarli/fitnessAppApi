using Microsoft.EntityFrameworkCore;

namespace fitnessAppApi.Models
{
    public class FitnessContext(DbContextOptions<FitnessContext> options) : DbContext(options)
    {
        public DbSet<User> User { get; set; }

        public DbSet<InvitationCode> InvitationCode { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InvitationCode>().HasKey("UsedById");
        }
    }
}
