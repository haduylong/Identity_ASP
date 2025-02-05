﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.DTOs.Request
{
    public class UserRequest
    {

    }

    public class UserCreateRequest
    {

        [Required]
        [MinLength(3, ErrorMessage = "Password must be at least {0} character")]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least {0} character")]
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
