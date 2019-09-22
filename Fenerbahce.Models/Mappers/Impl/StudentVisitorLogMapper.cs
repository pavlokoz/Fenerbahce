﻿using Fenerbahce.Models.DTOModels.MobileDTO;
using Fenerbahce.Models.EntityModels;
using System;

namespace Fenerbahce.Models.Mappers.Impl
{
	public class StudentVisitorLogMapper : IMapper<StudentEntity, VisitorLogDTO>
	{
		public StudentEntity Map(VisitorLogDTO source)
		{
			throw new NotImplementedException();
		}

		public VisitorLogDTO Map(StudentEntity source)
		{
			return new VisitorLogDTO
			{
				StudentId = source.StudentId,
				FirstName = source.FirstName,
				LastName = source.LastName,
				GroupId = source.GroupId,
				IsExist = source.VisitorLogs.Count > 0
			};
		}
	}
}
