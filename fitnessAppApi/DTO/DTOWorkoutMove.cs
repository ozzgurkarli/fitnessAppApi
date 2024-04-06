using fitnessAppApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace fitnessAppApi.DTO
{
    public class DTOWorkoutMove
    {
        public int Id { get; set; }

        public int MoveId { get; set; }

        public string MoveName { get; set; } = null!;

        public int Index { get; set; }

        public int SetCount { get; set; }

        public int Repeat { get; set; }

        public double Weight { get; set; }

        public int WorkoutId { get; set; }
    }
}
