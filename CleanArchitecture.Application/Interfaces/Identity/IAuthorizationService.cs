using CleanArchitecture.Application.Models.Identity.Authorization;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Interfaces.Identity;

public interface IAuthorizationService
{
    /// <summary>
    /// Assign New Permission To User
    /// </summary>
    /// <returns></returns>
    //Task<Result<AssigningPermissionResponse>> AssignPermissionToUser(AssigningPermissionRequest assigningPermissionRequest);

    /// <summary>
    /// UnAssign Currentlly Permission From User
    /// </summary>
    /// <returns></returns>
    //Task<Result<AssigningPermissionResponse>> UnAssignPermissionFromUser(AssigningPermissionRequest unAssigningPermissionRequest);

    /// <summary>
    /// Get Assigned Permissions For User
    /// </summary>
    /// <returns></returns>
    //Task<Result<AssignedPermissionResponse>> GetAssignedPermissionsForUser(AssignedPermissionRequest assignedPermissionRequest);

}