using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using System;

namespace Fenerbahce.Models.Mappers.Impl
{
	public class SearchUserMapper : IMapper<UserEntity, SearchUserDTO>
	{
		public UserEntity Map(SearchUserDTO source)
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
				Email = source.Email,
				DateOfBirth = source.DateOfBirth
			};
		}

		public SearchUserDTO Map(UserEntity source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("Source can not be null");
			}

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
