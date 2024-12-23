using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Donation
{
    public int DonationId { get; set; }

    public string? DonorName { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? DonationDate { get; set; }
}
