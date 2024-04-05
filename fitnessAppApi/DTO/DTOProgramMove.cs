using System.ComponentModel.DataAnnotations.Schema;

namespace fitnessAppApi.DTO
{
    public class DTOProgramMove
    {
        public int Id { get; set; }

        public int MoveId { get; set; }

        public int Index { get; set; }

        public string MoveName { get; set; } = null!;

        public string Muscle { get; set; } = null!;

        public int ProgramId { get; set; }

    }
}
