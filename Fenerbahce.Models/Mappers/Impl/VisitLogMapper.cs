using Fenerbahce.Models.DTOModels.MobileDTO;
using Fenerbahce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class VisitLogMapper : IMapper<VisitorLogEntity, VisitorLogDTO>
    {
        public VisitorLogDTO Map(VisitorLogEntity source)
        {
            throw new NotImplementedException();
        }

        public VisitorLogEntity Map(VisitorLogDTO source)
        {
            return new VisitorLogEntity
            {
                StudentId = source.StudentId,
                VisitorLogDate = source.LogDate,
                IsExist = source.IsExist
            };
        }
    }
}
