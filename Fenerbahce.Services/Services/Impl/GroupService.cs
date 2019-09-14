using Fenerbahce.Models.EntityModels;
using Fenerbahce.UnitOfWork.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace Fenerbahce.Services.Services.Impl
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public GroupService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Create(GroupEntity entity)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                uow.GroupRepository.Insert(entity);
                uow.Save();
            }
        }

        public void Delete(GroupEntity entity)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                uow.GroupRepository.Delete(entity);
                uow.Save();
            }
        }

        public void Delete(object id)
        {
            throw new System.NotImplementedException();
        }

        public IList<GroupEntity> GetAll()
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var query = from groupRepo in uow.GroupRepository.Get()
                            join sportRepo in uow.SportRepository.Get()
                            on groupRepo.SportId equals sportRepo.SportId
                            join schoolRepo in uow.SchoolRepository.Get()
                            on groupRepo.SchoolId equals schoolRepo.SchoolId
                            select new { groupRepo, sportRepo, schoolRepo };
                var result = query.ToList().Select(x => x.groupRepo).ToList();
                return result;
            }
        }

        public GroupEntity GetById(long id)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {

                var query = from groupRepo in uow.GroupRepository.Get()
                            join sportRepo in uow.SportRepository.Get()
                            on groupRepo.SportId equals sportRepo.SportId
                            join schoolRepo in uow.SchoolRepository.Get()
                            on groupRepo.SchoolId equals schoolRepo.SchoolId

                            join instructorGroupRepo in uow.InstructorGroupRepository.Get()
                            on groupRepo.GroupId equals instructorGroupRepo.GroupId into groupLeft
                            from instructorGroupRepo in groupLeft.DefaultIfEmpty()
                            join userRepo in uow.UserRepository.Get()
                            on instructorGroupRepo.InstructorId equals userRepo.UserId into instructorLeft
                            from userRepo in instructorLeft.DefaultIfEmpty()

                            join studentRepo in uow.StudentRepository.Get()
                            on groupRepo.GroupId equals studentRepo.GroupId into studentLeft
                            from studentRepo in studentLeft.DefaultIfEmpty()
                            where groupRepo.GroupId == id
                            select new { groupRepo, instructorGroupRepo, sportRepo, schoolRepo, userRepo, studentRepo };
                var group = query.ToList().
                    Select(x => x.groupRepo).Distinct().SingleOrDefault();
                return group;
            }
        }

        public void Update(GroupEntity entity)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                uow.GroupRepository.Update(entity);
                uow.Save();
            }
        }
    }
}
