namespace ShelterAnimalApi.Contracts.Adopter
{
    public class GetAdopterResponse
    {
        public int AdopterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

    }
}
