using Fenerbahce.EF.Mappings;
using Fenerbahce.Models.EntityModels;
using System;
using System.Data.Entity;

namespace Fenerbahce.EF.Context
{
    public class FenerbahceContext: DbContext
    {
        public FenerbahceContext() : base("name=" + Environment.MachineName + "DBConnectionString")
        {

        }

        public DbSet<TestEntity> Tests { get; set; }
        public DbSet<SchoolEntity> Schools { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }
        public DbSet<PaymentEntity> Payments { get; set; }
        public DbSet<SportEntity> Sports { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<InstructorGroupEntity> InstructorGroups { get; set; }
        public DbSet<StudentParentEntity> StudentParents { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder?.Configurations.Add(new TestMapping());
            modelBuilder?.Configurations.Add(new SchoolMapping());
            modelBuilder?.Configurations.Add(new GroupMapping());
            modelBuilder?.Configurations.Add(new SportMapping());
            modelBuilder?.Configurations.Add(new StudentMapping());
            modelBuilder?.Configurations.Add(new PaymentMapping());
            modelBuilder?.Configurations.Add(new InstructorGroupMapping());
            modelBuilder?.Configurations.Add(new StudentParentMapping());
            modelBuilder?.Configurations.Add(new UserMapping());
            modelBuilder?.Configurations.Add(new RoleMapping());
            modelBuilder?.Configurations.Add(new UserRoleMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
