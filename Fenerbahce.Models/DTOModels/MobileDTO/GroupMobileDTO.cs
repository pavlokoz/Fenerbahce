namespace Fenerbahce.Models.DTOModels.MobileDTO
{
    public class GroupMobileDTO
    {
        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public long SportId { get; set; }
    }

    public class CreateGroupDTO
    {
        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public long SportId { get; set; }
        public int SchoolId { get; set; }
    }
}
