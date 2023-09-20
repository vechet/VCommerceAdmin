using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Barcode { get; set; }

    public decimal Cost { get; set; }

    public DateTime OpenningBalanceDate { get; set; }

    public int ProductTypeId { get; set; }

    public int CategoryId { get; set; }

    public int? BrandId { get; set; }

    public string? Memo { get; set; }

    public short StatusId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int Version { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<PhotoAndVideo> PhotoAndVideos { get; set; } = new List<PhotoAndVideo>();

    public virtual ICollection<ProductStore> ProductStores { get; set; } = new List<ProductStore>();

    public virtual ProductType ProductType { get; set; } = null!;

    public virtual ICollection<ProductUmPrice> ProductUmPrices { get; set; } = new List<ProductUmPrice>();

    public virtual ICollection<SaleOrderDetail> SaleOrderDetails { get; set; } = new List<SaleOrderDetail>();

    public virtual Status Status { get; set; } = null!;
}
