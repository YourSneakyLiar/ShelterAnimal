namespace ShelterAnimalApi.Contracts.User
{
    public class GetUserResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
