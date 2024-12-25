namespace ShelterAnimalApi.Contracts.SupplyOrder
{
    public class GetSupplyOrderResponse
    {
        public int OrderId { get; set; }
        public int SupplyId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
    }
}
