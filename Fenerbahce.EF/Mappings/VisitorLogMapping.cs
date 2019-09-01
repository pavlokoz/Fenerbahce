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
            HasKey(X => X.VisitorLogId);

            Property(x => x.VisitorLogId).HasColumnName("VisitorLogId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.VisitorLogDate).HasColumnName("VisitorLogDate").IsRequired();
            Property(x => x.StudentId).HasColumnName("StudentId").IsRequired();

            HasRequired<StudentEntity>(g => g.Student)
                .WithMany(s => s.VisitorLogs)
                .HasForeignKey<long>(g => g.StudentId);
        }
    }
}
