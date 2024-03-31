using System.ComponentModel.DataAnnotations;

namespace fitnessAppApi.Models
{
    public class InvitationCode
    {
        [Key]
        public int UsedById { get; set; }

        public string? Code { get; set; }
    }
}
