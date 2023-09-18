using AutoMapper;

namespace CleanArchitecture.Application.CQRS.Mediators.Abstract
{
    public interface IBaseHandler
    {
    }

    public class BaseHandler<TRepository> : IBaseHandler where TRepository : class
    {
        protected readonly TRepository Repository;
        protected readonly IMapper AutoMapper;

        public BaseHandler(TRepository repository,IMapper mapper)
        {
            Repository=repository;
            AutoMapper=mapper;
        }
    }
}
