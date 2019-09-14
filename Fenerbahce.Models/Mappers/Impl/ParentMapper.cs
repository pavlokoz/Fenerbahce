using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using System;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class ParentMapper : IMapper<UserEntity, ParentDTO>
    {
        public UserEntity Map(ParentDTO source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source can not be null");
            }

            return new UserEntity
            {
                UserId = source.ParentId,
                FirstName = source.FirstName,
                LastName = source.LastName
            };
        }

        public ParentDTO Map(UserEntity source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source can not be null");
            }

            return new ParentDTO
            {
                ParentId = source.UserId,
                FirstName = source.FirstName,
                LastName = source.LastName
            };
        }
    }
}
