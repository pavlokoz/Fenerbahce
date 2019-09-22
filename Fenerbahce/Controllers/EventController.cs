using Fenerbahce.Helpers;
using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.Models.Enums;
using Fenerbahce.Models.Mappers;
using Fenerbahce.Services.Services;
using System;
using System.Linq;
using System.Web.Http;

namespace Fenerbahce.Controllers
{
	[Authorize]
	public class EventController : ApiController
	{
		private readonly IEventService eventService;
		private readonly IMapper<EventEntity, EventDTO> eventMapper;
		private readonly IMapper<EventEntity, CalendarEventDTO> calendarEventMapper;

		public EventController(IEventService eventService,
			IMapper<EventEntity, EventDTO> eventMapper,
			IMapper<EventEntity, CalendarEventDTO> calendarEventMapper)
		{
			this.eventService = eventService;
			this.eventMapper = eventMapper;
			this.calendarEventMapper = calendarEventMapper;
		}

		[HttpGet]
		public IHttpActionResult GetSchoolEvents(long schoolId, short monthId, short year)
		{
			var events = eventService.GetBySchoolId(schoolId, monthId, year);
			var eventsDTO = events.Select(calendarEventMapper.Map);
			return Ok(eventsDTO);
		}

		[HttpGet]
		public IHttpActionResult GetGroupEvents(long groupId, short monthId, short year)
		{
			var events = eventService.GetByGroupId(groupId, monthId, year);
			var eventsDTO = events.Select(calendarEventMapper.Map);
			return Ok(eventsDTO);
		}

		[HttpGet]
		public IHttpActionResult GetEvent(long eventId)
		{
			var @event = eventService.GetById(eventId);
			var eventDTO = eventMapper.Map(@event);
			return Ok(eventDTO);
		}

		[HttpPost]
		public IHttpActionResult CreateEvent(EventDTO eventDTO, EventFrequency eventFrequency, DateTime? dueDate)
		{
			var initialEvent = eventMapper.Map(eventDTO);
			if (eventFrequency == EventFrequency.None)
			{
				eventService.Create(initialEvent);
			}
			else
			{
				eventService.InsertEvents(EventControllerHelper.GenerateEvents(initialEvent, dueDate ?? DateTime.Now, (EventEntity @event) =>
				{
					EventEntity newEvent = (@event.Clone() as EventEntity);
					newEvent.EventTime = eventFrequency == EventFrequency.Weekly ? @event.EventTime.AddDays(7) :
										 eventFrequency == EventFrequency.Monthly ? @event.EventTime.AddMonths(1) :
										 throw new ArgumentException("Unsupported Event Frequency");
					return newEvent;
				}));
			}
			return Ok();
		}

		[HttpPut]
		public IHttpActionResult UpdateEvent([FromBody]EventDTO eventDTO)
		{
			eventService.Update(eventMapper.Map(eventDTO));
			return Ok();
		}

		[HttpPut]
		public IHttpActionResult UpdateEventDate([FromUri]long eventId, [FromUri] DateTime eventDate)
		{
			eventService.UpdateEventDate(eventId, eventDate);
			return Ok();
		}

		[HttpDelete]
		public IHttpActionResult Delete(long eventId)
		{
			eventService.Delete(eventId);
			return Ok();
		}
	}
}
