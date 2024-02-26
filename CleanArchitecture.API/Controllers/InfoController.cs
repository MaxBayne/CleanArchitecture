using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using CleanArchitecture.API.Attributes;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.API.ActionAttributes;

// ReSharper disable NotAccessedField.Local

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class InfoController : ControllerBase
    {
        private readonly ILogger<InfoController> _logger;
        private readonly IMediator _mediator;

        public InfoController(ILogger<InfoController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        // GET: api/<BookController>
        [LogActivity]
        [HttpGet]
        [ResponseType(typeof(List<ViewBookDto>), StatusCodes.Status200OK)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            try
            {
                //_logger.LogInformation("Info Controller");

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

       
    }
}
