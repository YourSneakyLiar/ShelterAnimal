using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Animal
{
    public int AnimalId { get; set; }

    public string? Name { get; set; }

    public int? SpeciesId { get; set; }

    public int? BreedId { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public string? Description { get; set; }

    public DateTime? AdmissionDate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Adoption> Adoptions { get; } = new List<Adoption>();

    public virtual Breed? Breed { get; set; }

    public virtual ICollection<MedicalRecord> MedicalRecords { get; } = new List<MedicalRecord>();

    public virtual Species? Species { get; set; }

    public virtual ICollection<Vaccination> Vaccinations { get; } = new List<Vaccination>();
}
