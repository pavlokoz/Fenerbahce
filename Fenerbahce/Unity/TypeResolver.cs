using Fenerbahce.Infrastructure.Config;
using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.Models.IdentityModels;
using Fenerbahce.Models.Mappers;
using Fenerbahce.Models.Mappers.Impl;
using Fenerbahce.Services.Services;
using Fenerbahce.Services.Services.Impl;
using Fenerbahce.UnitOfWork.UnitOfWork;
using Microsoft.AspNet.Identity;
using Unity;

namespace Fenerbahce.Unity
{
    public class TypeResolver
    {
        public static void Register(UnityContainer container)
        {
            container.RegisterType<IUnitOfWorkFactory, UnitOfWorkFactory>();

            //Services
            container.RegisterType<ITestService, TestService>();
            container.RegisterType<IGroupService, GroupService>();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<ISchoolService, SchoolService>();
            container.RegisterType<ISearchService, SearchService>();
            container.RegisterType<ISportService, SportService>();
            container.RegisterType<IInstructorService, InstructorService>();
            container.RegisterType<IParentService, ParentService>();

            //Mappers
            container.RegisterType<IMapper<TestEntity, TestDTO>, TestMapper>();
            container.RegisterType<IMapper<StudentEntity, StudentDTO>, StudentMapper>();
            container.RegisterType<IMapper<GroupEntity, GroupDetailDTO>, GroupDetailMapper>();
            container.RegisterType<IMapper<GroupEntity, GroupDTO>, GroupMapper>();
            container.RegisterType<IMapper<UserEntity, InstructorDTO>, InstructorMapper>();
            container.RegisterType<IMapper<ApplicationUser, RegisterOfUserBindingModel>, ApplicationUserMapper>();
            container.RegisterType<IMapper<SportEntity, SportDTO>, SportMapper>();
            container.RegisterType<IMapper<UserEntity, SearchUserDTO>, SearchUserMapper>();
            container.RegisterType<IMapper<SchoolEntity, SchoolDTO>, SchoolMapper>();
            container.RegisterType<IMapper<SchoolEntity, SchoolDetailDTO>, SchoolDetailMapper>();
            container.RegisterType<IMapper<InstructorGroupEntity, GroupInstructorDTO>, GroupInstructorMapper>();
            container.RegisterType<IMapper<UserEntity, ParentDTO>, ParentMapper>();
            container.RegisterType<IMapper<StudentParentEntity, StudentParentDTO>, StudentParentMapper>();

        
            //Identity
            container.RegisterType<ApplicationUserManager, ApplicationUserManager>();
            container.RegisterType<IUserStore<ApplicationUser, int>, UserStore>();
            container.RegisterType<ApplicationDbContext, ApplicationDbContext>();
        }
    }
}