using Fenerbahce.Models.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Fenerbahce.EF.Mappings
{
	public class SportMapping : EntityTypeConfiguration<SportEntity>
	{
		public SportMapping()
		{
			ToTable("dbo.Sport");
			HasKey(x => x.SportId);

			Property(x => x.SportId).HasColumnName("SportId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.SportName).HasColumnName("SportName").IsRequired().HasMaxLength(50);
		}
	}
}
