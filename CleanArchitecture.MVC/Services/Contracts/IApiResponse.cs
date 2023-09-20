namespace CleanArchitecture.MVC.Services.Contracts
{
    public interface IApiResponse<T>
    {
        string Message { get; set; }
        string ValidationErrors { get; set; }
        bool IsSuccess { get; set; }
        T Data { get; set; }
    }
}
