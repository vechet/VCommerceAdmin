using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class Um
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Abbreviation { get; set; }

    public string? Memo { get; set; }

    public bool IsSystemValue { get; set; }

    public short StatusId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int Version { get; set; }

    public virtual ICollection<SaleOrderDetail> SaleOrderDetails { get; set; } = new List<SaleOrderDetail>();

    public virtual Status Status { get; set; } = null!;
}
