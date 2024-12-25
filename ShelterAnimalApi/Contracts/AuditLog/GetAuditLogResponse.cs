namespace ShelterAnimalApi.Contracts.AuditLog
{
    public class GetAuditLogResponse
    {
        public int LogId { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
