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

		public void AddNewsImage(long newsId, byte[] image)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				var news = uow.NewsRepository.GetByID(newsId);
				news.Image = image;
				uow.NewsRepository.Update(news);
				uow.Save();
			}
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
				return uow.NewsRepository.Get().Select(x => new
				{
					x.Title,
					x.Info,
					x.NewsId,
					x.CreateDate
				}).OrderByDescending(x => x.NewsId).ToList().Select(x => new NewsEntity
				{
					NewsId = x.NewsId,
					Title = x.Title,
					Info = x.Info,
					CreateDate = x.CreateDate
				}).ToList();
			}
		}

		public NewsEntity GetById(long id)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				return uow.NewsRepository.GetByID(id);
			}
		}

		public byte[] GetNewsImage(long newsId)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				var query = from newsRepo in uow.NewsRepository.Get()
							where newsRepo.NewsId == newsId
							select newsRepo.Image;
				var result = query.ToList().Distinct().SingleOrDefault();
				return result;
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
