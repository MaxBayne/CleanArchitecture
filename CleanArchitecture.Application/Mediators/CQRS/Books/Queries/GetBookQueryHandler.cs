using AutoMapper;

using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Books.Queries
{
    public class GetUserQueryHandler : RequestHandler<GetBookQuery, Result<ViewBookDto>,IBookRepository>
    {
        public GetUserQueryHandler(IBookRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<Result<ViewBookDto>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //Get Data from Database using Repository as Entities
                var bookEntity = await Repository.GetAsync(request.BookId);

                //Convert Domain Entity to Dto using AutoMapper
                var bookDto = AutoMapper.Map<ViewBookDto>(bookEntity);

                return Result.Success(bookDto);
            }
            catch (Exception e)
            {
                return Result.Failure(new ViewBookDto(), e);
            }
        }


    }
}
