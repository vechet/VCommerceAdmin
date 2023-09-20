using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class ProductUmPrice
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int UmId { get; set; }

    public decimal Multiplier { get; set; }

    public decimal Price { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Um Um { get; set; } = null!;
}
