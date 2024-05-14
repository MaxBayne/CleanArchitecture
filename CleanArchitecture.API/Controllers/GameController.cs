using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using CleanArchitecture.API.Attributes;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Game;
using CleanArchitecture.Application.Mediators.CQRS.Game.Commands.Requests;
using CleanArchitecture.Application.Mediators.CQRS.Game.Queries.Requests;


// ReSharper disable NotAccessedField.Local

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IMediator _mediator;

        public GameController(ILogger<GameController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ResponseType(typeof(List<ViewGameDto>), StatusCodes.Status200OK)]
        [ResponseType(StatusCodes.Status204NoContent)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var request = new GetGamesQuery();
                var response = await _mediator.Send(request, cancellationToken);

                if (response.IsSuccess)
                {
                    //On Response Success

                    if (!response.Value!.ViewGamesDto.Any())
                    {
                        return NoContent();
                    }
                    
                    return Ok(response.Value.ViewGamesDto);
                }
                else
                {
                    //On Response Failed
                    return BadRequest(response.ProblemDetails);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<GameController>/5
        // ReSharper disable once RouteTemplates.RouteParameterConstraintNotResolved
        [HttpGet("{id:int}")]
        [ResponseType(typeof(ViewGameDto), StatusCodes.Status200OK)]
        [ResponseType(StatusCodes.Status404NotFound)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var request = new GetGameQuery(id);

                var response = await _mediator.Send(request, cancellationToken);

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.ProblemDetails);
                }
                else
                {
                    //On Response Success

                    if (response.Value is { ViewGameDto: null })
                    {
                        return NotFound();
                    }

                    return Ok(response.Value!.ViewGameDto);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

      
        // POST api/<GameController>
        [HttpPost]
        [ResponseType(StatusCodes.Status201Created)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateGameDto newGame, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new CreateGameCommand(newGame);

                var response = await _mediator.Send(command, cancellationToken);

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.ProblemDetails);
                }
                else
                {
                    //On Response Success
                    return CreatedAtAction(nameof(Get), new { id = response.Value!.ViewGameDto.Id }, response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        // PUT api/<GameController>/5
        [HttpPut("{id}")]
        [ResponseType(StatusCodes.Status204NoContent)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateGameDto updatedGame, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new UpdateGameCommand(id,0, updatedGame);
                
                var response = await _mediator.Send(command, cancellationToken);

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.ProblemDetails);
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

        // DELETE api/<GameController>/5
        [HttpDelete("{id}")]
        [ResponseType(StatusCodes.Status204NoContent)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new DeleteGameCommand(id);

                var response = await _mediator.Send(command, cancellationToken);

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.ProblemDetails);
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
