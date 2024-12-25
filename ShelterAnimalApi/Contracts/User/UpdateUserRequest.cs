namespace ShelterAnimalApi.Contracts.User
{
    public class UpdateUserRequest
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
