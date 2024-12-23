﻿using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string? EventName { get; set; }

    public DateTime? EventDate { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<EventAttendance> EventAttendances { get; } = new List<EventAttendance>();
}
