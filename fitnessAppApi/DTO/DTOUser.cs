namespace fitnessAppApi.DTO
{
    public class DTOUser
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Email { get; set; }

        public string? BirthDate { get; set; }

        public int Gender { get; set; }

        public string? InvitationCode { get; set; }
    }
}
