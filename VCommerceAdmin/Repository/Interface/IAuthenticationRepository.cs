﻿using VCommerceAdmin.ApiModels.Authentication;
using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.Repository.Interface
{
    public interface IAuthenticationRepository
    {
        Task<LoginResponse> Login(LoginRequest req);
        Task<BaseResponse> Register(RegisterRequest req);
        Task<GetMeResponse> GetMe();
        Task<RefreshTokenResponse> RefreshToken();
    }
}
