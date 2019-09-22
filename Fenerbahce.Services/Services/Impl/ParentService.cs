using Fenerbahce.Models.EntityModels;
using Fenerbahce.UnitOfWork.UnitOfWork;

namespace Fenerbahce.Services.Services.Impl
{
	public class ParentService : IParentService
	{
		private readonly IUnitOfWorkFactory unitOfWorkFactory;

		public ParentService(IUnitOfWorkFactory unitOfWorkFactory)
		{
			this.unitOfWorkFactory = unitOfWorkFactory;
		}

		public void AddParent(StudentParentEntity studentParent)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				uow.StudentParentRepository.Insert(studentParent);
				uow.Save();
			}
		}
	}
}
