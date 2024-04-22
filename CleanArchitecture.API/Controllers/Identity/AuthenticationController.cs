using CleanArchitecture.API.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using CleanArchitecture.Application.Interfaces.Identity;
using CleanArchitecture.Application.Models.Identity.Authentication;

namespace CleanArchitecture.API.Controllers.Identity
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService, ILogger<AuthenticationController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

       

        [HttpPost("register")]
        [ResponseType(StatusCodes.Status200OK)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest registerRequest)
        {
            var registerResponse = await _authenticationService.RegisterAsync(registerRequest);

            if (registerResponse.IsSuccess)
            {
                return Ok(registerResponse);
            }

            return BadRequest(registerResponse.Errors);
        }


        [HttpPost("login")]
        [ResponseType(StatusCodes.Status200OK)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            var loginResponse = await _authenticationService.LoginAsync(loginRequest);

            if (loginResponse.IsSuccess)
            {
                _logger.LogInformation($"User ({loginRequest.UserName}) logged successfully");
                return Ok(loginResponse);
            }

            _logger.LogInformation($"User ({loginRequest.UserName}) failed login");

            return BadRequest(loginResponse.Errors);
        }

       

       
    }

}
