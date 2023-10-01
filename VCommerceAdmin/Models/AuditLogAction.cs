using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class AuditLogAction
{
    public int Id { get; set; }

    public string KeyName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int AuditAction { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }
}
