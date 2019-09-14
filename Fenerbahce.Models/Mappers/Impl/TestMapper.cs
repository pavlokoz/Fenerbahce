using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using System;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class TestMapper : IMapper<TestEntity, TestDTO>
    {
        public TestEntity Map(TestDTO source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source can not be null");
            }

            return new TestEntity
            {
                TestId = source.TestId,
                TestName = source.TestName
            };
        }

        public TestDTO Map(TestEntity source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source can not be null");
            }

            return new TestDTO
            {
                TestId = source.TestId,
                TestName = source.TestName
            };
        }
    }
}
