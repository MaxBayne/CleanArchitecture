using CleanArchitecture.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Blazor.Server.Security.Account;

internal sealed class IdentityUserAccessor(UserManager<AppUser<Guid>> userManager, IdentityRedirectManager redirectManager)
{
    public async Task<AppUser<Guid>> GetRequiredUserAsync(HttpContext context)
    {
        var user = await userManager.GetUserAsync(context.User);

        if (user is null)
        {
            redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
        }

        return user;
    }
}
