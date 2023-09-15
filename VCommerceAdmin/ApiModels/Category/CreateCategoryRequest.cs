namespace VCommerceAdmin.ApiModels
{
    public class CreateCategoryRequest
    {
        public int ParentId { get; set; }
        public string Name { get; set; } = null!;
        public string? Memo { get; set; }
        public short StatusId { get; set; }
    }
}