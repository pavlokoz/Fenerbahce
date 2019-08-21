using System.Collections.Generic;

namespace Fenerbahce.Models.EntityModels
{
    public class SchoolEntity
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public byte[] Logo { get; set; }

        public IList<GroupEntity> Groups { get; set; }
    }
}
