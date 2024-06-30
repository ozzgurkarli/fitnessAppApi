using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fitnessAppApi.Models
{
    public class Workout
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey("Program")]
        public int ProgramId { get; set; }

        public string ProgramName { get; set; } = null!;

        public int Duration { get; set; }

        public bool Completed { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime RecordDate { get; set; }

        public virtual List<WorkoutMove> WorkoutMoves { get; set; }
    }
}
