using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Adopter
{
    public int AdopterId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Adoption> Adoptions { get; } = new List<Adoption>();
}
