namespace ShelterAnimalApi.Contracts.User
{
    public class CreateUserRequest
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }

    }
}
