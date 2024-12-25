using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class SupplyOrder
{
    public int OrderId { get; set; }

    public int? SupplyId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? Quantity { get; set; }

    public virtual Supply? Supply { get; set; }
}
