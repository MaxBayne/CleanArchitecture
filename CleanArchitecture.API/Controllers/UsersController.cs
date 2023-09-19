using CleanArchitecture.Application.CQRS.Mediators.Requests.User.Queries;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IMediator _mediator;

        public UsersController(ILogger<UsersController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            //using Mediator to send request and mediator will handle it by handler and return the response
            var request = new GetUserListQueryRequest();
            var response = await _mediator.Send(request);
            
            if (!response.IsSuccess)
            {
                //On Response Failed
                return BadRequest(response.Message);
            }
            else
            {
                //On Response Success

                if (!response.QueriedData!.Any())
                {
                    return NoContent();
                }

                return Ok(response.QueriedData);
            }


            
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
