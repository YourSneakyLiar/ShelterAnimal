namespace ShelterAnimalApi.Contracts.MedicalRecord
{
    public class GetMedicalRecordResponse
    {
        public int RecordId { get; set; }
        public int AnimalId { get; set; }
        public DateTime RecordDate { get; set; }
        public string Description { get; set; }
    }
}
