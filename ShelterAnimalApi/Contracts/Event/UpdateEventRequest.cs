namespace ShelterAnimalApi.Contracts.Event
{
    public class UpdateEventRequest
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
    }
}
