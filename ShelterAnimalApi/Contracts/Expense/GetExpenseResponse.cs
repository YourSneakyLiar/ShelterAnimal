namespace ShelterAnimalApi.Contracts.Expense
{
    public class GetExpenseResponse
    {
        public int ExpenseId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}
