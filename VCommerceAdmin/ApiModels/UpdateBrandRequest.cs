namespace VCommerceAdmin.ApiModels
{
    public class UpdateBrandRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Memo { get; set; }
        public short StatusId { get; set; }
    }
}