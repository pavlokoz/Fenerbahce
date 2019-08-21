using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class TestMapper : IMapper<TestEntity, TestDTO>
    {
        public TestEntity Map(TestDTO source)
        {
            return new TestEntity
            {
                TestId = source.TestId,
                TestName = source.TestName
            };
        }

        public TestDTO Map(TestEntity source)
        {
            return new TestDTO
            {
                TestId = source.TestId,
                TestName = source.TestName
            };
        }
    }
}
