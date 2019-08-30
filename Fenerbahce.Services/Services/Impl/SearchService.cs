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

        public void AddInstructor(InstructorGroupEntity entity)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                uow.InstructorGroupRepository.Insert(entity);
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

        public IList<UserEntity> Search(string searchCriteria, int roleId)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var test = from userRepo in uow.UserRepository.Get()
                           join userRoleRepo in uow.UserRoleRepository.Get()
                           on userRepo.UserId equals userRoleRepo.UserId
                           where userRoleRepo.RoleId == roleId && 
                            (userRepo.FirstName + userRepo.LastName).ToLower().Contains(searchCriteria.ToLower())
                           select userRepo;

                var users = test.ToList();

                var result = users;

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
