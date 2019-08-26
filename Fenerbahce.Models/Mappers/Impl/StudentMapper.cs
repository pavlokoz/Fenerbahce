using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class StudentMapper : IMapper<StudentEntity, StudentDTO>
    {
        public StudentEntity Map(StudentDTO source)
        {
            return new StudentEntity
            {
                StudentId = source.StudentId,
                FirstName = source.FirstName,
                LastName = source.LastName,
                DateOfBirth = source.DateOfBirth,
                Patrimonial = source.Patrimonial
            };
        }

        public StudentDTO Map(StudentEntity source)
        {
            return new StudentDTO
            {
                StudentId = source.StudentId,
                FirstName = source.FirstName,
                LastName = source.LastName,
                DateOfBirth = source.DateOfBirth,
                Patrimonial = source.Patrimonial
            };
        }
    }
}
