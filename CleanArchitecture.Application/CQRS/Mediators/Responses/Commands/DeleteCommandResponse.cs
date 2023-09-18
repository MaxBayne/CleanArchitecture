using CleanArchitecture.Application.CQRS.Mediators.Responses.Abstract;

namespace CleanArchitecture.Application.CQRS.Mediators.Responses.Commands
{
    public class DeleteCommandResponse<T>:BaseCommandResponse
    {
        /// <summary>
        /// Deleted Data after Delete Operation
        /// </summary>
        public T? DeletedData { get; set; } = default(T);

        /// <summary>
        /// Id of Deleted Record
        /// </summary>
        public object? DeletedId { get; set; }
    }
}
