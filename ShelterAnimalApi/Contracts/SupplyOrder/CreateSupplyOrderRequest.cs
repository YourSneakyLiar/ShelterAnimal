namespace ShelterAnimalApi.Contracts.SupplyOrder
{
    public class CreateSupplyOrderRequest
    {
        public int SupplyId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
    }
}
