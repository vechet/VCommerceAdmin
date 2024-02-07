using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Data;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Repository.Interface;

namespace VCommerceAdmin.Repository
{
    public class SaleOrderRepository : ISaleOrderRepository
    {
        private readonly IDbContextFactory<VcommerceContext> _contextFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;

        public SaleOrderRepository(
            IDbContextFactory<VcommerceContext> contextFactory,
            IHttpContextAccessor httpContextAccessor,
            UserManager<IdentityUser> userManager)
        {
            _contextFactory = contextFactory;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<BaseResponse> CreateSaleOrder(CreateSaleOrderRequest req)
        {
            throw new NotImplementedException();
        }

        public async Task<GetDetailSaleOrderResponse> GetDetailSaleOrder(GetDetailSaleOrderRequest req)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var result = context.Brands.Where(x => x.Id == req.Id && x.Status.KeyName == "Active")
                        .Select(x => new DetailSaleOrderResponse
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Memo = x.Memo,
                            CreatedByUser = context.Users.FirstOrDefault(z => z.Id == x.CreatedBy).UserName,
                            CreatedBy = x.CreatedBy,
                            CreatedDate = x.CreatedDate.ToString(GlobalVariable.dateFormat),
                            ModifiedByUser = x.ModifiedBy.IsNullOrEmpty() ? null : context.Users.FirstOrDefault(z => z.Id == x.ModifiedBy).UserName,
                            ModifiedBy = x.ModifiedBy,
                            StatusId = x.StatusId,
                            StatusName = x.Status.Name,
                        }).FirstOrDefault();

                    return new GetDetailSaleOrderResponse(result, ApiResponseStatus.Success.Value(), ApiResponseStatus.Success.Description());
                }
                catch (Exception ex)
                {
                    GlobalFunction.RecordErrorLog("SaleOrdersRepository/GetDetailSaleOrder", ex, context);
                    return new GetDetailSaleOrderResponse(new DetailSaleOrderResponse(), ApiResponseStatus.InternalError.Value(), ApiResponseStatus.InternalError.Description());
                }
            }
        }

        public async Task<GetSaleOrdersResponse> GetSaleOrders(GetSaleOrdersRequest req)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> UpdateSaleOrder(UpdateSaleOrderRequest req)
        {
            throw new NotImplementedException();
        }

    }
}
