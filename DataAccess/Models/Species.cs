using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Species
{
    public int SpeciesId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Animal> Animals { get; } = new List<Animal>();

    public virtual ICollection<Breed> Breeds { get; } = new List<Breed>();
}
