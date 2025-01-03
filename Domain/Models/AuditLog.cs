﻿using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class AuditLog
{
    public int LogId { get; set; }

    public int? UserId { get; set; }

    public string? Action { get; set; }

    public DateTime? ActionDate { get; set; }

    public virtual User? User { get; set; }
}
