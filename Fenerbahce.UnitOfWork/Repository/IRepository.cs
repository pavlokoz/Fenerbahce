using System;
using System.Linq;
using System.Linq.Expressions;

namespace Fenerbahce.UnitOfWork.Repository
{
	public interface IRepository<TEntity> where TEntity : class, new()
	{
		IQueryable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "");
		TEntity GetByID(object id);
		void Insert(TEntity entity);
		void Delete(object id);
		void Delete(TEntity entityToDelete);
		void Update(TEntity entityToUpdate);
	}
}
