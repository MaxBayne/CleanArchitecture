using CleanArchitecture.Application.CQRS.Mediators.Responses.Abstract;

namespace CleanArchitecture.Application.CQRS.Mediators.Responses.Queries
{
    public class QueryResponse<T>:BaseQueryResponse
    {
        /// <summary>
        /// Queried Data after get Operation
        /// </summary>
        public T? QueriedData { get; set; } = default(T);
    }
}
