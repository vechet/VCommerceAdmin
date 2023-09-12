using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using VCommerceAdmin.CustomModels;
using VCommerceAdmin.Data;
using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.Controllers.Api
{
    [Route("api/v1")]
    [ApiController]
    public class BrandApiController : ControllerBase
    {
        private readonly VcommerceContext _db;

        public BrandApiController(VcommerceContext db)
        {
            _db = db;
        }

        [HttpPost("Brands")]
        public ApiResponse<List<BrandResponse>> Brands([FromBody] BrandRequest req)
        {
            var brands = _db.Brands.Select(x => new BrandResponse
            {
                Id = x.Id,
                Name = x.Name,
                Memo = x.Memo,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                StatusId = x.StatusId,
                StatusName = x.Status.Name,
            }).OrderByDescending(x => x.Id).ToList();

            return new ApiResponse<List<BrandResponse>>(brands);
        }
    }
}
