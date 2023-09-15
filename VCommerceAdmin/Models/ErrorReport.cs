namespace VCommerceAdmin.Models;

public partial class ErrorReport
{
    public int Id { get; set; }

    public string? ModuleName { get; set; }

    public string? Message { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }
}