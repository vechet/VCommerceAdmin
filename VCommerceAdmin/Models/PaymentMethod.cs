namespace VCommerceAdmin.Models;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? KeyName { get; set; }

    public bool IsSystemValue { get; set; }

    public string? Memo { get; set; }

    public short StatusId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}