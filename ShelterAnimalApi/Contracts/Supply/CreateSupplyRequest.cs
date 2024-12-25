namespace ShelterAnimalApi.Contracts.Supply
{
    public class CreateSupplyRequest
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
    }
}
