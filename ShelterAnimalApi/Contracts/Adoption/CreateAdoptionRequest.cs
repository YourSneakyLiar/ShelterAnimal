namespace ShelterAnimalApi.Contracts.Adoption
{
    public class CreateAdoptionRequest
    {
        public int AnimalId { get; set; }
        public int AdopterId { get; set; }
        public DateTime AdoptionDate { get; set; }

    }
}
