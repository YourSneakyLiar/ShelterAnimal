using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Expense
{
    public int ExpenseId { get; set; }

    public string? Description { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? ExpenseDate { get; set; }
}
