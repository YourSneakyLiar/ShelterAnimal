namespace ShelterAnimalApi.Contracts.AuditLog
{
    public class CreateAuditLogRequest
    {

        public int UserId { get; set; }
        public string Action { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
