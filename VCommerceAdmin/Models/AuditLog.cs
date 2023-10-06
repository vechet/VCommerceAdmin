using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class AuditLog
{
    public int Id { get; set; }

    public int AuditLogControllerId { get; set; }

    public int AuditLogActionId { get; set; }

    public int? TransactionId { get; set; }

    public string? TransactionKeyValue { get; set; }

    public int? Version { get; set; }

    public string? Description { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual AuditLogAction AuditLogAction { get; set; } = null!;

    public virtual AuditLogController AuditLogController { get; set; } = null!;
}
