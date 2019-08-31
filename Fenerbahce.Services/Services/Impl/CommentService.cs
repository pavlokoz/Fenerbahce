using Fenerbahce.Models.EntityModels;
using Fenerbahce.UnitOfWork.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenerbahce.Services.Services.Impl
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public CommentService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Create(CommentEntity entity)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                uow.CommentRepository.Insert(entity);
                uow.Save();
            }
        }

        public void Delete(CommentEntity entity)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                if (entity.CommentText.Length == 0 || entity.CommentDate.ToString().Length == 0)
                {
                    throw new Exception("Error command is not request");
                }
                uow.CommentRepository.Delete(entity);
                uow.Save();
            }
        }

        public IList<CommentEntity> GetAll()
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return uow.CommentRepository.Get().ToList();
            }
        }

        public IList<CommentEntity> GetByGroupId(long groupId, DateTime date)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var comments = uow.CommentRepository.Get()
                    .Where(x => x.GroupId == groupId && x.CommentDate == date).ToList();
                return comments;
            }
        }

        public CommentEntity GetById(long id)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var comment = uow.CommentRepository.GetByID(id);
                return comment;
            }
        }
    }
}
