using CleanArchitecture.MVC.Services.Contracts;

namespace CleanArchitecture.MVC.Services.Abstract
{
    

    public abstract class ApiResponse<T> : IApiResponse<T>
    {
        public string Message { get; set; }
        public string ValidationErrors { get; set; }
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
    }
}
