namespace ShelterAnimalApi.Contracts.SupplyOrder
{
    public class UpdateSupplyOrderRequest
    {
        public int SupplyId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
    }
}
