using Fenerbahce.Models.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Fenerbahce.EF.Mappings
{
    public class SchoolMapping : EntityTypeConfiguration<SchoolEntity>
    {
        public SchoolMapping()
        {
            ToTable("dbo.School");
            HasKey(x => x.SchoolId);

            Property(x => x.SchoolId).HasColumnName("SchoolId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.SchoolName).HasColumnName("SchoolName").IsRequired().HasMaxLength(50);
            Property(x => x.Logo).HasColumnName("Logo").IsRequired();
        }
    }
}
