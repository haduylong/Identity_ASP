﻿using Identity.Application.DTOs.Request;
using Identity.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> CreateUser(UserRequest user);
    }
}
