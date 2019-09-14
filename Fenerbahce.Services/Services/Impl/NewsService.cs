using System;
using System.Collections.Generic;
using System.Linq;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.UnitOfWork.UnitOfWork;

namespace Fenerbahce.Services.Services.Impl
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public NewsService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Create(NewsEntity entity)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                uow.NewsRepository.Insert(entity);
                uow.Save();
            }
        }

        public void Delete(NewsEntity entity)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                uow.NewsRepository.Delete(entity);
                uow.Save();
            }
        }

        public void Delete(object id)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                uow.NewsRepository.Delete(id);
                uow.Save();
            }
        }

        public IList<NewsEntity> GetAll()
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return uow.NewsRepository.Get().ToList();
            }
        }

        public NewsEntity GetById(long id)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return uow.NewsRepository.GetByID(id);
            }
        }

        public void Update(NewsEntity entity)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                uow.NewsRepository.Update(entity);
                uow.Save();
            }
        }
    }
}
