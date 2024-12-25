namespace ShelterAnimalApi.Contracts.Expense
{
    public class UpdateExpenseRequest
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}
