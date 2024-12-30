using AutoMapper;
using Identity.Application.DTOs.Request;
using Identity.Application.DTOs.Response;
using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Mappers
{
    public class PermissionMapper : Profile
    {
        public PermissionMapper() 
        {
            CreateMap<ReqCreatePermission, Permission>();
            CreateMap<ReqUpdatePermission, Permission>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Permission, RespPermission>();
        }
    }
}
