using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult ReadConfig()
        {
            var configValues = new
            {
                AppConnectionString = _configuration["ConnectionStrings:AppConnectionString"],
                EnvName = _configuration["ASPNETCORE_ENVIRONMENT"],
                SigningKeysUserSecret = _configuration["Authentication:Schemes:Bearer:SigningKeys:0:Value"]
            };

            return Ok(configValues);
        }
    }
}
