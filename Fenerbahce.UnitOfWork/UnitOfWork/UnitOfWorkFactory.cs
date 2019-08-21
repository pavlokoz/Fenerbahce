using Fenerbahce.EF.Context;

namespace Fenerbahce.UnitOfWork.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(new FenerbahceContext());
        }
    }
}
