using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class Currency
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsBaseCurrency { get; set; }

    public string Abbreviate { get; set; } = null!;

    public decimal RoundValue { get; set; }

    public string? Memo { get; set; }

    public bool IsSystemValue { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public short StatusId { get; set; }

    public virtual ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();

    public virtual Status Status { get; set; } = null!;
}
