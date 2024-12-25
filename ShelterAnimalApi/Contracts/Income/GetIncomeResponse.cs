namespace ShelterAnimalApi.Contracts.Income
{
    public class GetIncomeResponse
    {
        public int IncomeId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime IncomeDate { get; set; }
    }
}
