using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Data;
using VCommerceAdmin.Repository.Interface;

namespace VCommerceAdmin.Repository
{
    public class SaleOrdersRepository : ISaleOrdersRepository
    {
        private readonly IDbContextFactory<VcommerceContext> _contextFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;

        public SaleOrdersRepository(
            IDbContextFactory<VcommerceContext> contextFactory,
            IHttpContextAccessor httpContextAccessor,
            UserManager<IdentityUser> userManager)
        {
            _contextFactory = contextFactory;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public Task<GetSaleOrdersResponse> GetSaleOrders(GetSaleOrdersRequest req)
        {
            throw new NotImplementedException();
        }
    }
}
