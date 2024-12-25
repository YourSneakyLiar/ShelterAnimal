namespace ShelterAnimalApi.Contracts.AuditLog
{
    public class UpdateAuditLogRequest
    {
        public int UserId { get; set; }
        public string Action { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
