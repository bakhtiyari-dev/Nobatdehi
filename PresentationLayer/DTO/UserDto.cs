namespace PresentationLayer.DTO
{
    public class UserDto
    {
        public required string Role { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required int OfficeId { get; set; }
    }
}
