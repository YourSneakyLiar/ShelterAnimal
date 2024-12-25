namespace ShelterAnimalApi.Contracts.Vaccination
{
    public class GetVaccinationResponse
    {
        public int VaccinationId { get; set; }
        public int AnimalId { get; set; }
        public string VaccineName { get; set; }
        public DateTime VaccinationDate { get; set; }
    }
}
