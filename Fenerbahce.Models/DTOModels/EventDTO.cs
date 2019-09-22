using System;

namespace Fenerbahce.Models.DTOModels
{
	public class EventDTO
	{
		public long EventId { get; set; }
		public long GroupId { get; set; }
		public DateTime EventTime { get; set; }
		public bool Active { get; set; }
		public int Duration { get; set; }
		public string AddInfo { get; set; }
	}
}
