using CleanArchitecture.Application.Models.Infrastructure;

namespace CleanArchitecture.Application.Contracts.Infrastructure
{
    public interface IEmailSenderService
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
