using fitnessAppApi.Models;
using System.ComponentModel.DataAnnotations;

namespace fitnessAppApi.DTO
{
    public class DTOProgram
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string ProgramName { get; set; } = null!;

        public ICollection<ProgramMove> ProgramMoves { get; set; } = null!;

    }
}
