using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using System;

namespace Fenerbahce.Models.Mappers.Impl
{
	public class GroupMapper : IMapper<GroupEntity, GroupDTO>
	{
		public GroupEntity Map(GroupDTO source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("Source can not be null");
			}

			return new GroupEntity
			{
				GroupId = source.GroupId,
				GroupName = source.GroupName,
				SchoolId = source.SchoolId,
				SportId = source.SportId,
			};
		}

		public GroupDTO Map(GroupEntity source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("Source can not be null");
			}

			return new GroupDTO
			{
				GroupId = source.GroupId,
				GroupName = source.GroupName,
				SchoolId = source.SchoolId,
				SportId = source.SportId,
				SchoolName = source.School?.SchoolName,
				SportName = source.Sport?.SportName
			};
		}
	}
}
