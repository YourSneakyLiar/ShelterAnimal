using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class EventAttendance
{
    public int AttendanceId { get; set; }

    public int? EventId { get; set; }

    public int? VolunteerId { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Volunteer? Volunteer { get; set; }
}
