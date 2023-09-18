using CleanArchitecture.Application.CQRS.Mediators.Responses.Abstract;

namespace CleanArchitecture.Application.CQRS.Mediators.Responses.Commands
{
    public class CreateCommandResponse<T>:BaseCommandResponse
    {
        /// <summary>
        /// Created Data after Create Operation
        /// </summary>
        public T? CreatedData { get; set; } = default(T);
    }
}
