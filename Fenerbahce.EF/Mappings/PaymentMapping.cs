using Fenerbahce.Models.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Fenerbahce.EF.Mappings
{
	public class PaymentMapping : EntityTypeConfiguration<PaymentEntity>
	{
		public PaymentMapping()
		{
			ToTable("dbo.Payment");
			HasKey(x => x.PaymentId);

			Property(x => x.PaymentId).HasColumnName("PaymentId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Type).HasColumnName("Type").IsRequired().HasMaxLength(50);
			Property(x => x.Amount).HasColumnName("Amount").IsRequired();
			Property(x => x.StudentId).HasColumnName("StudentId").IsRequired();

			HasRequired<StudentEntity>(g => g.Student)
				.WithMany(s => s.Payments)
				.HasForeignKey<long>(g => g.StudentId);
		}
	}
}
