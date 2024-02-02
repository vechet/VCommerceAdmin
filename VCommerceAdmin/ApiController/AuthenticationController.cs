using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VCommerceAdmin.ApiModels.Authentication;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Services;
using VCommerceAdmin.Services.Interface;

namespace VCommerceAdmin.ApiController
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("v1/authentication/login")]
        public async Task<ApiResponse<LoginResponse>> Login([FromBody] LoginRequest req)
        {
            return new ApiResponse<LoginResponse>(await _authenticationService.Login(req));
        }

        [AllowAnonymous]
        [HttpPost("v1/authentication/register")]
        public async Task<ApiResponse<BaseResponse>> Register([FromBody] RegisterRequest req)
        {
            return new ApiResponse<BaseResponse>(await _authenticationService.Register(req));
        }

        [HttpPost("v1/authentication/get-me")]
        public async Task<ApiResponse<GetMeResponse>> GetMe()
        {
            return new ApiResponse<GetMeResponse>(await _authenticationService.GetMe());
        }

        [HttpPost("v1/authentication/refresh-token")]
        public ApiResponse<RefreshTokenResponse> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            return new ApiResponse<RefreshTokenResponse>(_authenticationService.RefreshToken());
        }
    }
}