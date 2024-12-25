namespace ShelterAnimalApi.Contracts.Volunteer
{
    public class CreateVolunteerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Availability { get; set; }
    }
}
