namespace CleanArchitecture.Application.HandleExceptions.Abstract
{
    public abstract class BaseException:ApplicationException
    {
        public BaseException() : base()
        {

        }

        public BaseException(string message):base(message)
        {
            
        }

        public BaseException(string message,Exception innerException) : base(message,innerException)
        {

        }
    }
}
