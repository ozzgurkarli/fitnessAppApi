using System.ComponentModel.DataAnnotations;

namespace fitnessAppApi.Models
{
    public class ProgramMove
    {
        [Key]
        public int Id { get; set; }

        public int ProgramId { get; set; }

        public int MoveId { get; set; }

        public int Index { get; set; }

        public string MoveName { get; set; } = null!;

        public string Muscle { get; set; } = null!;
    }
}
