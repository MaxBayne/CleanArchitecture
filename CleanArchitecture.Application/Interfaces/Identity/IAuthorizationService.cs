using CleanArchitecture.Application.Models.Identity.Authorization;
using CleanArchitecture.Common.Results;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Interfaces.Identity;

public interface IAuthorizationService
{
    /// <summary>
    /// Assign New Permission To User
    /// </summary>
    /// <returns></returns>
    Task<Result<AssigningPermissionResponse>> AssignPermissionToUser(AssigningPermissionRequest request);

    /// <summary>
    /// UnAssign Currentlly Permission From User
    /// </summary>
    /// <returns></returns>
    Task<Result<AssigningPermissionResponse>> UnAssignPermissionFromUser(AssigningPermissionRequest request);

    /// <summary>
    /// Get Assigned Permissions For User
    /// </summary>
    /// <returns></returns>
    Task<Result<AssignedPermissionResponse>> GetAssignedPermissionsForUser(AssignedPermissionRequest request);

    /// <summary>
    /// Check User Has Permission Assigned to Him
    /// </summary>
    /// <returns></returns>
    Task<bool> HasPermission(Guid userId,PermissionType permissionType);

}