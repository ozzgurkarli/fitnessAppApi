using fitnessAppApi.Models;
using System.ComponentModel.DataAnnotations;

namespace fitnessAppApi.DTO
{
    public class DTOProgram
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string ProgramName { get; set; } = null!;

        public virtual List<DTOProgramMove> ProgramMoves { get; set; } = null!;

    }
}
