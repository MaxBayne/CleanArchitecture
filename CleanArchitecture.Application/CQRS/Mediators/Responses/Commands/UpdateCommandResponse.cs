using CleanArchitecture.Application.CQRS.Mediators.Responses.Abstract;

namespace CleanArchitecture.Application.CQRS.Mediators.Responses.Commands
{
    public class UpdateCommandResponse<T>:BaseCommandResponse
    {
        /// <summary>
        /// Updated Data after Update Operation
        /// </summary>
        public T? UpdatedData { get; set; } = default(T);

        /// <summary>
        /// Original Data before Update Operation
        /// </summary>
        public T? OriginalData { get; set; } = default(T);

    }
}
