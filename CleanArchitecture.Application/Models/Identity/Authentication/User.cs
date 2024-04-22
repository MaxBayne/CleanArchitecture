namespace CleanArchitecture.Application.Models.Identity.Authentication;

public class User
{
    public string UserId { get; set; }
    public string? UserName { get; set; }
    public string UserEmail { get; set; }
}