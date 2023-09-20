using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class CustomerShippingAddress
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string? Name { get; set; }

    public string? Memo { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public string? AddressDisplay { get; set; }

    public string? ContactPerson { get; set; }

    public string? ContactNumber { get; set; }

    public short StatusId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();

    public virtual Status Status { get; set; } = null!;
}
