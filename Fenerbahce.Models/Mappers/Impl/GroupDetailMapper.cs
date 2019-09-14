using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using System;
using System.Linq;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class GroupDetailMapper : IMapper<GroupEntity, GroupDetailDTO>
    {
        private readonly IMapper<StudentEntity, StudentDTO> studentMapper;
        private readonly IMapper<UserEntity, InstructorDTO> instructorMapper;

        public GroupDetailMapper(IMapper<StudentEntity, StudentDTO> studentMapper,
            IMapper<UserEntity, InstructorDTO> instructorMapper)
        {
            this.studentMapper = studentMapper;
            this.instructorMapper = instructorMapper;
        }

        public GroupEntity Map(GroupDetailDTO source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source can not be null");
            }

            return new GroupEntity
            {
                GroupId = source.GroupId,
                GroupName = source.GroupName,
                SchoolId = source.SchoolId,
                SportId = source.SportId,
                Students = source.Students.Select(studentMapper.Map).ToList(),
                Instructors = source.Instructors.Select(instructorMapper.Map).ToList()
            };
        }

        public GroupDetailDTO Map(GroupEntity source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source can not be null");
            }

            return new GroupDetailDTO
            {
                GroupId = source.GroupId,
                GroupName = source.GroupName,
                SchoolId = source.SchoolId,
                SportId = source.SportId,
                SchoolName = source.School.SchoolName,
                SportName = source.Sport.SportName,
                Students = source.Students.Select(studentMapper.Map).ToList(),
                Instructors = source.Instructors.Select(instructorMapper.Map).ToList()
            };
        }
    }
}
