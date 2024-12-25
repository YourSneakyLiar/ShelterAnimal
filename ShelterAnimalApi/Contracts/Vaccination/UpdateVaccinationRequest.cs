namespace ShelterAnimalApi.Contracts.Vaccination
{
    public class UpdateVaccinationRequest
    {
        public int AnimalId { get; set; }
        public string VaccineName { get; set; }
        public DateTime VaccinationDate { get; set; }
    }
}
