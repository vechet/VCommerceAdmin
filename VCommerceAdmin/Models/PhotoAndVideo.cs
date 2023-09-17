using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class PhotoAndVideo
{
    public int Id { get; set; }

    public int? SortOrder { get; set; }

    public string FileName { get; set; } = null!;

    public int? CategoryId { get; set; }

    public int? BrandId { get; set; }

    public int? ProductId { get; set; }

    public int? UserAccountId { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Product? Product { get; set; }
}
