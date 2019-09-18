using Fenerbahce.Models.DTOModels.MobileDTO;
using Fenerbahce.Models.EntityModels;
using System;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class CommentMapper : IMapper<CommentEntity, CommentDTO>
    {
        public CommentEntity Map(CommentDTO source)
        {
            return new CommentEntity
            {
                CommentId = source.CommentId,
                CommentText = source.CommentText,
                CommentDate = source.CommentDate ?? DateTime.Now.Date
            };
        }

        public CommentDTO Map(CommentEntity source)
        {
            return new CommentDTO
            {
                CommentId = source.CommentId,
                CommentText = source.CommentText,
                CommentDate = source.CommentDate
            };
        }
    }
}
