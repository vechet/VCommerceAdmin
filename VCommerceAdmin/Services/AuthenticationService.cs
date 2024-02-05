using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using NuGet.Protocol;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.ApiModels.Authentication;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Repository.Interface;
using VCommerceAdmin.Services.Interface;

namespace VCommerceAdmin.Services
{
    //https://www.youtube.com/watch?v=v7q3pEK1EA0
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthenticationService(
            IConfiguration configuration, 
            IHttpContextAccessor httpContextAccessor,
            IAuthenticationRepository authenticationRepository,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _authenticationRepository = authenticationRepository;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<LoginResponse> Login(LoginRequest req)
        {
            var result = await _signInManager.PasswordSignInAsync(req.Username, req.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(req.Username);
                var userToken = new TokenResponse();
                var accessToken = GenerateToken(user, 1);
                var refreshToken = GenerateToken(user, 30);
                userToken.AccessToken = accessToken.Token;
                userToken.ExpiresIn = accessToken.ExpiresIn;
                userToken.RefreshToken = refreshToken.Token;
                userToken.RefreshTokenExpiresIn = refreshToken.ExpiresIn;
                return new LoginResponse(userToken, ApiResponseStatus.Success.Value(), ApiResponseStatus.Success.Description());
            }
            else
            {
                return new LoginResponse(null, ApiResponseStatus.WrongUserNameOrPassword.Value(), ApiResponseStatus.WrongUserNameOrPassword.Description());
            }
        }

        public async Task<BaseResponse> Register(RegisterRequest req)
        {
            return await _authenticationRepository.Register(req);
        }

        private GenerateToken GenerateToken(IdentityUser user, int period)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
                //new Claim(ClaimTypes.Role, "Admin")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSetting:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // generate access token
            var generateAccessToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(period),
                signingCredentials: creds
            );
            var token = new JwtSecurityTokenHandler().WriteToken(generateAccessToken);
            var expiresIn = generateAccessToken.Claims.Last().Value;
            return new GenerateToken
            {
                Token = token,
                ExpiresIn = expiresIn,
            };
        }

        public async Task<GetMeResponse> GetMe()
        {
            var userAccount =new UserAccount();
            if (_httpContextAccessor.HttpContext != null)
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _userManager.FindByIdAsync(userId);
                userAccount.Id = user.Id;
                userAccount.Name = user.UserName;
                userAccount.Email = user.Email;
            }
            return  new GetMeResponse(userAccount, ApiResponseStatus.Success.Value(), ApiResponseStatus.Success.Description());
        }

        private bool ValidateRefreshToken(string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSetting:Token").Value));

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = false, // Customize these settings based on your requirements
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero // Adjust the clock skew if necessary
            };

            ClaimsPrincipal principal;
            SecurityToken securityToken = null;

            try
            {
                principal = tokenHandler.ValidateToken(refreshToken, validationParameters, out securityToken);
            }
            catch (SecurityTokenException ex)
            {
                // Log or handle specific token-related exceptions
                return false;
            }
            catch (Exception ex)
            {
                // Log or handle other exceptions
                return false;
            }

            // Check if the token is still valid
            return DateTime.UtcNow < securityToken.ValidTo;
        }

        private string ExtractRefreshToken(string authorizationHeader)
        {
            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                return authorizationHeader.Substring("Bearer ".Length).Trim();
            }
            return "";
        }


        public async Task<RefreshTokenResponse> RefreshToken()
        {
            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            var currentRefreshToken = ExtractRefreshToken(authorizationHeader);

            //Validate Refresh Token
            if (!ValidateRefreshToken(currentRefreshToken))
            {
                return new RefreshTokenResponse(null, ApiResponseStatus.Unauthorized.Value(), ApiResponseStatus.Unauthorized.Description());
            }

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            var userToken = new TokenResponse();
            var accessToken = GenerateToken(user, 1);
            var refreshToken = GenerateToken(user, 30);
            userToken.AccessToken = accessToken.Token;
            userToken.ExpiresIn = accessToken.ExpiresIn;
            userToken.RefreshToken = refreshToken.Token;
            userToken.RefreshTokenExpiresIn = refreshToken.ExpiresIn;
            return new RefreshTokenResponse(userToken, ApiResponseStatus.Success.Value(), ApiResponseStatus.Success.Description());
        }
    }
}
