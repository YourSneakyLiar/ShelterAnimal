using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Supply
{
    public int SupplyId { get; set; }

    public string? Name { get; set; }

    public int? Quantity { get; set; }

    public string? Unit { get; set; }

    public virtual ICollection<SupplyOrder> SupplyOrders { get; } = new List<SupplyOrder>();
}
