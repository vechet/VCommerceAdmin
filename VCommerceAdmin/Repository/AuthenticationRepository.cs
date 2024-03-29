﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Security.Claims;
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
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthenticationRepository(
            IDbContextFactory<VcommerceContext> contextFactory,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _contextFactory = contextFactory;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<GetMeResponse> GetMe()
        {
            throw new NotImplementedException();
        }

        public async Task<LoginResponse> Login(LoginRequest req)
        {
            throw new NotImplementedException();
        }

        public async Task<RefreshTokenResponse> RefreshToken()
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
                        return new BaseResponse(0, ApiResponseStatus.DuplicateName.Value(), ApiResponseStatus.DuplicateName.Description());
                    }

                    var user = new IdentityUser
                    {
                        UserName = req.Username,
                        Email = req.Email,
                        PhoneNumber = req.Phone,
                    };
                    var result = await _userManager.CreateAsync(user, req.Password);

                    if(result.Errors.Count() > 0 && result.Errors.FirstOrDefault().Code.ToLower().Contains("password"))
                    {
                        return new BaseResponse(0, ApiResponseStatus.InvalidPasswordFormat.Value(), ApiResponseStatus.InvalidPasswordFormat.Description());
                    }

                    // add audit log
                    GlobalFunction.RecordAuditLog("Authentication", "Register", 1, user.UserName, 1, GetAuditDescription(context, user.Id), context);
                    //GlobalFunction.RecordAuditLog("Authentication", "Register", user.Id, user.UserName, user.Version, GetAuditDescription(context, user.Id), context);
                    return new BaseResponse(0, ApiResponseStatus.Success.Value(), ApiResponseStatus.Success.Description());
                }
                catch (Exception ex)
                {
                    GlobalFunction.RecordErrorLog("AuthenticationRepository/Register", ex, context);
                    return new BaseResponse(0, ApiResponseStatus.InternalError.Value(), ApiResponseStatus.InternalError.Description());
                }
            }
        }

        public string GetAuditDescription(VcommerceContext context, string id)
        {
            var type = (context.Users.Where(x => x.Id == id).Select(x => new
            {
                x.Id,
                x.UserName,
                x.Email,
                x.PhoneNumber,
                Version = 1
            })).FirstOrDefault();
            return JsonConvert.SerializeObject(type, Formatting.Indented, new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.IsoDateFormat });
        }

    }
}
