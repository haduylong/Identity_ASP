using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.DTOs.Request
{
    public class ReqPermission
    {
        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "Permission's name must be at least {1} characters")]
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ReqCreatePermission
    {

        [MinLength(3, ErrorMessage = "Permission's name must be at least {1} characters")]
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ReqUpdatePermission
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "Permission's name must be at least {1} characters")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
