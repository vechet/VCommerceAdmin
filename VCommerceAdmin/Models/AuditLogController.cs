using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class AuditLogController
{
    public int Id { get; set; }

    public string? KeyName { get; set; }

    public string Name { get; set; } = null!;

    public int? GroupId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }
}
