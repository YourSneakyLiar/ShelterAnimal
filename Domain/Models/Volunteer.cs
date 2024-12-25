using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Volunteer
{
    public int VolunteerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Availability { get; set; }

    public virtual ICollection<EventAttendance> EventAttendances { get; } = new List<EventAttendance>();
}
