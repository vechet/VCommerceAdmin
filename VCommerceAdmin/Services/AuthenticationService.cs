using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using VCommerceAdmin.ApiModels.Authentication;
using VCommerceAdmin.Services.Interface;

namespace VCommerceAdmin.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LoginResponse Login(LoginRequest req)
        {
            var req2 = new LoginRequest();
            req2.Username = "vechet";
            var token = CreateToken(req2);
            return new LoginResponse();
        }

        public RegisterResponse Register(RegisterRequest req)
        {
            throw new NotImplementedException();
        }

        public string CreateToken(LoginRequest req)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, req.Username)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
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
    }
}
