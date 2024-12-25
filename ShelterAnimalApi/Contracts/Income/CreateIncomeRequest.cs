namespace ShelterAnimalApi.Contracts.Income
{
    public class CreateIncomeRequest
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime IncomeDate { get; set; }
    }
}
