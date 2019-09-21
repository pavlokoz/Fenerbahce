using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using System;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class UserMapper : IMapper<UserEntity, UserDTO>
    {
        public UserEntity Map(UserDTO source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source can not be null");
            }

            return new UserEntity
            {
                UserId = source.UserId,
                FirstName = source.FirstName,
                LastName = source.LastName,
                DateOfBirth = source.DateOfBirth,
                Email = source.Email
            };
        }

        public UserDTO Map(UserEntity source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source can not be null");
            }

            return new UserDTO
            {
                UserId = source.UserId,
                FirstName = source.FirstName,
                LastName = source.LastName,
                DateOfBirth = source.DateOfBirth,
                Email = source.Email
            };
        }
    }
}
