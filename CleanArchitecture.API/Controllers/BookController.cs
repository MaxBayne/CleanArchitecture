using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using CleanArchitecture.API.Attributes;
using CleanArchitecture.Application.Mediators.CQRS.Books.Commands;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Common.Results;
using Microsoft.AspNetCore.Authorization;
using CleanArchitecture.Application.Mediators.CQRS.Books.Queries;

// ReSharper disable NotAccessedField.Local

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IMediator _mediator;

        public BookController(ILogger<BookController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        // GET: api/<BookController>
        
        [HttpGet]
        [ResponseType(StatusCodes.Status200OK)]
        [ResponseType(StatusCodes.Status204NoContent)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<List<ViewBookDto>>>> Get(CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var request = new GetBookListQuery();
                var response = await _mediator.Send(request, cancellationToken);

                if (response.IsSuccess)
                {
                    //On Response Success

                    if (!response.Value!.Any())
                    {
                        return NoContent();
                    }
                    
                    return Ok(response);
                }
                else
                {
                    //On Response Failed
                    return BadRequest(response.Value);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<BookController>/5
        [Authorize]
        [HttpGet("{id}")]
        [ResponseType(StatusCodes.Status200OK)]
        [ResponseType(StatusCodes.Status404NotFound)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<ViewBookDto>>> Get(int id, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var request = new GetBookQuery() 
                {
                    BookId= id 
                };

                var response = await _mediator.Send(request, cancellationToken);

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.Value);
                }
                else
                {
                    //On Response Success

                    if (response.Value==null)
                    {
                        return NotFound();
                    }

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<BookController>
        //[Authorize]
        [HttpPost]
        [ResponseType(StatusCodes.Status201Created)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<ViewBookDto>>> Post([FromBody] CreateBookDto newBook, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new CreateBookCommand()
                {
                    CreateBookDto = newBook
                };

                var response = await _mediator.Send(command, cancellationToken);

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.ProblemDetails);
                    
                }
                else
                {
                    //On Response Success
                    return CreatedAtAction(nameof(Get),new {id=response.Value!.Id},response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        // PUT api/<BookController>/5
        //[Authorize]
        [HttpPut("{id}")]
        [ResponseType(StatusCodes.Status204NoContent)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<ViewBookDto>>> Put(int id, [FromBody] UpdateBookDto updatedBook, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new UpdateBookCommand()
                {
                    BookId = id,
                    UpdatedBookDto= updatedBook
                };

                var response = await _mediator.Send(command, cancellationToken);

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.Errors);
                }
                else
                {
                    //On Response Success
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<BookController>/5
        //[Authorize]
        [HttpDelete("{id}")]
        [ResponseType(StatusCodes.Status204NoContent)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<ViewBookDto>>> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new DeleteBookCommand()
                {
                    BookId = id
                };

                var response = await _mediator.Send(command, cancellationToken);

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.Errors);
                }
                else
                {
                    //On Response Success
                    return  Ok(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
