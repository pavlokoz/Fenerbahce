using System.Collections.Generic;
using System.Linq;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.UnitOfWork.UnitOfWork;

namespace Fenerbahce.Services.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public UserService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Delete(object id)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                uow.UserRepository.Delete(id);
                uow.Save();
            }
        }

        public List<UserEntity> GetAll()
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var query = from userRepo in uow.UserRepository.Get()
                            join userRoleRepo in uow.UserRoleRepository.Get()
                            on userRepo.UserId equals userRoleRepo.UserId
                            where userRoleRepo.RoleId != 1
                            select userRepo;

                var users = query.ToList();
                return users;
            }
        }
    }
}
