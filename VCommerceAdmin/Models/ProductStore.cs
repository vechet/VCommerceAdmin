using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class ProductStore
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int StoreId { get; set; }

    public decimal QtyOnHand { get; set; }

    public decimal QtyAvailable { get; set; }

    public decimal ReorderPoint { get; set; }

    public decimal MaxPoint { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
