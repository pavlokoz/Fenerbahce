using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class InstructorMapper : IMapper<UserEntity, InstructorDTO>
    {
        public UserEntity Map(InstructorDTO source)
        {
            return new UserEntity
            {
                UserId = source.InstructorId,
                LastName = source.LastName,
                FirstName = source.FirstName,
                DateOfBirth = source.DateOfBirth,
                Email = source.Email
            };
        }

        public InstructorDTO Map(UserEntity source)
        {
            return new InstructorDTO
            {
                InstructorId = source.UserId,
                LastName = source.LastName,
                FirstName = source.FirstName,
                DateOfBirth = source.DateOfBirth,
                Email = source.Email
            };
        }
    }
}
