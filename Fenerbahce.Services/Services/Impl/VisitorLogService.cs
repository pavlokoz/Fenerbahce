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

        //public IList<VisitorLogEntity> GetVisitorLog(long groupId, DateTime date)
        //{
        //    using (var uow = unitOfWorkFactory.CreateUnitOfWork())
        //    {
        //        var query = from studRepo in uow.StudentRepository.Get()
        //                    join groupRepo in uow.GroupRepository.Get()
        //                    on studRepo.GroupId equals groupRepo.GroupId into groupLeft
        //                    from groupRepo in groupLeft.DefaultIfEmpty()
        //                    join visitRepo in uow.VisitorLogRepository.Get()
        //                    on studRepo.StudentId equals visitRepo.StudentId into visitLeft
        //                    from visitRepo in visitLeft.DefaultIfEmpty()
        //                    where 
        //    }
        //}
    }
}
