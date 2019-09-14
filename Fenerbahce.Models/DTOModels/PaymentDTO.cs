namespace Fenerbahce.Models.DTOModels
{
    public class PaymentDTO
    {
        public long PaymentId { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; }
        public long StudentId { get; set; }
    }
}
