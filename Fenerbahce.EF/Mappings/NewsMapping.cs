using Fenerbahce.Models.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Fenerbahce.EF.Mappings
{
    public class NewsMapping : EntityTypeConfiguration<NewsEntity>
    {
        public NewsMapping()
        {
            ToTable("dbo.News");
            HasKey(x => x.NewsId);

            Property(x => x.NewsId).HasColumnName("NewsId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title).HasColumnName("Title").IsRequired().HasMaxLength(255);
            Property(x => x.Image).HasColumnName("Image").IsOptional();
            Property(x => x.Info).HasColumnName("Info").IsOptional();
            Property(x => x.CreateDate).HasColumnName("CreateDate").IsRequired();
            Property(x => x.AuthorId).HasColumnName("AuthorId").IsRequired();

            HasRequired<UserEntity>(g => g.Author)
                .WithMany(s => s.News)
                .HasForeignKey<long>(g => g.AuthorId);
        }
    }
}
