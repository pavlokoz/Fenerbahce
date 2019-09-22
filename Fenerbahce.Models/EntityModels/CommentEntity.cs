using System;

namespace Fenerbahce.Models.EntityModels
{
	public class CommentEntity
	{
		public long CommentId { get; set; }
		public string CommentText { get; set; }
		public DateTime? CommentDate { get; set; }
		public GroupEntity Group { get; set; }
		public long GroupId { get; set; }
	}
}
