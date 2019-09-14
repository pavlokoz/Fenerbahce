using Fenerbahce.Models.EntityModels;
using System.Collections.Generic;

namespace Fenerbahce.Services.Services
{
    public interface IGroupService: IService<GroupEntity>
    {
        IList<GroupEntity> GetBySportId(long id);
    }
}
