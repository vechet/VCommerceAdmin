using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VCommerceAdmin.ApiModels.Authentication;
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
        public LoginResponse Login([FromForm] LoginRequest req)
        {
            return _authenticationService.Login(req);
        }

        [AllowAnonymous]
        [HttpPost("v1/authentication/register")]
        public RegisterResponse Register([FromForm] RegisterRequest req)
        {
            return _authenticationService.Register(req);
        }
    }
}
