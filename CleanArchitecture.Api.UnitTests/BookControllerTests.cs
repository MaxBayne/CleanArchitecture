using System.Security.Claims;
using CleanArchitecture.API.Controllers;
using CleanArchitecture.Application.Mediators.CQRS.Book.Queries;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FakeItEasy;

namespace CleanArchitecture.Api.UnitTests
{
    public class BookControllerTests
    {
        [Fact]
        public async void GetBooks_When_UserUnAuthenticated_ShouldReturn_UnauthorizedResult()
        {
            //Arrange ---------------------------------------------------------
            var loggerFake = A.Fake<ILogger<BookController>>();
            var mediatorFake = A.Fake<IMediator>();
            var bookController = new BookController(loggerFake, mediatorFake);

            var cancellationToken = new CancellationToken();
            var requestCqrs = new GetBooksQuery();
            var viewBooksDto = new List<ViewBookDto> { new() };
            var responseCqrs = new GetBooksResponse(viewBooksDto);
            var httpContext = new DefaultHttpContext();

            A.CallTo(callSpecification:  () => mediatorFake.Send(requestCqrs, cancellationToken)).Returns(responseCqrs);

            bookController.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            //Act ---------------------------------------------------------
            var response = await bookController.Get(new CancellationToken());

            //Assert ---------------------------------------------------------
            response.Should().NotBeNull();
            response.Should().BeOfType<UnauthorizedResult>();
        }

        [Fact]
        public async void GetBooks_When_UserAuthenticatedWithBooks_ShouldReturn_OkResult()
        {
            //Arrange ---------------------------------------------------------
            var loggerFake = A.Fake<ILogger<BookController>>();
            var mediatorFake = A.Fake<IMediator>();
            var bookController = new BookController(loggerFake, mediatorFake);

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

            //_mediatorMock.Setup(x => x.Send(requestCqrs, cancellationToken)).ReturnsAsync(Result.Success(responseCqrs));

            A.CallTo(callSpecification: () => mediatorFake.Send(requestCqrs, cancellationToken)).Returns(responseCqrs);

            bookController.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };


            //Act ---------------------------------------------------------
            var response = await bookController.Get(cancellationToken);

            //Assert ---------------------------------------------------------
            response.Should().NotBeNull();
            response.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async void GetBooks_When_UserAuthenticatedWithEmptyBooks_ShouldReturn_NoContentResult()
        {
            //Arrange ---------------------------------------------------------
            var loggerFake = A.Fake<ILogger<BookController>>();
            var mediatorFake = A.Fake<IMediator>();
            var bookController = new BookController(loggerFake, mediatorFake);

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

            A.CallTo(callSpecification: () => mediatorFake.Send(requestCqrs, cancellationToken)).Returns(responseCqrs);
            //_mediatorMock.Setup(x => x.Send(requestCqrs, cancellationToken)).ReturnsAsync(Result.Success(responseCqrs));

            bookController.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };


            //Act ---------------------------------------------------------
            var response = await bookController.Get(cancellationToken);

            //Assert ---------------------------------------------------------
            response.Should().NotBeNull();
            response.Should().BeOfType<NoContentResult>();
        }
    }
}