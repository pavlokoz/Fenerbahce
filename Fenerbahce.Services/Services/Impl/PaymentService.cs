using System.Collections.Generic;
using System.Linq;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.UnitOfWork.UnitOfWork;

namespace Fenerbahce.Services.Services.Impl
{
	public class PaymentService : IPaymentService
	{
		private readonly IUnitOfWorkFactory unitOfWorkFactory;

		public PaymentService(IUnitOfWorkFactory unitOfWorkFactory)
		{
			this.unitOfWorkFactory = unitOfWorkFactory;
		}

		public void Create(PaymentEntity entity)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				uow.PaymentRepository.Insert(entity);
				uow.Save();
			}
		}

		public void Delete(PaymentEntity entity)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				uow.PaymentRepository.Delete(entity);
				uow.Save();
			}
		}

		public void Delete(object id)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				uow.PaymentRepository.Delete(id);
				uow.Save();
			}
		}

		public IList<PaymentEntity> GetAll()
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				return uow.PaymentRepository.Get().ToList();
			}
		}

		public PaymentEntity GetById(long id)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				return uow.PaymentRepository.GetByID(id);
			}
		}

		public void Update(PaymentEntity entity)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				uow.PaymentRepository.Update(entity);
				uow.Save();

			}
		}
	}
}
