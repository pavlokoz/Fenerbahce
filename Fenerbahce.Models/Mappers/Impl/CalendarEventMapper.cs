using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using System;
using System.Collections.Generic;

namespace Fenerbahce.Models.Mappers.Impl
{
	public class CalendarEventMapper: IMapper<EventEntity, CalendarEventDTO>
	{
		public EventEntity Map(CalendarEventDTO source)
		{
			throw new NotImplementedException();
		}

		public CalendarEventDTO Map(EventEntity source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("Source can not be null");
			}

			return new CalendarEventDTO
			{
				EventDate = source.EventTime,
				GroupName = source.Group?.GroupName,
				Duration = source.Duration,
				EventId = source.EventId,
				GroupId = source.GroupId
			};
		}

	}
}
