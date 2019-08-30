using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using System;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class StudentMapper : IMapper<StudentEntity, StudentDTO>
    {
        public StudentEntity Map(StudentDTO source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source can not be null");
            }

            return new StudentEntity
            {
                StudentId = source.StudentId,
                FirstName = source.FirstName,
                LastName = source.LastName,
                DateOfBirth = source.DateOfBirth,
                Patrimonial = source.Patrimonial,
                GroupId = source.GroupId
            };
        }

        public StudentDTO Map(StudentEntity source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source can not be null");
            }

            return new StudentDTO
            {
                StudentId = source.StudentId,
                FirstName = source.FirstName,
                LastName = source.LastName,
                DateOfBirth = source.DateOfBirth,
                Patrimonial = source.Patrimonial,
                GroupId = source.GroupId,
                GroupName = source.Group?.GroupName
            };
        }
    }
}
