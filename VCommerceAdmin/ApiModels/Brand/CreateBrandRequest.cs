namespace VCommerceAdmin.ApiModels
{
    public class CreateBrandRequest
    {
        public string Name { get; set; } = null!;
        public string? Memo { get; set; }
        public IFormFile? Photo { get; set; }
        public short StatusId { get; set; }
    }
}