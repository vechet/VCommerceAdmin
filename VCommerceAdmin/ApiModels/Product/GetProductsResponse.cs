namespace VCommerceAdmin.ApiModels
{
    public class GetProductsResponse
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
        public string ProductTypeName { get; set; } = null!;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public int? BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public string? Memo { get; set; }
        public short StatusId { get; set; }
        public string StatusName { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}