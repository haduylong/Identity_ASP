using Identity.Application.DTOs.Request;
using Identity.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface IPermissionService
    {
        Task<RespPermission> CreatePermissionAsync(ReqCreatePermission reqPermission);
        Task<RespPermission> UpdatePermissionAsync(ReqUpdatePermission reqPermission);
        Task<IEnumerable<RespPermission>> GetAllPermissionAsync();
        Task<RespPermission> GetPermissionAsync(int id);
        Task DeletePermissionAsync(int id);
    }
}
