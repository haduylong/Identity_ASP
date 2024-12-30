using AutoMapper;
using Identity.Application.DTOs.Request;
using Identity.Application.DTOs.Response;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using Identity.Domain.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PermissionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RespPermission> CreatePermissionAsync(ReqCreatePermission reqPermission)
        {
            var permission = _mapper.Map<Permission>(reqPermission);
            await _unitOfWork.PermissionRepository.CreateAsync(permission);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<RespPermission>(permission);
        }

        public async Task<RespPermission> UpdatePermissionAsync(ReqUpdatePermission reqPermission)
        {
            var permission = await _unitOfWork.PermissionRepository.GetAsync(reqPermission.Id);
            if(permission == null)
            {
                throw new ApplicationException("User not found");
            }

            _mapper.Map(reqPermission, permission);
            await _unitOfWork.PermissionRepository.UpdateAsync(permission);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<RespPermission>(permission);
        }

        public async Task<RespPermission> GetPermissionAsync(int id)
        {
            Permission permission = await _unitOfWork.PermissionRepository.GetAsync(id) 
                ?? throw new ApplicationException(String.Format("Permission ID = {0} not found", id));

            return _mapper.Map<RespPermission>(permission);
        }

        public async Task<IEnumerable<RespPermission>> GetAllPermissionAsync()
        {
            var permissions = await _unitOfWork.PermissionRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<RespPermission>>(permissions);
        }

        public async Task DeletePermissionAsync(int id)
        {
            await _unitOfWork.PermissionRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
