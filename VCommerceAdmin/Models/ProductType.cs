using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class ProductType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string KeyName { get; set; } = null!;

    public string? Memo { get; set; }

    public short StatusId { get; set; }

    public int Ordering { get; set; }

    public virtual Status Status { get; set; } = null!;
}
