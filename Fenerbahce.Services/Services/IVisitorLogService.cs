using Fenerbahce.Models.EntityModels;
using System;
using System.Collections.Generic;

namespace Fenerbahce.Services.Services
{
	public interface IVisitorLogService : IService<VisitorLogEntity>
	{
		IList<StudentEntity> GetVisitorLog(long groupId, DateTime date);
		void UpdateState(VisitorLogEntity visitorLogEntity);
	}
}
