using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.ApiModels.Authentication;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Services.Interface;

namespace VCommerceAdmin.Services
{
    //https://www.youtube.com/watch?v=v7q3pEK1EA0
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public LoginResponse Login(LoginRequest req)
        {
            var userAccount = new UserAccount();
            userAccount.Token = CreateToken(req);
            return new LoginResponse(userAccount, ApiReturnError.Success.Value(), ApiReturnError.Success.Description());

        }

        public RegisterResponse Register(RegisterRequest req)
        {
            throw new NotImplementedException();
        }

        private string CreateToken(LoginRequest req)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, req.Username)
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

            return jwt;
        }

        public GetMeResponse GetMe()
        {
            var userAccount =new UserAccount();
            var username = "";
            if (_httpContextAccessor.HttpContext != null)
            {
                username = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            userAccount.Name = username;
            return new GetMeResponse(userAccount, ApiReturnError.Success.Value(), ApiReturnError.Success.Description());
        }

        public RefreshTokenResponse RefreshToken()
        {
            var refreshToken = _httpContextAccessor.HttpContext.Request.Cookies["refreshToken"];
            return new RefreshTokenResponse(null, ApiReturnError.Success.Value(), ApiReturnError.Success.Description());
        }
    }
}
