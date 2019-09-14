using Fenerbahce.Models.EntityModels;
using System;
using System.Collections.Generic;

namespace Fenerbahce.Services.Services
{
    public interface IVisitorLogService: IService<VisitorLogEntity>
    {
        IList<StudentEntity> GetVisitorLog(long groupId, DateTime date);
        void Update(VisitorLogEntity entity);
        void UpdateState(VisitorLogEntity visitorLogEntity);
    }
}
