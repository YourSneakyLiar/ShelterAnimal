using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Breed
{
    public int BreedId { get; set; }

    public int? SpeciesId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Animal> Animals { get; } = new List<Animal>();

    public virtual Species? Species { get; set; }
}
