using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using FluentAssertions;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.Mediators.CQRS.Book.Commands;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Profiles;
using CleanArchitecture.Domain.Entities;
using FakeItEasy;

namespace CleanArchitecture.Application.UnitTests.CQRS.Books.Commands;


public class CreateBookCommandHandlerTests
{
    [Fact]
    public async Task Handle_When_ValidationFail_ShouldReturn_FailureResult()
    {
        //Arrange

        var unitOfWorkFake = A.Fake<IUnitOfWork>();
        var bookRepositoryFake = A.Fake<IBookRepository>();
        var notificationPublisherFake = A.Fake<INotificationPublisher>();
        var mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();

        var handler = new CreateBookCommandHandler(bookRepositoryFake, unitOfWorkFake, mapper, notificationPublisherFake);

        //make validation fail
        var command = new CreateBookCommand(new CreateBookDto { Title = "", Category = "", IsActive = true });

        //Act
        var result =await handler.Handle(command, default);


        //Assert
        result.IsFailure.Should().BeTrue();
        result.HasErrors.Should().BeTrue();
        result.Errors.Should().NotBeEmpty();
        
    }

    [Fact]
    public async Task Handle_When_ValidationSuccess_ShouldReturn_NotFailureResult()
    {
        //Arrange
        var unitOfWorkFake = A.Fake<IUnitOfWork>();
        var bookRepositoryFake = A.Fake<IBookRepository>();
        var notificationPublisherFake = A.Fake<INotificationPublisher>();
        var mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();

        var handler = new CreateBookCommandHandler(bookRepositoryFake, unitOfWorkFake, mapper, notificationPublisherFake);

        //make validation success
        var command = new CreateBookCommand(new CreateBookDto { Title = "Learning OOP", Category = "Programming", IsActive = true });

        //Act
        var result = await handler.Handle(command, default);
        

        //Assert
        result.IsFailure.Should().BeFalse();
        result.HasErrors.Should().BeFalse();
        result.Errors.Should().BeEmpty();
    }

    [Fact]
    public async Task Handle_When_ValidationSuccess_ShouldReturn_SuccessResultWithValue()
    {
        //Arrange
        var unitOfWorkFake = A.Fake<IUnitOfWork>();
        var bookRepositoryFake = A.Fake<IBookRepository>();
        var notificationPublisherFake = A.Fake<INotificationPublisher>();
        var newBookDto = new CreateBookDto { Title = "Learning OOP", Category = "Programming", IsActive = true };
        var newBookEntity = Book.Create(1, "Learning OOP","", "Programming", true);
        var mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();

        //Setup BookRepository Methods
        A.CallTo(() => bookRepositoryFake.AddAsync(newBookEntity, true)).Returns(newBookEntity);

        var handler = new CreateBookCommandHandler(bookRepositoryFake, unitOfWorkFake, mapper, notificationPublisherFake);

        var command = new CreateBookCommand(newBookDto);

        //Act
        var result = await handler.Handle(command, default);

        //Assert
        result.Value.Should().NotBeNull();

    }
}