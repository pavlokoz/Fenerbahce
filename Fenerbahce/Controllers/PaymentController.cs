using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.Models.Mappers;
using Fenerbahce.Services.Services;
using System.Web.Http;

namespace Fenerbahce.Controllers
{
    [Authorize(Roles = "Admin,Accounter")]
    public class PaymentController : ApiController
    {
        private readonly IPaymentService paymentService;
        private readonly IMapper<PaymentEntity, PaymentDTO> paymentMapper;

        public PaymentController(IPaymentService paymentService,
            IMapper<PaymentEntity, PaymentDTO> paymentMapper)
        {
            this.paymentService = paymentService;
            this.paymentMapper = paymentMapper;
        }

        [HttpPost]
        public IHttpActionResult CreatePayment(PaymentDTO paymentDTO)
        {
            paymentService.Create(paymentMapper.Map(paymentDTO));
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdatePayment(PaymentDTO paymentDTO)
        {
            paymentService.Update(paymentMapper.Map(paymentDTO));
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(long paymentId)
        {
            paymentService.Delete(paymentId);
            return Ok();
        }
    }
}
