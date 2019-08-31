using Fenerbahce.Models.EntityModels;
using System;
using System.Collections.Generic;

namespace Fenerbahce.Services.Services
{
    public interface ICommentService : IService<CommentEntity>
    {
        IList<CommentEntity> GetByGroupId(long groupId, DateTime date);
    }
}
