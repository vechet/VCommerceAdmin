using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.ApiModels
{
    public class GetBrandsResponse : BaseResponse
    {
        public List<BrandsResponse> Brands;
        public GetBrandsResponse(List<BrandsResponse> brands, int code, string msg) 
        {
            Brands = brands;
            ErrorCode = code;
            ErrorMessage = msg;
        }
    }

    public class BrandsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Memo { get; set; }
        public string? Photo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public short StatusId { get; set; }
        public string StatusName { get; set; } = null!;
    }
}