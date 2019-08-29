using System.Collections.Generic;

namespace Fenerbahce.Models.DTOModels
{
    public class SchoolDetailDTO: SchoolDTO
    {
        public IList<GroupDTO> Groups { get; set; }
    }
}
