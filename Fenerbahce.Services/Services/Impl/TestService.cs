using System.Collections.Generic;
using System.Linq;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.UnitOfWork.UnitOfWork;

namespace Fenerbahce.Services.Services.Impl
{
	public class TestService : ITestService
	{
		private readonly IUnitOfWorkFactory unitOfWorkFactory;

		public TestService(IUnitOfWorkFactory unitOfWorkFactory)
		{
			this.unitOfWorkFactory = unitOfWorkFactory;
		}

		public IList<TestEntity> GetAll()
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				return uow.TestRepository.Get().ToList();
			}
		}

		public void Create(TestEntity entity)
		{
			throw new System.NotImplementedException();
		}

		public void Delete(TestEntity entity)
		{
			throw new System.NotImplementedException();
		}

		public TestEntity GetById(long id)
		{
			throw new System.NotImplementedException();
		}

		public void Delete(object id)
		{
			throw new System.NotImplementedException();
		}

		public void Update(TestEntity entity)
		{
			throw new System.NotImplementedException();
		}
	}
}
