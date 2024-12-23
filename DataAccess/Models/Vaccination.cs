using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Vaccination
{
    public int VaccinationId { get; set; }

    public int? AnimalId { get; set; }

    public string? VaccineName { get; set; }

    public DateTime? VaccinationDate { get; set; }

    public virtual Animal? Animal { get; set; }
}
