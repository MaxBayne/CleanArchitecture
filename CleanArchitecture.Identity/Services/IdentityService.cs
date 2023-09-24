using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.HandleExceptions.Exceptions;
using CleanArchitecture.Application.Models.Identity;
using CleanArchitecture.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser<Guid>> _userManager;
        private readonly SignInManager<ApplicationUser<Guid>> _signInManager;
        private readonly JWTSettings _jwtSettings;

        public IdentityService(UserManager<ApplicationUser<Guid>> userManager, SignInManager<ApplicationUser<Guid>> signInManager, IOptions<JWTSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            //find User by username
            var user = await _userManager.FindByNameAsync(loginRequest.UserName);

            //if username not exist
            if (user == null)
            {
                throw new NotFoundException($"UserName ({loginRequest.UserName}) not found");
            }

            //if username exit then try to login by username and password
            var loginResult = await _signInManager.PasswordSignInAsync(user.UserName!,loginRequest.UserPassword,isPersistent:false,lockoutOnFailure:false);

            //if password not valid
            if (!loginResult.Succeeded)
            {
                throw new Exception($"Invalid Password !");
            }

            //if user exist and login success then try to generate access token for that user
            var token = await GenerateJwtTokenAsync(user);
            

            return new LoginResponse()
            {
                UserId = user.Id,
                UserEmail = user.Email!,
                UserName = user.UserName!,
                UserToken = token
            };
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            throw new NotImplementedException();
        }

        #region Helper
        private async Task<string> GenerateJwtTokenAsync(ApplicationUser<Guid> user)
        {
            // Create a security key.
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            // Create a signing credential.
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Create a claims identity.
            var claimsIdentity = new ClaimsIdentity(new Claim[] 
            {
            new Claim(ClaimTypes.NameIdentifier, "1234567890"),
            new Claim(ClaimTypes.Name, "John Doe"),
            new Claim(ClaimTypes.Email, "john.doe@example.com"),
            });

            // Create a JWT token.
            var jwtToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                //claims: claimsIdentity.Claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_jwtSettings.DurationInMinutes))
                //signingCredentials: signingCredentials
            );

            // Write the token to a string.
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(jwtToken);

            return tokenString;

        }
        #endregion
    }
}
