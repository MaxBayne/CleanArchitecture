using CleanArchitecture.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using CleanArchitecture.Application.Interfaces.Identity;
using CleanArchitecture.Common.Results;
using CleanArchitecture.Common.Settings;
using CleanArchitecture.Application.Models.Identity.Authentication;

namespace CleanArchitecture.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser<Guid>> _userManager;
        private readonly SignInManager<AppUser<Guid>> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(UserManager<AppUser<Guid>> userManager, SignInManager<AppUser<Guid>> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }



        public async Task<Result<RegisterResponse>> RegisterAsync(RegisterRequest registerRequest)
        {
            try
            {

                //find User by username
                var userNameExist = await _userManager.FindByNameAsync(registerRequest.UserName);

                //if username exist
                if (userNameExist != null)
                {
                    return Result.Failure<RegisterResponse>($"UserName ({registerRequest.UserName}) already Exist");
                }

                //find user by email
                var userEmailExist = await _userManager.FindByEmailAsync(registerRequest.Email);

                //if email exist
                if (userEmailExist != null)
                {
                    return Result.Failure<RegisterResponse>($"Email ({registerRequest.Email}) already Exist");
                }

                //if username and email not exit then try to register it

                var newUser = new AppUser<Guid>()
                {
                    UserName = registerRequest.UserName,
                    NormalizedUserName = registerRequest.UserName.ToUpper(),

                    Email = registerRequest.Email,
                    NormalizedEmail = registerRequest.Email.ToUpper(),

                    EmailConfirmed = true
                };

                var registeredUser = await _userManager.CreateAsync(newUser, registerRequest.UserPassword);

                if (registeredUser.Succeeded)
                {
                    return Result.Success(new RegisterResponse
                    {
                        IsSuccess = true,
                        UserId = newUser.Id.ToString()
                    });
                }
                else
                {
                    return Result.Failure<RegisterResponse>(registeredUser.Errors.First().Description);
                }


            }
            catch (Exception ex)
            {
                return Result.Failure<RegisterResponse>(ex);
            }
        }

        public async Task<Result<LoginResponse>> LoginAsync(LoginRequest loginRequest)
        {
            try
            {
                //find User by username
                var user = await _userManager.FindByNameAsync(loginRequest.UserName);

                //if username not exist
                if (user == null)
                {
                    return Result.Failure(new LoginResponse(), $"UserName ({loginRequest.UserName}) not found");
                }

                //Compare Security Stamp
                if (loginRequest.SecurityStamp != user.SecurityStamp)
                {
                    throw new UnauthorizedAccessException("SecurityStamp Not Matched");
                }

                //if username exit then try to login by username and password
                var loginResult = await _signInManager.PasswordSignInAsync(user.UserName!, loginRequest.UserPassword, isPersistent: false, lockoutOnFailure: false);

                //if password not valid
                if (!loginResult.Succeeded)
                {
                    throw new AuthenticationException("Invalid Password !");
                }


                //if user exist and login success then try to generate access token for that user with claims

                var userClaims = await CreateUserClaimsAsync(user);

                var jwtToken = GenerateJwtToken(_jwtSettings, userClaims);

                return Result.Success(new LoginResponse()
                {
                    IsSuccess = true,

                    UserId = user.Id,
                    UserName = user.UserName!,
                    UserEmail = user.Email!,
                    UserClaims = userClaims,

                    UserToken = jwtToken.TokenString
                });
            }
            catch (Exception ex)
            {
                return Result.Failure<LoginResponse>(ex);
            }
        }



        public async Task<List<User>> GetUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync("Users");

            return users.Select(appUser => new User
            {
                UserId = appUser.Id.ToString(),
                UserName = appUser.UserName,
                UserEmail = appUser.Email!
            }).ToList();
        }

        public async Task<List<User>> GetSupervisors()
        {
            var supervisors = await _userManager.GetUsersInRoleAsync("Supervisors");

            return supervisors.Select(appUser => new User
            {
                UserId = appUser.Id.ToString(),
                UserName = appUser.UserName,
                UserEmail = appUser.Email!
            }).ToList();
        }

        public async Task<List<User>> GetAdministrators()
        {
            var administrators = await _userManager.GetUsersInRoleAsync("Administrators");

            return administrators.Select(appUser => new User
            {
                UserId = appUser.Id.ToString(),
                UserName = appUser.UserName,
                UserEmail = appUser.Email!
            }).ToList();
        }

        #region Helper

        /// <summary>
        /// Token is some encoded String that contain user claims and has expire time and signed and client app send it inside header of every request
        /// </summary>
        /// <param name="jwtSettings"></param>
        /// <param name="userClaims"></param>
        /// <returns></returns>
        private (SecurityToken Token,string TokenString) GenerateJwtToken(JwtSettings jwtSettings,IEnumerable<Claim> userClaims)
        {
            // Create a security key that will be used to sign the jwt token to sure that data not edited over network
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.IssuerSigningKey));

            // Create a signing credential.
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Create a JWT token Descriptor that describe the content of Token
            var jwtTokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer= jwtSettings.Issuer,
                Audience= jwtSettings.Audience,
                Subject=new ClaimsIdentity(userClaims),//claims mean info for user like email,name,role mobile etc..
                SigningCredentials = signingCredentials,
                Expires= DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings.DurationInMinutes))
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var jwtToken=jwtTokenHandler.CreateToken(jwtTokenDescriptor);

            var jwtTokenAsString = jwtTokenHandler.WriteToken(jwtToken);

            return (Token: jwtToken,TokenString: jwtTokenAsString) ;

        }

        private async Task<IEnumerable<Claim>> CreateUserClaimsAsync(AppUser<Guid> user)
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
                new(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new(ClaimTypes.Name,user.UserName!),
                new(ClaimTypes.Email,user.Email!)
            };

            //Combine All Claims into one list
            var claims = customClaims.Union(userClaims).Union(roleClaims);

            return claims;
        }

        #endregion
    }
}
