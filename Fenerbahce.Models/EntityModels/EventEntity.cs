using System;

namespace Fenerbahce.Models.EntityModels
{
	public class EventEntity: ICloneable
	{
		public long EventId { get; set; }
		public long GroupId { get; set; }
		public DateTime EventTime { get; set; }
		public bool Active { get; set; }
		public int Duration { get; set; }
		public string AddInfo { get; set; }

		public GroupEntity Group { get; set; }

		public object Clone()
		{
			return this.MemberwiseClone();
		}
	}
}
