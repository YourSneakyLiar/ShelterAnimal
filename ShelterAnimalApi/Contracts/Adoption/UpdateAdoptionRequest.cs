namespace ShelterAnimalApi.Contracts.Adoption
{
    public class UpdateAdoptionRequest
    {
        public int AnimalId { get; set; }
        public int AdopterId { get; set; }
        public DateTime AdoptionDate { get; set; }
    }
}
