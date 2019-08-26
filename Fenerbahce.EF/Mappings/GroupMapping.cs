using Fenerbahce.Models.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Fenerbahce.EF.Mappings
{
    public class GroupMapping: EntityTypeConfiguration<GroupEntity>
    {
        public GroupMapping()
        {
            ToTable("dbo.Group");
            HasKey(x => x.GroupId);

            Property(x => x.GroupId).HasColumnName("GroupId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.GroupName).HasColumnName("GroupName").IsRequired().HasMaxLength(50);
            Property(x => x.SchoolId).HasColumnName("SchoolId").IsRequired();
            Property(x => x.SportId).HasColumnName("SportId").IsRequired();

            HasRequired<SchoolEntity>(g => g.School)
                .WithMany(s => s.Groups)
                .HasForeignKey<int>(g => g.SchoolId);

            HasRequired<SportEntity>(g => g.Sport)
                .WithMany(s => s.Groups)
                .HasForeignKey<long>(g => g.SportId);

            HasMany(x => x.Instructors)
                .WithMany(y => y.Groups)
                .Map(z =>
                {
                    z.MapLeftKey("GroupId");
                    z.MapRightKey("InstructorId");
                    z.ToTable("dbo.InstructorGroup");
                });
        }
    }
}
