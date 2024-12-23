using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class MedicalRecord
{
    public int RecordId { get; set; }

    public int? AnimalId { get; set; }

    public DateTime? RecordDate { get; set; }

    public string? Description { get; set; }

    public virtual Animal? Animal { get; set; }
}
