using AutoMapper;

namespace CleanArchitecture.Application.CQRS.Mediators.Handlers.Abstract
{
    public interface IHandlerBase
    {
    }

    public class HandlerBase<TRepository> : IHandlerBase where TRepository : class
    {
        protected readonly TRepository Repository;
        protected readonly IMapper AutoMapper;

        public HandlerBase(TRepository repository,IMapper mapper)
        {
            Repository=repository;
            AutoMapper=mapper;
        }
    }
}
