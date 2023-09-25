using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using CleanArchitecture.API.Attributes;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Commands;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Queries;
using CleanArchitecture.Application.CQRS.Mediators.Requests.Book.Commands;
using CleanArchitecture.Application.CQRS.Mediators.Requests.Book.Queries;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;

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
        public async Task<ActionResult<QueryResponse<List<ViewBookDto>>>> Get()
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var request = new GetBookListQueryRequest();
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

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        [ResponseType(StatusCodes.Status200OK)]
        [ResponseType(StatusCodes.Status404NotFound)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<QueryResponse<ViewBookDto>>> Get(int id)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var request = new GetBookQueryRequest() 
                {
                    BookId= id 
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
        [HttpPost]
        [ResponseType(StatusCodes.Status201Created)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateCommandResponse<ViewBookDto>>> Post([FromBody] CreateBookDto newBook)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new CreateBookCommandRequest()
                {
                    CreateBookDto = newBook
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
                    return CreatedAtAction(nameof(Get),new {id=response.CreatedData!.Id},response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        [ResponseType(StatusCodes.Status204NoContent)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UpdateCommandResponse<ViewBookDto>>> Put(int id, [FromBody] UpdateBookDto updatedBook)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new UpdateBookCommandRequest()
                {
                    BookId = id,
                    UpdatedBookDto= updatedBook
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
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        [ResponseType(StatusCodes.Status204NoContent)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DeleteCommandResponse<ViewBookDto>>> Delete(int id)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new DeleteBookCommandRequest()
                {
                    BookId = id
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
