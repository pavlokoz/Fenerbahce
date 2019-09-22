using Fenerbahce.Models.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Fenerbahce.EF.Mappings
{
	public class CommentMapping : EntityTypeConfiguration<CommentEntity>
	{
		public CommentMapping()
		{
			ToTable("dbo.Comment");
			HasKey(X => X.CommentId);

			Property(x => x.CommentId).HasColumnName("CommentId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.CommentText).HasColumnName("CommentText").IsRequired().HasMaxLength(50);
			Property(x => x.CommentDate).HasColumnName("CommentDate").IsRequired();
			Property(x => x.GroupId).HasColumnName("GroupId").IsRequired();

			HasRequired<GroupEntity>(g => g.Group)
				.WithMany(s => s.Comments)
				.HasForeignKey<long>(g => g.GroupId);
		}
	}
}
