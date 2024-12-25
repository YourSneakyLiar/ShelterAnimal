namespace ShelterAnimalApi.Contracts.Event
{
    public class GetEventResponse
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
    }
}
