using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Memo { get; set; }

    public bool IsSystemValue { get; set; }

    public short StatusId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int Version { get; set; }

    public virtual ICollection<PhotoAndVideo> PhotoAndVideos { get; set; } = new List<PhotoAndVideo>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Status Status { get; set; } = null!;
}
