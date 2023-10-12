using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Books.Queries
{
    public class GetBookListQueryHandler : RequestHandler<GetBookListQuery, Result<List<ViewBookDto>>, IBookRepository>
    {
        public GetBookListQueryHandler(IBookRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<Result<List<ViewBookDto>>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //Get Data from Database using Repository as Entities
                var booksEntities = await Repository.GetAllAsync();

                //Convert Domain Entity to Dto using AutoMapper
                var booksDto = AutoMapper.Map<List<ViewBookDto>>(booksEntities);

                return Result.Success(booksDto);
            }
            catch (Exception e)
            {
                return Result.Failure(new List<ViewBookDto>(),e);
            }
        }


    }
}
