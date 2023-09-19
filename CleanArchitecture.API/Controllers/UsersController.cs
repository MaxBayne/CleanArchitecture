using CleanArchitecture.Application.CQRS.Mediators.Requests.User.Commands;
using CleanArchitecture.Application.CQRS.Mediators.Requests.User.Queries;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

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
            try
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
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var request = new GetUserQueryRequest() 
                {
                    UserId=id 
                };

                var response = await _mediator.Send(request);

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.Message);
                }
                else
                {
                    //On Response Success

                    if (response.QueriedData==null)
                    {
                        return NoContent();
                    }

                    return Ok(response.QueriedData);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] CreateUserDto newUser)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new CreateUserCommandRequest()
                {
                    CreateUserDto = newUser
                };

                var response = await _mediator.Send(command);

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.Message);
                }
                else
                {
                    //On Response Success
                    return CreatedAtAction(nameof(Get),new {id=response.CreatedData!.Id},response.CreatedData);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateUserDto updatedUser)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new UpdateUserCommandRequest()
                {
                    UserId = id,
                    UpdatedUserDto= updatedUser
                };

                var response = await _mediator.Send(command);

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.Message);
                }
                else
                {
                    //On Response Success
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new DeleteUserCommandRequest()
                {
                    UserId = id
                };

                var response = await _mediator.Send(command);

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.Message);
                }
                else
                {
                    //On Response Success
                    return  NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
