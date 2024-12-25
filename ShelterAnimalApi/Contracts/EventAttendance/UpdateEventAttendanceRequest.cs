namespace ShelterAnimalApi.Contracts.EventAttendance
{
    public class UpdateEventAttendanceRequest
    {
        public int EventId { get; set; }
        public int VolunteerId { get; set; }
    }
}
