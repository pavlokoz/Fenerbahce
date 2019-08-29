using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class SchoolDetailMapper: IMapper<SchoolEntity, SchoolDetailDTO>
    {
        private readonly IMapper<GroupEntity, GroupDTO> groupMapper;
        public SchoolDetailMapper(IMapper<GroupEntity, GroupDTO> groupMapper)
        {
            this.groupMapper = groupMapper;
        }

        public SchoolEntity Map(SchoolDetailDTO source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source can not be null");
            }

            return new SchoolEntity
            {
                SchoolId = source.SchoolId,
                SchoolName = source.SchoolName,
                Logo = source.Logo,
                Groups = source.Groups.Select(groupMapper.Map).ToList()
            };
        }

        public SchoolDetailDTO Map(SchoolEntity source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source can not be null");
            }

            return new SchoolDetailDTO
            {
                SchoolId = source.SchoolId,
                SchoolName = source.SchoolName,
                Logo = source.Logo,
                Groups = source.Groups.Select(groupMapper.Map).ToList()
            };
        }
    }
}
