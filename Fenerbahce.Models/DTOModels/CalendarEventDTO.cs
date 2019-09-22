using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenerbahce.Models.DTOModels
{
	public class CalendarEventDTO
	{
		public long EventId { get; set; }
		public long GroupId { get; set; }
		public string GroupName { get; set; }
		public DateTime EventDate { get; set; }
		public int Duration { get; set; }
	}
}
