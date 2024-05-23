using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fitnessAppApi.Models
{
    public class WorkoutMove
    {
        [Key]
        public int Id { get; set; }

        public int MoveId { get; set; }

        public string MoveName { get; set; } = null!;

        public string Muscle { get; set; } = null!;

        public int Index { get; set; }

        public int SetCount { get; set; }

        public int Repeat { get; set; }

        public double Weight { get; set; }


        [ForeignKey("Workout")]
        public int WorkoutId { get; set; }

        public virtual Workout Workout { get; set; }
    }
}
