using System;
using System.Collections.Generic;
using System.Linq;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.UnitOfWork.UnitOfWork;

namespace Fenerbahce.Services.Services.Impl
{
	public class EventService : IEventService
	{
		private readonly IUnitOfWorkFactory unitOfWorkFactory;

		public EventService(IUnitOfWorkFactory unitOfWorkFactory)
		{
			this.unitOfWorkFactory = unitOfWorkFactory;
		}

		public void Create(EventEntity entity)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				uow.EventRepository.Insert(entity);
				uow.Save();
			}
		}

		public void Delete(EventEntity entity)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				uow.EventRepository.Insert(entity);
				uow.Save();
			}
		}

		public void Delete(object id)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				uow.EventRepository.Delete(id);
				uow.Save();
			}
		}

		public IList<EventEntity> GetAll()
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				return uow.EventRepository.Get().ToList();
			}
		}

		public IList<EventEntity> GetByGroupId(long groupId, short monthId, short year)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				var query = from eventRepo in uow.EventRepository.Get()
							join groupRepo in uow.GroupRepository.Get()
							on eventRepo.GroupId equals groupRepo.GroupId
							where eventRepo.EventTime.Month == monthId &&
								  eventRepo.EventTime.Year == year &&
								  groupRepo.GroupId == groupId
							select new { eventRepo, groupRepo };
				return query.ToList().Select(x => x.eventRepo).ToList();
			}
		}

		public EventEntity GetById(long id)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				return uow.EventRepository.GetByID(id);
			}
		}

		public IList<EventEntity> GetBySchoolId(long schoolId, short monthId, short year)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				var query = from eventRepo in uow.EventRepository.Get()
							join groupRepo in uow.GroupRepository.Get()
							on eventRepo.GroupId equals groupRepo.GroupId
							join schoolRepo in uow.SchoolRepository.Get()
							on groupRepo.SchoolId equals schoolRepo.SchoolId
							where eventRepo.EventTime.Month == monthId &&
								  eventRepo.EventTime.Year == year &&
								  schoolRepo.SchoolId == schoolId
							select new { eventRepo, groupRepo };
				return query.ToList().Select(x => x.eventRepo).ToList();
			}
		}

		public void InsertEvents(IEnumerable<EventEntity> events)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				foreach (EventEntity @event in events)
				{
					uow.EventRepository.Insert(@event);
				}
				uow.Save();
			}
		}

		public void Update(EventEntity entity)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				uow.EventRepository.Update(entity);
				uow.Save();
			}
		}

		public void UpdateEventDate(long eventId, DateTime eventDate)
		{
			using (var uow = unitOfWorkFactory.CreateUnitOfWork())
			{
				var @event = uow.EventRepository.GetByID(eventId);
				var eventTime = @event.EventTime;
				var time = eventTime.TimeOfDay;
				@event.EventTime = eventDate.AddSeconds(time.TotalSeconds);
				uow.EventRepository.Update(@event);
				uow.Save();
			}
		}
	}
}
