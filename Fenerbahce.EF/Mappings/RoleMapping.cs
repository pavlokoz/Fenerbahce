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

            Property(x => x.RoleId).HasColumnName("RoleId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.RoleName).HasColumnName("RoleName").IsRequired().HasMaxLength(256);
        }
    }
}
