using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class GroupMapper : IMapper<GroupEntity, GroupDTO>
    {
        public GroupEntity Map(GroupDTO source)
        {
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
            return new GroupDTO
            {
                GroupId = source.GroupId,
                GroupName = source.GroupName,
                SchoolId = source.SchoolId,
                SportId = source.SportId,
                SchoolName = source.School.SchoolName,
                SportName = source.Sport.SportName
            };
        }
    }
}
