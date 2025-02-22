﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fitnessAppApi.Models
{
    public class ProgramMove
    {
        [Key]
        public int Id { get; set; }

        public int MoveId { get; set; }

        public int Index { get; set; }

        public string MoveName { get; set; } = null!;

        public string Muscle { get; set; } = null!;

        [ForeignKey("Program")]
        public int ProgramId { get; set; }

        public virtual Models.Program Program { get; set; }
    }
}
