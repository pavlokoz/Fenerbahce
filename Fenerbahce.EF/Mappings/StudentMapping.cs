using Fenerbahce.Models.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Fenerbahce.EF.Mappings
{
    public class StudentMapping: EntityTypeConfiguration<StudentEntity>
    {
        public StudentMapping()
        {
            ToTable("dbo.Student");
            HasKey(x => x.StudentId);

            Property(x => x.StudentId).HasColumnName("GroupId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(50);
            Property(x => x.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(50);
            Property(x => x.DateOfBirth).HasColumnName("DateOfBirth").IsRequired();
            Property(x => x.Patrimonial).HasColumnName("Patrimonial").IsRequired().HasMaxLength(50);
            Property(x => x.SportId).HasColumnName("SportId").IsRequired();
            Property(x => x.GroupId).HasColumnName("GroupId").IsRequired();

            HasRequired<GroupEntity>(g => g.Group)
                .WithMany(s => s.Students)
                .HasForeignKey<long>(g => g.GroupId);

            HasRequired<SportEntity>(g => g.Sport)
                .WithMany(s => s.Students)
                .HasForeignKey<long>(g => g.SportId);
        }
    }
}
