namespace ShelterAnimalApi.Contracts.EventAttendance
{
    public class CreateEventAttendanceRequest
    {
        public int EventId { get; set; }
        public int VolunteerId { get; set; }
    }
}
