using Fenerbahce.Models.EntityModels;
using Fenerbahce.UnitOfWork.UnitOfWork;
using System;
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
                var school = uow.SchoolRepository.GetByID(id);
                return school;
            }
        }
    }
}
