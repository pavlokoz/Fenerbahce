using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.Models.Mappers;
using Fenerbahce.Models.Mappers.Impl;
using Fenerbahce.Services.Services;
using Fenerbahce.Services.Services.Impl;
using Fenerbahce.UnitOfWork.UnitOfWork;
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

            //Mappers
            container.RegisterType<IMapper<TestEntity, TestDTO>, TestMapper>();
            container.RegisterType<IMapper<StudentEntity, StudentDTO>, StudentMapper>();
            container.RegisterType<IMapper<GroupEntity, GroupDetailDTO>, GroupDetailMapper>();
            container.RegisterType<IMapper<GroupEntity, GroupDTO>, GroupMapper>();
            container.RegisterType<IMapper<UserEntity, InstructorDTO>, InstructorMapper>();
            container.RegisterType<IMapper<UserEntity, SearchUserDTO>, SearchUserMapper>();
        }
    }
}