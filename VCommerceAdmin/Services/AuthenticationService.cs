using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
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
                var userToken = new LoginToken();
                userToken = CreateToken(user);
                return new LoginResponse(userToken, ApiReturnError.Success.Value(), ApiReturnError.Success.Description());
            }
            else
            {
                return new LoginResponse(null, ApiReturnError.WrongUserNameOrPassword.Value(), ApiReturnError.WrongUserNameOrPassword.Description());
            }
        }

        public async Task<BaseResponse> Register(RegisterRequest req)
        {
            return await _authenticationRepository.Register(req);
        }

        private LoginToken CreateToken(IdentityUser user)
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

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            var expirationTime = token.Claims.Last().Value;
            var loginToken = new LoginToken(jwt, expirationTime);
            return loginToken;
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
            return  new GetMeResponse(userAccount, ApiReturnError.Success.Value(), ApiReturnError.Success.Description());
        }

        public RefreshTokenResponse RefreshToken()
        {
            var refreshToken = _httpContextAccessor.HttpContext.Request.Cookies["refreshToken"];
            return new RefreshTokenResponse(null, ApiReturnError.Success.Value(), ApiReturnError.Success.Description());
        }
    }
}
