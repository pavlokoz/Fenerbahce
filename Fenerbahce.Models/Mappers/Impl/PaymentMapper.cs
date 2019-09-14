using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using System;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class PaymentMapper : IMapper<PaymentEntity, PaymentDTO>
    {
        public PaymentEntity Map(PaymentDTO source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source can not be null");
            }

            return new PaymentEntity
            {
                PaymentId = source.PaymentId,
                StudentId = source.StudentId,
                Amount = source.Amount,
                Type = source.Type
            };
        }

        public PaymentDTO Map(PaymentEntity source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source can not be null");
            }

            return new PaymentDTO
            {
                PaymentId = source.PaymentId,
                StudentId = source.StudentId,
                Amount = source.Amount,
                Type = source.Type
            };
        }
    }
}
