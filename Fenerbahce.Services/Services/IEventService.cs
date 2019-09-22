using Fenerbahce.Models.EntityModels;
using System;
using System.Collections.Generic;

namespace Fenerbahce.Services.Services
{
	public interface IEventService : IService<EventEntity>
	{
		void InsertEvents(IEnumerable<EventEntity> events);
		void UpdateEventDate(long eventId, DateTime eventDate);
		IList<EventEntity> GetBySchoolId(long schoolId, short monthId, short year);
		IList<EventEntity> GetByGroupId(long schoolId, short monthId, short year);
	}
}
