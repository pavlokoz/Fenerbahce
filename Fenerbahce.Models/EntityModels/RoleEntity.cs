using System.Collections.Generic;

namespace Fenerbahce.Models.EntityModels
{
    public class RoleEntity
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public IList<UserRoleEntity> UserRoles { get; set; }
        public IList<UserEntity> Users { get; set; }
    }
}
