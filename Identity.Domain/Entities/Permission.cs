using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Entities
{
    [Table("permissions")]
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "Permission's name must be at least {0} character")]
        public string Name { get; set; }

        [Column(TypeName ="ntext")]
        public string Description { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
