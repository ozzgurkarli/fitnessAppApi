using fitnessAppApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace fitnessAppApi.DTO
{
    public class DTOWorkout
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProgramId { get; set; }

        public string ProgramName { get; set; } = null!;

        public int Duration { get; set; }

        public bool Completed { get; set; }

        public DateTime RecordDate { get; set; }

        public virtual List<DTOWorkoutMove> WorkoutMoves { get; set; }
    }
}
