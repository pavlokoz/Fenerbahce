using Fenerbahce.Models.EntityModels;
using Fenerbahce.UnitOfWork.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace Fenerbahce.Services.Services.Impl
{
	public class InstructorService : IInstructorService
	{
		private readonly IUnitOfWorkFactory unitOfWorkFactory;

		public InstructorService(IUnitOfWorkFactory unitOfWorkFactory)
		{
			this.unitOfWorkFactory = unitOfWorkFactory;
		}

		public void AddInstructor(InstructorGroupEntity entity)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				uow.InstructorGroupRepository.Insert(entity);
				uow.Save();
			}
		}

		public void Delete(object id)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				uow.InstructorGroupRepository.Delete(id);
				uow.Save();
			}
		}

		public void DeleteInstructor(InstructorGroupEntity instrGroup)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				uow.InstructorGroupRepository.Delete(instrGroup);
				uow.Save();
			}
		}

		public IList<UserEntity> GetInstructors()
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				var query = from userRepo in uow.UserRepository.Get()
							join userRoleRepo in uow.UserRoleRepository.Get()
							on userRepo.UserId equals userRoleRepo.UserId
							where userRoleRepo.RoleId == 3
							select userRepo;

				var users = query.ToList();
				return users;
			}
		}

		public void Update(InstructorGroupEntity instructorGroupEntity)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				uow.InstructorGroupRepository.Update(instructorGroupEntity);
				uow.Save();
			}
		}
	}
}
