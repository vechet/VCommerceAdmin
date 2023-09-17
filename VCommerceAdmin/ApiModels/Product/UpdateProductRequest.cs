namespace VCommerceAdmin.ApiModels
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Barcode { get; set; }
        public decimal Cost { get; set; }
        public string? Photo { get; set; }
        public decimal ReorderPoint { get; set; }
        public decimal MaxPoint { get; set; }
        public DateTime OpenningBalanceDate { get; set; }
        public int ProductTypeId { get; set; }
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string? Memo { get; set; }
        public short StatusId { get; set; }
    }
}