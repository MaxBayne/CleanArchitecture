using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace CleanArchitecture.Blazor.Server.Security.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }



        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            try
            {
                var authHeader = Request.Headers["Authorization"].ToString();
                var authHeaderValue = authHeader.Split(" ")[1];
                var decodedAuthString = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderValue));
                var credentials = decodedAuthString.Split(":");
                var username = credentials[0];
                var password = credentials[1];

                // Validate username and password (e.g., check against database or other source)
                if (IsValidUser(username, password))
                {
                    //بيانات الهوية
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, username));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, "Admins"));
                    claims.Add(new Claim(ClaimTypes.Role, "Managers"));

                    //الهوية مع تحديد بيانات الهوية
                    var identity = new ClaimsIdentity(claims, Scheme.Name);

                    //المستخدم مع تحديد الهوية User
                    var principal = new ClaimsPrincipal(identity);

                    //تذكرة الدخول للمستخدم
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
                else
                {
                    return AuthenticateResult.Fail("Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail($"Error: {ex.Message}");
            }
        }

        #region Helper

        private bool IsValidUser(string username, string password)
        {
            // Implement your own logic to validate the user (e.g., check against database)
            // Return true if valid, false otherwise
            // Example:
            return username == "myuser" && password == "mypassword";
        }

        #endregion
    }
}
