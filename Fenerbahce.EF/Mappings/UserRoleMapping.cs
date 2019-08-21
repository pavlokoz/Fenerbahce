using Fenerbahce.Models.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Fenerbahce.EF.Mappings
{
    public class UserRoleMapping : EntityTypeConfiguration<UserRoleEntity>
    {
        public UserRoleMapping()
        {
            ToTable("dbo.UserRole");
            HasKey(x => new { x.RoleId, x.UserId});

            Property(x => x.RoleId).HasColumnName("RoleId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.UserId).HasColumnName("UserId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(x => x.Role).WithMany(y => y.UserRoles).HasForeignKey(z => z.RoleId);
            HasRequired(x => x.User).WithMany(y => y.UserRoles).HasForeignKey(z => z.UserId);
        }
    }
}
