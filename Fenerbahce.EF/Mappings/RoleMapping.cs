using Fenerbahce.Models.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Fenerbahce.EF.Mappings
{
    public class RoleMapping: EntityTypeConfiguration<RoleEntity>
    {
        public RoleMapping()
        {
            ToTable("dbo.Role");
            HasKey(x => x.RoleId);

            Property(x => x.RoleId).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.RoleName).HasColumnName("Name").IsRequired().HasMaxLength(256);

            HasMany(x => x.Users)
                .WithMany(y => y.Roles)
                .Map(z =>
                {
                    z.MapLeftKey("RoleId");
                    z.MapRightKey("UserId");
                    z.ToTable("dbo.UserRole");
                });
        }
    }
}
