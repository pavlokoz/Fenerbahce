using System.Collections.Generic;

namespace Fenerbahce.Models.EntityModels
{
    public class SportEntity
    {
        public long SportId { get; set; }
        public string SportName { get; set; }

        public IList<GroupEntity> Groups { get; set; }

        public IList<StudentEntity> Students { get; set; }
    }
}
