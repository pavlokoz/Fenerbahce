using System.Collections.Generic;

namespace Fenerbahce.Models.EntityModels
{
    public class GroupEntity
    {
        public long GroupId { get; set; }
        public string GroupName { get; set; }

        public SchoolEntity School { get; set; }
        public int SchoolId { get; set; }

        public SportEntity Sport { get; set; }
        public long SportId { get; set; }

        public IList<StudentEntity> Students { get; set; }
        public IList<InstructorGroupEntity> InstructorGroups { get; set; }
    }
}
