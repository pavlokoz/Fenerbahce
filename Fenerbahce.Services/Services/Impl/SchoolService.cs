using Fenerbahce.Models.EntityModels;
using Fenerbahce.UnitOfWork.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace Fenerbahce.Services.Services.Impl
{
    public class SchoolService: ISchoolService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public SchoolService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Create(SchoolEntity entity)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                uow.SchoolRepository.Insert(entity);
                uow.Save();
            }
        }

        public void Delete(SchoolEntity entity)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                uow.SchoolRepository.Delete(entity);
                uow.Save();
            }
        }

        public IList<SchoolEntity> GetAll()
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var school = uow.SchoolRepository.Get().ToList();
                return school;
            }
        }

        public SchoolEntity GetById(long id)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var query = from schoolRepo in uow.SchoolRepository.Get()
                            join groupRepo in uow.GroupRepository.Get()
                            on schoolRepo.SchoolId equals groupRepo.SchoolId into groupLeft
                            from groupRepo in groupLeft.DefaultIfEmpty()
                            join sportRepo in uow.SportRepository.Get()
                            on groupRepo.SportId equals sportRepo.SportId into sportLeft
                            from sportRepo in sportLeft.DefaultIfEmpty()
                            where schoolRepo.SchoolId == id
                            select new { schoolRepo, groupRepo, sportRepo };
                var result = query.ToList().Select(x => x.schoolRepo).Distinct().SingleOrDefault();
                return result;
            }
        }

        public byte[] GetLogoById(long schoolId)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var query = from schoolRepo in uow.SchoolRepository.Get()
                            where schoolRepo.SchoolId == schoolId
                            select schoolRepo.Logo;
                var result = query.ToList().Distinct().SingleOrDefault();
                return result;
            }
        }
    }
}
