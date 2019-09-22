using System.Collections.Generic;

namespace Fenerbahce.Models.EntityModels
{
	public class RoleEntity
	{
		public RoleEntity()
		{
			UserRoles = new List<UserRoleEntity>();
			Users = new List<UserEntity>();
		}

		public int RoleId { get; set; }
		public string RoleName { get; set; }

		public IList<UserRoleEntity> UserRoles { get; set; }
		public IList<UserEntity> Users { get; set; }
	}
}
