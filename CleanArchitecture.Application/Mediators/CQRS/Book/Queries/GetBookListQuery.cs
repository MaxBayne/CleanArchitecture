using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Common.Results;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Queries
{
    public class GetBookListQuery : IRequest<Result<List<ViewBookDto>>>
    {
    }
}
