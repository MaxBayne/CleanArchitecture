using CleanArchitecture.Application.Interfaces.Identity;
using CleanArchitecture.Application.Models.Identity.Authentication;
using CleanArchitecture.Application.Models.Identity.Authorization;
using CleanArchitecture.Common.Results;
using CleanArchitecture.Identity.Contexts;
using CleanArchitecture.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Identity.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly ApplicationIdentityDbContext _dbContext;
    private readonly ILogger<AuthorizationService> _logger;

    public AuthorizationService(ApplicationIdentityDbContext dbContext,ILogger<AuthorizationService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    

    
}