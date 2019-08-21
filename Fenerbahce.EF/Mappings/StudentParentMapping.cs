using Fenerbahce.Models.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Fenerbahce.EF.Mappings
{
    public class StudentParentMapping : EntityTypeConfiguration<StudentParentEntity>
    {
        public StudentParentMapping()
        {
            ToTable("dbo.StudentParent");
            HasKey(x => new { x.StudentId, x.ParentId });

            Property(x => x.ParentId).HasColumnName("ParentId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.StudentId).HasColumnName("StudentId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //Do not forget add foreign key!!

            //HasRequired(x => x.User).WithMany(y => y.StudentParent).HasForeignKey(z => z.UserId);
            //HasRequired(x => x.Student).WithMany(y => y.StudentParent).HasForeignKey(z => z.StudentId);
        }
    }
}
