using Fenerbahce.Models.IdentityModels;
using System;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class ApplicationUserMapper: IMapper<ApplicationUser, RegisterOfUserBindingModel>
    {
        public ApplicationUser Map(RegisterOfUserBindingModel source)
        {
            return new ApplicationUser()
            {
                Id = 0,
                Email = source.Email,
                LastName = source.LastName,
                DateOfBirth = source.DateOfBirth,
                FirstName = source.FirstName,
                UserName = source.Email,
                Roles = { new UserRole { RoleId = (int)source.Role } },
                EmailConfirmed = true,
                SecurityPin = source.SecurityPin
            };
        }

        public RegisterOfUserBindingModel Map(ApplicationUser source)
        {
            throw new NotImplementedException();
        }
    }
}
