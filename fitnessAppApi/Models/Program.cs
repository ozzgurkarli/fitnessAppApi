using fitnessAppApi.DTO;
using System.ComponentModel.DataAnnotations;

namespace fitnessAppApi.Models
{
    public class Program
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string ProgramName { get; set; } = null!;

        public virtual List<ProgramMove> ProgramMoves { get; set; }

        public DateTime RecordDate { get; set; }
    }
}
