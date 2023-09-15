using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class Status
{
    public short Id { get; set; }

    public string Name { get; set; } = null!;

    public string KeyName { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<Brand> Brands { get; set; } = new List<Brand>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();

    public virtual ICollection<ProductType> ProductTypes { get; set; } = new List<ProductType>();

    public virtual ICollection<Um> Ums { get; set; } = new List<Um>();
}
