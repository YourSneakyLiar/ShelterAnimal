namespace ShelterAnimalApi.Contracts.Staff
{
    public class CreateStaffRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
