using System.Collections.Generic;

namespace Fenerbahce.Models.EntityModels
{
    public class RoleEntity
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
