using Identity.Application.DTOs;
using Identity.Application.DTOs.Request;
using Identity.Application.DTOs.Response;
using Identity.Application.Interfaces;
using Identity.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<RespPermission>>> CreatePermissionController([FromBody] ReqCreatePermission reqPermission)
        {
            var dto = await _permissionService.CreatePermissionAsync(reqPermission);
            var res = new ApiResponse<RespPermission>
            {
                StatusCode = HttpStatusCode.Created,
                Message = "Create permission successfully",
                Data = dto
            };

            return CreatedAtAction(nameof(CreatePermissionController), res);
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse<RespPermission>>> UpdatePermissionController([FromBody] ReqUpdatePermission reqPermission)
        {
            var dto = await _permissionService.UpdatePermissionAsync(reqPermission);
            var res = new ApiResponse<RespPermission>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Update permission successfully",
                Data = dto
            };

            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<RespPermission>>> GetPermissionController([FromRoute(Name = "id")] int id)
        {
            var dto = await _permissionService.GetPermissionAsync(id);
            var res = new ApiResponse<RespPermission>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Get permission successfully",
                Data = dto
            };

            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<RespPermission>>>> GetAllPermissionController()
        {
            var dto = await _permissionService.GetAllPermissionAsync();
            var res = new ApiResponse<IEnumerable<RespPermission>>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Get all permission successfully",
                Data = dto
            };

            return Ok(res);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<RespPermission>>> DeletePermissionController([FromRoute(Name = "id")] int id)
        {
            await _permissionService.DeletePermissionAsync(id);
            var res = new ApiResponse<RespPermission>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Delete permission successfully",
            };

            return Ok(res);
        }
    }
}
