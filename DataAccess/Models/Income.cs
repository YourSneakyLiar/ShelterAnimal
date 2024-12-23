using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Income
{
    public int IncomeId { get; set; }

    public string? Description { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? IncomeDate { get; set; }
}
