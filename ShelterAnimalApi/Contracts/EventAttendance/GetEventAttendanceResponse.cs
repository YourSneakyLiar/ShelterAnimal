namespace ShelterAnimalApi.Contracts.EventAttendance
{
    public class GetEventAttendanceResponse
    {
        public int AttendanceId { get; set; }
        public int EventId { get; set; }
        public int VolunteerId { get; set; }
    }
}
