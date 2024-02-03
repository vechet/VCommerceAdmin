using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.ApiModels
{
    public class GetDetailBrandResponse : BaseResponse
    {
        public DetailBrandResponse Brand { get; set; }
        public GetDetailBrandResponse(DetailBrandResponse brand, int code, string msg)
        {
            Brand = brand;
            Code = code;
            Message = msg;
        }
    }

    public class DetailBrandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Memo { get; set; }
        public string? Photo { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public short StatusId { get; set; }
        public string StatusName { get; set; } = null!;
    }
}