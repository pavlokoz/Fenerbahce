using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.Models.Mappers;
using Fenerbahce.Services.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Fenerbahce.Controllers
{
    [AllowAnonymous]
    public class TestController : ApiController
    {
        private readonly ITestService testService;
        private readonly IMapper<TestEntity, TestDTO> testMapper;

        public TestController(ITestService testService, IMapper<TestEntity, TestDTO> testMapper)
        {
            this.testService = testService;
            this.testMapper = testMapper;
        }

        [Route("")]
        public IList<TestDTO> GetAll()
        {
            var result = testService.GetAll();
            return result.Select(testMapper.Map).ToList();
        }
    }
}