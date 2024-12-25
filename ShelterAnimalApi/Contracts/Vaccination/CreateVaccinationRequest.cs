namespace ShelterAnimalApi.Contracts.Vaccination
{
    public class CreateVaccinationRequest
    {
        public int AnimalId { get; set; }
        public string VaccineName { get; set; }
        public DateTime VaccinationDate { get; set; }
    }
}
