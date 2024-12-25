namespace ShelterAnimalApi.Contracts.MedicalRecord
{
    public class UpdateMedicalRecordRequest
    {
        public int AnimalId { get; set; }
        public DateTime RecordDate { get; set; }
        public string Description { get; set; }
    }
}
