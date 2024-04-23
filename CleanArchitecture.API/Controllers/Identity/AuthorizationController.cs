using CleanArchitecture.API.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using CleanArchitecture.Application.Interfaces.Identity;
using CleanArchitecture.Application.Models.Identity.Authentication;
using CleanArchitecture.Application.Models.Identity.Authorization;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.API.Controllers.Identity
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILogger<AuthorizationController> _logger;
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService, ILogger<AuthorizationController> logger)
        {
            _authorizationService = authorizationService;
            _logger = logger;
        }

        [HttpGet("permissions")]
        [ResponseType(StatusCodes.Status200OK)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AssignedPermissionResponse>> GetAssignedPermissionsForUser(AssignedPermissionRequest request)
        {
            var assignedPermissionsResponse = await _authorizationService.GetAssignedPermissionsForUser(request);

            if (assignedPermissionsResponse.IsSuccess)
            {
                return Ok(assignedPermissionsResponse);
            }

            return BadRequest(assignedPermissionsResponse.Errors);
        }


        [HttpPost("assign")]
        [ResponseType(StatusCodes.Status200OK)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AssigningPermissionResponse>> AssignPermissionToUser(AssigningPermissionRequest request)
        {
            var assignPermissionResponse = await _authorizationService.AssignPermissionToUser(request);

            if (assignPermissionResponse.IsSuccess)
            {
                _logger.LogInformation($"Assigned Permission ({(PermissionType)request.permissionId}) To User successfully");
                return Ok(assignPermissionResponse);
            }

            _logger.LogInformation($"Assigned Permission ({(PermissionType)request.permissionId}) To User Failure");

            return BadRequest(assignPermissionResponse.Errors);
        }

        [HttpPost("unassign")]
        [ResponseType(StatusCodes.Status200OK)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AssigningPermissionResponse>> UnAssignPermissionFromUser(AssigningPermissionRequest request)
        {
            var unAssignPermissionResponse = await _authorizationService.UnAssignPermissionFromUser(request);

            if (unAssignPermissionResponse.IsSuccess)
            {
                _logger.LogInformation($"UnAssigned Permission ({(PermissionType)request.permissionId}) To User successfully");
                return Ok(unAssignPermissionResponse);
            }

            _logger.LogInformation($"UnAssigned Permission ({(PermissionType)request.permissionId}) To User Failure");

            return BadRequest(unAssignPermissionResponse.Errors);
        }

    }

}
