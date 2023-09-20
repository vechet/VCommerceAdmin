using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class CustomerType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Memo { get; set; }

    public bool IsSystemValue { get; set; }

    public short StatusId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int Version { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
