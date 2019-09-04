using Fenerbahce.Models.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Fenerbahce.EF.Mappings
{
    public class VisitorLogMapping : EntityTypeConfiguration<VisitorLogEntity>
    {
        public VisitorLogMapping()
        {
            ToTable("dbo.VisitorLog");
            HasKey(x => new { x.StudentId, x.VisitorLogDate });

            Property(x => x.StudentId).HasColumnName("StudentId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.VisitorLogDate).HasColumnName("VisitorLogDate").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Ignore(x => x.IsExist);
            HasRequired<StudentEntity>(g => g.Student)
                .WithMany(s => s.VisitorLogs)
                .HasForeignKey<long>(g => g.StudentId);
        }
    }
}
