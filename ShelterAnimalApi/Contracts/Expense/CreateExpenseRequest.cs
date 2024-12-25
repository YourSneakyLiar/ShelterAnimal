namespace ShelterAnimalApi.Contracts.Expense
{
    public class CreateExpenseRequest
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}
