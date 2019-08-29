using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class SearchUserMapper : IMapper<UserEntity, SearchUserDTO>
    {
        public UserEntity Map(SearchUserDTO source)
        {
            return new UserEntity
            {
                UserId = source.UserId,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Email = source.Email,
                DateOfBirth = source.DateOfBirth
            };
        }

        public SearchUserDTO Map(UserEntity source)
        {
            return new SearchUserDTO
            {
                UserId = source.UserId,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Email = source.Email,
                DateOfBirth = source.DateOfBirth
            };
        }
    }
}
