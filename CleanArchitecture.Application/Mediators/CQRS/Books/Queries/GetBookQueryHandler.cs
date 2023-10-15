using AutoMapper;

using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Books.Queries
{
    public class GetUserQueryHandler : RequestHandler<GetBookQuery, Result<ViewBookDto>>
    {
        private readonly IBookRepository _bookRepository;
        public GetUserQueryHandler(IBookRepository bookRepository, IMapper mapper) : base(mapper)
        {
            _bookRepository = bookRepository;
        }

        public override async Task<Result<ViewBookDto>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //Get Data from Database using Repository as Entities
                var bookEntity = await _bookRepository.GetAsync(request.BookId);

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
