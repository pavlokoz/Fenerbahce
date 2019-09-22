using System;
using System.Collections.Generic;

namespace Fenerbahce.Models.DTOModels
{
	public class StudentDTO
	{
		public long StudentId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string Patrimonial { get; set; }
		public long GroupId { get; set; }
		public string GroupName { get; set; }
		public IList<ParentDTO> Parents { get; set; }
		public IList<PaymentDTO> Payments { get; set; }
	}
}
