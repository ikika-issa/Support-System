using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain_Models
{
    public class RolePermission : BaseEntity
    {
        public string RoleId { get; set; } = string.Empty;
        public IdentityRole? Role { get; set; }

        public Guid PermissionId { get; set; }
        public Permission? Permission { get; set; }
    }
}
