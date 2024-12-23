using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? PasswordHash { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<AuditLog> AuditLogs { get; } = new List<AuditLog>();

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}
