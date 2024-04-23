using CleanArchitecture.Application.Interfaces.Identity;
using CleanArchitecture.Application.Models.Identity.Authentication;
using CleanArchitecture.Application.Models.Identity.Authorization;
using CleanArchitecture.Common.Results;
using CleanArchitecture.Identity.Contexts;
using CleanArchitecture.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
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

    public async Task<Result<AssigningPermissionResponse>> AssignPermissionToUser(AssigningPermissionRequest request)
    {
        try
        {
            //create user Permission Entity

            var newUserPermission = _dbContext.Set<ApplicationUserPermission>().Add(new ApplicationUserPermission()
            {
                PermissionId = request.permissionId,
                UserId = request.userId,

                CreatedOn = request.CreatedOn,
                UpdatedOn = request.UpdatedOn
            });

            await _dbContext.SaveChangesAsync();

            if (newUserPermission != null)
            {
                return Result.Success(new AssigningPermissionResponse());
            }
            else
            {
                return Result.Failure<AssigningPermissionResponse>("Fail To Insert User Permission");
            }

        }
        catch (Exception ex)
        {
            return Result.Failure<AssigningPermissionResponse>(ex);
        }
    }

    public async Task<Result<AssigningPermissionResponse>> UnAssignPermissionFromUser(AssigningPermissionRequest request)
    {
        try
        {
            //get the user permission

            var currentUserPermission = await _dbContext.Set<ApplicationUserPermission>()
                                                        .FirstOrDefaultAsync(c => c.UserId == request.userId && c.PermissionId == request.permissionId);


            if (currentUserPermission == null)
            {
                return Result.Failure<AssigningPermissionResponse>("Invalid User or Permission");
            }

            _dbContext.Set<ApplicationUserPermission>().Remove(currentUserPermission);

            await _dbContext.SaveChangesAsync();

            return Result.Success(new AssigningPermissionResponse());

        }
        catch (Exception ex)
        {
            return Result.Failure<AssigningPermissionResponse>(ex);
        }
    }

    public async Task<Result<AssignedPermissionResponse>> GetAssignedPermissionsForUser(AssignedPermissionRequest request)
    {
        try
        {

            var assignedPermissions = await _dbContext.Set<ApplicationUserPermission>()
                                                          .AsNoTracking()
                                                          .Include(i=>i.Permission)
                                                          .Where(c => c.UserId == request.UserId)
                                                          .Select(userPermission=> new Permission
                                                          {
                                                              Id= userPermission.Permission.Id,
                                                              Name= userPermission.Permission.Name,
                                                              Description= userPermission.Permission.Description
                                                          }).ToListAsync();



            return Result.Success(new AssignedPermissionResponse()
            {
                Permissions = assignedPermissions
            });

        }
        catch (Exception ex)
        {
            return Result.Failure<AssignedPermissionResponse>(ex);
        }
    }
}