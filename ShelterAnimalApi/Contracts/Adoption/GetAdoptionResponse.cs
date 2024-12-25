namespace ShelterAnimalApi.Contracts.Adoption
{
    public class GetAdoptionResponse
    {
        public int AdoptionId { get; set; }
        public int AnimalId { get; set; }
        public int AdopterId { get; set; }
        public DateTime AdoptionDate { get; set; }
    }
}
