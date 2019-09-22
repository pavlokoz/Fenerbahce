using System;
using System.Collections.Generic;

namespace Fenerbahce.Models.EntityModels
{
	public class StudentEntity
	{
		public StudentEntity()
		{
			Payments = new List<PaymentEntity>();
			StudentParents = new List<StudentParentEntity>();
			Parents = new List<UserEntity>();
			VisitorLogs = new List<VisitorLogEntity>();
		}

		public long StudentId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string Patrimonial { get; set; }

		public GroupEntity Group { get; set; }
		public long GroupId { get; set; }

		public IList<PaymentEntity> Payments { get; set; }
		public IList<StudentParentEntity> StudentParents { get; set; }
		public IList<UserEntity> Parents { get; set; }
		public IList<VisitorLogEntity> VisitorLogs { get; set; }
	}
}
