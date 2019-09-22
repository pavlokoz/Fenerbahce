using System.Collections.Generic;
using System.Linq;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.UnitOfWork.UnitOfWork;

namespace Fenerbahce.Services.Services.Impl
{
	public class SportService : ISportService
	{
		private readonly IUnitOfWorkFactory unitOfWorkFactory;

		public SportService(IUnitOfWorkFactory unitOfWorkFactory)
		{
			this.unitOfWorkFactory = unitOfWorkFactory;
		}

		public void Create(SportEntity entity)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				uow.SportRepository.Insert(entity);
				uow.Save();
			}
		}

		public void Delete(SportEntity entity)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				uow.SportRepository.Delete(entity);
				uow.Save();
			}

		}

		public void Delete(object id)
		{
			throw new System.NotImplementedException();
		}

		public IList<SportEntity> GetAll()
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				return uow.SportRepository.Get().ToList();
			}
		}

		public SportEntity GetById(long id)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				return uow.SportRepository.GetByID(id);
			}
		}

		public void Update(SportEntity entity)
		{
			throw new System.NotImplementedException();
		}
	}
}
