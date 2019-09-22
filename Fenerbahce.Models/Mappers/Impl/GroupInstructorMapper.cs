using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using System;

namespace Fenerbahce.Models.Mappers.Impl
{
	public class GroupInstructorMapper : IMapper<InstructorGroupEntity, GroupInstructorDTO>
	{
		private readonly IMapper<UserEntity, InstructorDTO> instructorMapper;

		public GroupInstructorMapper(IMapper<UserEntity, InstructorDTO> instructorMapper)
		{
			this.instructorMapper = instructorMapper;
		}

		public InstructorGroupEntity Map(GroupInstructorDTO source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("Source can not be null");
			}

			return new InstructorGroupEntity
			{
				GroupId = source.GroupId,
				InstructorId = source.InstructorId,
				Salary = source.Salary,
				Type = source.Type
			};
		}

		public GroupInstructorDTO Map(InstructorGroupEntity source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("Source can not be null");
			}

			return new GroupInstructorDTO
			{
				GroupId = source.GroupId,
				InstructorId = source.InstructorId,
				Salary = source.Salary,
				Type = source.Type,
				Instructor = instructorMapper.Map(source.Instructor)
			};
		}
	}
}
