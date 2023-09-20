using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class SaleOrderDetail
{
    public int Id { get; set; }

    public int SaleOrderId { get; set; }

    public int ProductId { get; set; }

    public decimal Qty { get; set; }

    public int UmId { get; set; }

    public decimal TotalQty { get; set; }

    /// <summary>
    /// Price has changed by cashier in backend sale module
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Amount before disount on item,Amount=Qty* Price
    /// </summary>
    public decimal TotalAmount { get; set; }

    public decimal DiscountPercentage { get; set; }

    public decimal DiscountAmount { get; set; }

    /// <summary>
    /// Amount after disount on item
    /// </summary>
    public decimal GrandTotalAmount { get; set; }

    public string? Memo { get; set; }

    public decimal QtySold { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual SaleOrder SaleOrder { get; set; } = null!;

    public virtual Um Um { get; set; } = null!;
}
