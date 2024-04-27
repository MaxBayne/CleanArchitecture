using System.Security.Claims;
using CleanArchitecture.API.Controllers;
using CleanArchitecture.Application.Mediators.CQRS.Book.Queries;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Common.Results;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace CleanArchitecture.Api.UnitTests
{
    public class BookControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly BookController _bookController;


        public BookControllerTests()
        {
            var loggerMock = new Mock<ILogger<BookController>>();
            _mediatorMock = new Mock<IMediator>();
            _bookController = new BookController(loggerMock.Object, _mediatorMock.Object);
        }

        [Fact]
        public async void GetBooks_UnAuthenticatedUser_ReturnUnauthorizedResult()
        {
            //Arrange ---------------------------------------------------------
            var cancellationToken = new CancellationToken();
            var requestCqrs = new GetBooksQuery();
            var viewBooksDto = new List<ViewBookDto> { new() };
            var responseCqrs = new GetBooksResponse(viewBooksDto);
            var httpContext = new DefaultHttpContext();

            _mediatorMock.Setup(x => x.Send(requestCqrs, cancellationToken)).ReturnsAsync(Result.Success(responseCqrs));

            _bookController.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            //Act ---------------------------------------------------------
            var response = await _bookController.Get(new CancellationToken());

            //Assert ---------------------------------------------------------
            response.Should().NotBeNull();
            response.Should().BeOfType<UnauthorizedResult>();
        }

        [Fact]
        public async void GetBooks_AuthenticatedUserWithBooks_ReturnOkResult()
        {
            //Arrange ---------------------------------------------------------
            var cancellationToken = new CancellationToken();
            var requestCqrs = new GetBooksQuery();
            var viewBooksDto = new List<ViewBookDto> { new() };
            var responseCqrs = new GetBooksResponse(viewBooksDto);
            var httpContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "TestUser"),
                    // Add any other claims as needed
                }, "TestAuthentication"))
            };

            _mediatorMock.Setup(x => x.Send(requestCqrs, cancellationToken)).ReturnsAsync(Result.Success(responseCqrs));

            _bookController.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };


            //Act ---------------------------------------------------------
            var response = await _bookController.Get(cancellationToken);

            //Assert ---------------------------------------------------------
            response.Should().NotBeNull();
            response.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async void GetBooks_AuthenticatedUserWithEmptyBooks_ReturnNoContentResult()
        {
            //Arrange ---------------------------------------------------------
            var cancellationToken = new CancellationToken();
            var requestCqrs = new GetBooksQuery();
            var viewBooksDto = new List<ViewBookDto>();
            var responseCqrs = new GetBooksResponse(viewBooksDto);
            var httpContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "TestUser"),
                    // Add any other claims as needed
                }, "TestAuthentication"))
            };


            _mediatorMock.Setup(x => x.Send(requestCqrs, cancellationToken)).ReturnsAsync(Result.Success(responseCqrs));

            _bookController.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };


            //Act ---------------------------------------------------------
            var response = await _bookController.Get(cancellationToken);

            //Assert ---------------------------------------------------------
            response.Should().NotBeNull();
            response.Should().BeOfType<NoContentResult>();
        }
    }
}