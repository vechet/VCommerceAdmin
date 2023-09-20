using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int SupplierTypeId { get; set; }

    public string? ContactName { get; set; }

    public short? ContactGenderId { get; set; }

    public string? Phone1 { get; set; }

    public string? Phone2 { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public string? Address { get; set; }

    public decimal CreditLimited { get; set; }

    public decimal OpenningBalance { get; set; }

    public DateTime OpenningBalanceDate { get; set; }

    public string? Memo { get; set; }

    public bool IsSystemValue { get; set; }

    public short StatusId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int GenerateId { get; set; }

    public bool? IsReversed { get; set; }

    public virtual Status Status { get; set; } = null!;

    public virtual SupplierType SupplierType { get; set; } = null!;
}
