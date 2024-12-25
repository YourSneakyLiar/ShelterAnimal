using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Position { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }
}
