using Fenerbahce.Models.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Fenerbahce.EF.Mappings
{
    public class UserMapping : EntityTypeConfiguration<UserEntity>
    {
        public UserMapping()
        {
            ToTable("dbo.User");
            HasKey(x => x.UserId);

            Property(x => x.UserId).HasColumnName("UserId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FirstName).HasColumnName("FirstName").IsRequired();
            Property(x => x.LastName).HasColumnName("LastName").IsRequired();
            Property(x => x.Email).HasColumnName("Email").IsRequired().HasMaxLength(256);
            Property(x => x.DateOfBirth).HasColumnName("DateOfBirth").IsOptional();

            HasMany(x => x.Groups)
                .WithMany(y => y.Instructors)
                .Map(z =>
                    {
                        z.MapLeftKey("InstructorId");
                        z.MapRightKey("GroupId");
                        z.ToTable("dbo.InstructorGroup");
                    });

            HasMany(e => e.Students)
                .WithMany(e => e.Parents)
                .Map(m =>
                    {
                        m.MapLeftKey("ParentId");
                        m.MapRightKey("StudentId");
                        m.ToTable("dbo.StudentParent");
                    });
        }
    }
}
