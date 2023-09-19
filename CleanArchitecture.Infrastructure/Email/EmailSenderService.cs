using CleanArchitecture.Application.Contracts.Infrastructure;

namespace CleanArchitecture.Infrastructure.Email
{
    public class EmailSenderService: IEmailSenderService
    {
        public async Task<bool> SendEmailAsync(Application.Models.Infrastructure.Email email)
        {
            throw new NotImplementedException();
        }
    }
}
