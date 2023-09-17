using CleanArchitecture.Application.HandleExceptions.Abstract;

namespace CleanArchitecture.Application.HandleExceptions.Exceptions
{
    public class BadRequestException:BaseException
    {
        public BadRequestException(string message):base(message)
        {
            
        }
        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
