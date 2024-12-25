using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Adoption
{
    public int AdoptionId { get; set; }

    public int? AnimalId { get; set; }

    public int? AdopterId { get; set; }

    public DateTime? AdoptionDate { get; set; }

    public virtual Adopter? Adopter { get; set; }

    public virtual Animal? Animal { get; set; }
}
