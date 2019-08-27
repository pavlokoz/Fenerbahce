using Fenerbahce.Models.EntityModels;
using Fenerbahce.UnitOfWork.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fenerbahce.Services.Services.Impl
{
    public class SearchService: ISearchService
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
                var query = from roleRepo in uow.RoleRepository.Get()                           
                            join userRoleRepo in uow.UserRoleRepository.Get()
                            on roleRepo.RoleId equals userRoleRepo.RoleId into roleLeft
                            from userRoleRepo in roleLeft.DefaultIfEmpty()
                            join userRepo in uow.UserRepository.Get()
                            on userRoleRepo.UserId equals userRepo.UserId into userLeft
                            from userRepo in userLeft.DefaultIfEmpty()
                            where roleRepo.RoleId == roleId
                            select new { userRepo };

                var users = query.ToList().Select(x=>x.userRepo).ToList();

                var result = users
                    .Where(x => ((x.FirstName + x.LastName).ToLower()).Contains(searchCriteria.ToLower()))
                    .ToList();
                var startWithDictionary = new List<UserEntity>();
                var containsDictionary = new List<UserEntity>();
                foreach (var item in result)
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
