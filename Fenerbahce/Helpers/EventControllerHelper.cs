using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fenerbahce.Helpers
{
	internal static class EventControllerHelper
	{
		public static IEnumerable<EventEntity> GenerateEvents(EventEntity @event, DateTime dueDate, Func<EventEntity, EventEntity> func)
		{
			DateTime lastEventTime = @event.EventTime;
			yield return @event;
			EventEntity nextEvent =@event;
			while (lastEventTime.Date <= dueDate.Date)
			{				
				nextEvent = func(nextEvent);
				lastEventTime = nextEvent.EventTime;
				yield return nextEvent;
			}
		}
	}
}