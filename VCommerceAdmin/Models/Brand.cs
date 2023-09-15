namespace VCommerceAdmin.Models;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Memo { get; set; }

    public short StatusId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public byte[]? Photo { get; set; }

    public virtual Status Status { get; set; } = null!;
}