using Fenerbahce.Models.EntityModels;
using Fenerbahce.UnitOfWork.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace Fenerbahce.Services.Services.Impl
{
    public class SearchService : ISearchService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public SearchService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public IList<UserEntity> Search(string searchCriteria, int roleId)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var query = from userRepo in uow.UserRepository.Get()
                            join userRoleRepo in uow.UserRoleRepository.Get()
                            on userRepo.UserId equals userRoleRepo.UserId
                            where userRoleRepo.RoleId == roleId &&
                             (userRepo.FirstName + userRepo.LastName).ToLower().Contains(searchCriteria.ToLower())
                            select userRepo;

                var users = query.ToList();

                var startWithDictionary = new List<UserEntity>();
                var containsDictionary = new List<UserEntity>();
                foreach (var item in query)
                {
                    if ((item.LastName + item.FirstName).ToLower().StartsWith(searchCriteria.ToLower()))
                    {
                        startWithDictionary.Add(item);
                    }
                    else
                    {
                        containsDictionary.Add(item);
                    }
                }
                foreach (var item in containsDictionary)
                {
                    startWithDictionary.Add(item);
                }
                return startWithDictionary;
            }
        }
    }
}
