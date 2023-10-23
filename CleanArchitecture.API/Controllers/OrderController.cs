using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using CleanArchitecture.API.Attributes;
using CleanArchitecture.Application.Mediators.CQRS.Order.Commands;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Order;

// ReSharper disable NotAccessedField.Local

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;

        public OrderController(ILogger<OrderController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        


        // POST api/<OrderController>
        [HttpPost]
        [ResponseType(StatusCodes.Status201Created)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateOrderDto newOrder, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new CreateOrderCommand(newOrder);
                
                var response = await _mediator.Send(command, cancellationToken);

                var viewOrderDto = response.Value!.ViewOrderDto;

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.ProblemDetails);
                }
                else
                {
                    //On Response Success
                    //return CreatedAtAction(nameof(Get),new {id=response.Value!.ViewOrderDto.Id},response);
                    return Created($"Order URI = {viewOrderDto.Id}", viewOrderDto);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        [ResponseType(StatusCodes.Status204NoContent)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateOrderDto updatedOrder, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new UpdateOrderCommand(id, 1, updatedOrder);

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

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        [ResponseType(StatusCodes.Status204NoContent)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new DeleteOrderCommand(id);

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
    }
}
