using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class Store
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public string? Address { get; set; }

    public string? ShortcutInvoice { get; set; }

    public short Type { get; set; }

    public string? Memo { get; set; }

    public bool IsSystemValue { get; set; }

    public short StatusId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? InvoiceName { get; set; }

    public byte[]? ReceiptLogo { get; set; }

    public byte[]? InvoiceLogo { get; set; }

    public string? Vatin { get; set; }

    public int? ParrentId { get; set; }

    public virtual ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();

    public virtual Status Status { get; set; } = null!;

    public virtual GlobalParam TypeNavigation { get; set; } = null!;
}
