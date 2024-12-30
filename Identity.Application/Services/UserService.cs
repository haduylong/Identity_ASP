using Identity.Application.DTOs.Request;
using Identity.Application.DTOs.Response;
using Identity.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Services
{
    public class UserService : IUserService
    {
        public Task<UserResponse> CreateUser(UserRequest user)
        {
            throw new NotImplementedException();
        }
    }
}
