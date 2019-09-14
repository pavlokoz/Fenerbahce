using System;
using System.Collections.Generic;
using System.Linq;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.UnitOfWork.UnitOfWork;

namespace Fenerbahce.Services.Services.Impl
{
    public class VisitorLogService : IVisitorLogService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public VisitorLogService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Update(VisitorLogEntity entity)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                uow.VisitorLogRepository.Update(entity);
                uow.Save();
            }
        }

        public void Create(VisitorLogEntity entity)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                uow.VisitorLogRepository.Insert(entity);
                uow.Save();
            }
        }

        public void Delete(VisitorLogEntity entity)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                uow.VisitorLogRepository.Delete(entity);
                uow.Save();
            }
        }

        public IList<VisitorLogEntity> GetAll()
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return uow.VisitorLogRepository.Get().ToList();
            }
        }

        public VisitorLogEntity GetById(long id)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var visit = uow.VisitorLogRepository.GetByID(id);
                return visit;
            }
        }

        public IList<StudentEntity> GetVisitorLog(long groupId, DateTime date)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var studentQuery = from studRepo in uow.StudentRepository.Get()
                                   join groupRepo in uow.GroupRepository.Get()
                                   on studRepo.GroupId equals groupRepo.GroupId into groupLeft
                                   from groupRepo in groupLeft.DefaultIfEmpty()
                                   where studRepo.GroupId == groupId
                                   select new { studRepo, groupRepo };
                var students = studentQuery.ToList()
                    .Select(x => x.studRepo).ToList();
                var studentIds = students.Select(x => x.StudentId);
                var logs = uow.VisitorLogRepository.Get().Where(x => x.VisitorLogDate == date && studentIds.Contains(x.StudentId)).ToList();
                students.ForEach(x =>
                {
                    var visitLog = logs.Where(y => y.StudentId == x.StudentId).SingleOrDefault();
                    if (visitLog != null)
                    {
                        x.VisitorLogs = new List<VisitorLogEntity> { visitLog };
                    }
                });
                return students;
            }
        }

        public void UpdateState(VisitorLogEntity visitorLogEntity)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var visitorLog = uow.VisitorLogRepository.Get().Where(x => (x.StudentId == visitorLogEntity.StudentId && x.VisitorLogDate == visitorLogEntity.VisitorLogDate)).SingleOrDefault();
                if (visitorLog == null && visitorLogEntity.IsExist)
                {
                    uow.VisitorLogRepository.Insert(visitorLogEntity);
                }
                else if(!visitorLogEntity.IsExist && visitorLog != null)
                {
                    uow.VisitorLogRepository.Delete(visitorLog);
                }
                uow.Save();

            }
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
