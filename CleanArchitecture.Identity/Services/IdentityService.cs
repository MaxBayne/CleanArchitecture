using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.HandleExceptions.Exceptions;
using CleanArchitecture.Application.Models.Identity;
using CleanArchitecture.Domain.Entities;
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
            try
            {
                //find User by username
                var user = await _userManager.FindByNameAsync(loginRequest.UserName);

                //if username not exist
                if (user == null)
                {
                    throw new NotFoundException($"UserName ({loginRequest.UserName}) not found");
                }

                //if username exit then try to login by username and password
                var loginResult = await _signInManager.PasswordSignInAsync(user.UserName!, loginRequest.UserPassword, isPersistent: false, lockoutOnFailure: false);

                //if password not valid
                if (!loginResult.Succeeded)
                {
                    throw new Exception($"Invalid Password !");
                }

                //if user exist and login success then try to generate access token for that user
                var token = await GenerateJwtTokenAsync(user, _jwtSettings);


                return new LoginResponse()
                {
                    UserId = user.Id,
                    UserName = user.UserName!,
                    UserEmail = user.Email!,
                    UserToken = token,
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new LoginResponse()
                {
                    IsSuccess = false,
                    Exception = e
                };
            }
            
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            throw new NotImplementedException();
        }

        #region Helper

        /// <summary>
        /// Token is some encoded String that contain user claims and has expire time and signed and client app send it inside header of every request
        /// </summary>
        /// <param name="user"></param>
        /// <param name="jwtSettings"></param>
        /// <returns></returns>
        private async Task<string> GenerateJwtTokenAsync(ApplicationUser<Guid> user, JWTSettings jwtSettings)
        {
            //Get Roles that user belong to it (user can belong to multi roles)
            var userRoles = await _userManager.GetRolesAsync(user);

            //Get User Claims From database (Claim is just information about user)
            var userClaims = await _userManager.GetClaimsAsync(user);

            //Generate claims for roles that user belong to it
            var roleClaims = new List<Claim>();
            foreach (var role in userRoles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }
           
            //generate custom claims
            var customClaims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.NameId,user.Id.ToString()),
                new(JwtRegisteredClaimNames.Name,user.UserName!),
                new(JwtRegisteredClaimNames.Sub,user.UserName!),
                new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Email,user.Email!)
            };

            //Combine All Claims into one list
            var claims = customClaims.Union(userClaims).Union(roleClaims);

            // Create a security key that will be used to sign the jwt token to sure that data not edited over network
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            // Create a signing credential.
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Create a JWT token.
            var jwtToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_jwtSettings.DurationInMinutes)),
                claims: claims,
                signingCredentials: signingCredentials
            );

            // Write the token to a string.
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);

        }
        #endregion
    }
}
