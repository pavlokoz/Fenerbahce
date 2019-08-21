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


            //Mappers
            container.RegisterType<IMapper<TestEntity, TestDTO>, TestMapper>();
        }
    }
}