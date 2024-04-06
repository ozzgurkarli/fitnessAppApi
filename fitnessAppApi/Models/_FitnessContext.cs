using Microsoft.EntityFrameworkCore;
using System.Data;

namespace fitnessAppApi.Models
{
    public class FitnessContext(DbContextOptions<FitnessContext> options) : DbContext(options)
    {
        public DbSet<User> User { get; set; }

        public DbSet<Models.Program> Program { get; set; }

        public DbSet<ProgramMove> ProgramMove { get; set; }

        public DbSet<Workout> Workout { get; set; }

        public DbSet<WorkoutMove> WorkoutMove { get; set; }

        public DbSet<InvitationCode> InvitationCode { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InvitationCode>().HasKey("UsedById");
        }
    }
}
