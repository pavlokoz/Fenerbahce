using Fenerbahce.Models.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Fenerbahce.EF.Mappings
{
	class EventMapping : EntityTypeConfiguration<EventEntity>
	{
		public EventMapping()
		{
			ToTable("dbo.Event");
			HasKey(x => x.EventId);

			Property(x => x.EventId).HasColumnName("EventId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.GroupId).HasColumnName("GroupId").IsRequired();
			Property(x => x.EventTime).HasColumnName("EventTime").IsRequired();
			Property(x => x.Active).HasColumnName("Active").IsRequired();
			Property(x => x.Duration).HasColumnName("Duration").IsOptional();
			Property(x => x.AddInfo).HasColumnName("AddInfo").IsOptional();

			HasRequired(g => g.Group)
				.WithMany(s => s.Events)
				.HasForeignKey(g => g.GroupId);
		}
	}
}
