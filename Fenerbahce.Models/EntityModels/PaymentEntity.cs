namespace Fenerbahce.Models.EntityModels
{
	public class PaymentEntity
	{
		public long PaymentId { get; set; }
		public int Amount { get; set; }
		public string Type { get; set; }

		public long StudentId { get; set; }
		public StudentEntity Student { get; set; }
	}
}
