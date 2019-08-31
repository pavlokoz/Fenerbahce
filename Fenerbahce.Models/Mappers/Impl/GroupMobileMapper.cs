using Fenerbahce.Models.DTOModels.MobileDTO;
using Fenerbahce.Models.EntityModels;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class GroupMobileMapper : IMapper<GroupEntity, GroupMobileDTO>
    {
        public GroupEntity Map(GroupMobileDTO source)
        {
            return new GroupEntity
            {
                GroupId = source.GroupId,
                GroupName = source.GroupName,
                SportId = source.SportId
            };
        }

        public GroupMobileDTO Map(GroupEntity source)
        {
            return new GroupMobileDTO
            {
                GroupId = source.GroupId,
                GroupName = source.GroupName,
                SportId = source.SportId
            };
        }
    }
}
