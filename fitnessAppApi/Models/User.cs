using System.ComponentModel.DataAnnotations;

namespace fitnessAppApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Email { get; set; }

        public DateTime BirthDate { get; set; }

        public int Gender { get; set; }

        public string? InvitationCode { get; set; }

        public DateTime RecordDate { get; set; }
    }
}
