namespace VCommerceAdmin.CustomModels
{
    public class BrandCreateRequest
    {
        public string Name { get; set; } = null!;
        public string? Memo { get; set; }
        public short StatusId { get; set; }
    }
}