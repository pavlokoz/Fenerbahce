using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenerbahce.Models.Mappers.Impl
{
	public class StudentParentMapper : IMapper<StudentParentEntity, StudentParentDTO>
	{
		public StudentParentEntity Map(StudentParentDTO source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("Source can not be null");
			}

			return new StudentParentEntity
			{
				StudentId = source.StudentId,
				ParentId = source.ParentId
			};
		}

		public StudentParentDTO Map(StudentParentEntity source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("Source can not be null");
			}

			return new StudentParentDTO
			{
				StudentId = source.StudentId,
				ParentId = source.ParentId
			};
		}
	}
}
