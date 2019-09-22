using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using System;

namespace Fenerbahce.Models.Mappers.Impl
{
	public class EventMapper : IMapper<EventEntity, EventDTO>
	{
		public EventEntity Map(EventDTO source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("Source can not be null");
			}

			return new EventEntity
			{
				Active = source.Active,
				AddInfo = source.AddInfo,
				Duration = source.Duration,
				EventId = source.EventId,
				EventTime = source.EventTime,
				GroupId = source.GroupId
			};
		}

		public EventDTO Map(EventEntity source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("Source can not be null");
			}

			return new EventDTO
			{
				Active = source.Active,
				AddInfo = source.AddInfo,
				Duration = source.Duration,
				EventId = source.EventId,
				EventTime = source.EventTime,
				GroupId = source.GroupId
			};
		}
	}
}
