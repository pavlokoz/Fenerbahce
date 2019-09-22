using System;

namespace Fenerbahce.Models.DTOModels
{
	public class NewsDTO
	{
		public long NewsId { get; set; }
		public string Title { get; set; }
		public string Info { get; set; }
		public DateTime? CreateDate { get; set; }
	}
}
