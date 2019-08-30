using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class ParentMapper : IMapper<UserEntity, ParentDTO>
    {
        public UserEntity Map(ParentDTO source)
        {
            return new UserEntity
            {
                UserId = source.ParentId,
                FirstName = source.FirstName,
                LastName = source.LastName
            };
        }

        public ParentDTO Map(UserEntity source)
        {
            return new ParentDTO
            {
                ParentId = source.UserId,
                FirstName = source.FirstName,
                LastName = source.LastName
            };
        }
    }
}
