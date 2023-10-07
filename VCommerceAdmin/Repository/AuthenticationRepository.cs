using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using VCommerceAdmin.ApiModels.Authentication;
using VCommerceAdmin.Data;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Models;
using VCommerceAdmin.Repository.Interface;

namespace VCommerceAdmin.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IDbContextFactory<VcommerceContext> _contextFactory;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthenticationRepository(
            IDbContextFactory<VcommerceContext> contextFactory,
            UserManager<IdentityUser> userManager)
        {
            _contextFactory = contextFactory;
            _userManager = userManager;
        }

        public GetMeResponse GetMe()
        {
            throw new NotImplementedException();
        }

        public LoginResponse Login(LoginRequest req)
        {
            throw new NotImplementedException();
        }

        public RefreshTokenResponse RefreshToken()
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> Register(RegisterRequest req)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var duplicateUser = await _userManager.FindByNameAsync(req.Username);
                    if (duplicateUser != null)
                    {
                        return new BaseResponse(0, ApiReturnError.DuplicateName.Value(), ApiReturnError.DuplicateName.Description());
                    }

                    var user = new IdentityUser
                    {
                        UserName = req.Username,
                        Email = req.Email,
                        PhoneNumber = req.Phone
                    };
                    var result = await _userManager.CreateAsync(user, req.Password);

                    if(result.Errors.Count() > 0 && result.Errors.FirstOrDefault().Code.ToLower().Contains("password"))
                    {
                        return new BaseResponse(0, ApiReturnError.InvalidPasswordFormat.Value(), ApiReturnError.InvalidPasswordFormat.Description());
                    }

                    // add audit log
                    //GlobalFunction.RecordAuditLog("Authentication", "Register", newBrand.Id, newBrand.Name, newBrand.Version, GetAuditDescription(context, newBrand.Id), context);
                    return new BaseResponse(0, ApiReturnError.Success.Value(), ApiReturnError.Success.Description());
                }
                catch (Exception ex)
                {
                    GlobalFunction.RecordErrorLog("AuthenticationRepository/Register", ex, context);
                    return new BaseResponse(0, ApiReturnError.DbError.Value(), ApiReturnError.DbError.Description());
                }
            }
        }
    }
}
