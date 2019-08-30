using System;
using System.Collections.Generic;

namespace Fenerbahce.Models.EntityModels
{
    public class UserEntity
    {
        public UserEntity()
        {
            UserRoles = new List<UserRoleEntity>();
            Roles = new List<RoleEntity>();
            InstructorGroups = new List<InstructorGroupEntity>();
            Groups = new List<GroupEntity>();
            StudentParents = new List<StudentParentEntity>();
            Students = new List<StudentEntity>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public IList<UserRoleEntity> UserRoles { get; set; }
        public IList<RoleEntity> Roles { get; set; }
        public IList<InstructorGroupEntity> InstructorGroups { get; set; }
        public IList<GroupEntity> Groups { get; set; }
        public IList<StudentParentEntity> StudentParents { get; set; }
        public IList<StudentEntity> Students { get; set; }
    }
}
