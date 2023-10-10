using CleanArchitecture.Application.Exceptions.Abstract;

namespace CleanArchitecture.Application.Exceptions.Concretes
{
    public sealed class BadRequestException:BaseException
    {
        public BadRequestException(string message):base(message)
        {
            
        }
        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
