namespace ShelterAnimalApi.Contracts.Supply
{
    public class GetSupplyResponse
    {

        public int SupplyId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
    }
}
