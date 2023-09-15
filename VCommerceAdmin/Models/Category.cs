namespace VCommerceAdmin.Models;

public partial class Category
{
    public int Id { get; set; }

    public int? ParentId { get; set; }

    public string Name { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public string? Memo { get; set; }

    public bool IsSystemValue { get; set; }

    public short StatusId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<Category> InverseParent { get; set; } = new List<Category>();

    public virtual Category? Parent { get; set; }

    public virtual Status Status { get; set; } = null!;
}