using Fenerbahce.Models.EntityModels;
using System.Collections.Generic;

namespace Fenerbahce.Services.Services
{
    public interface ISearchService
    {
        IList<UserEntity> Search(string searchCriteria, int roleId);

        IList<UserEntity> GetInstructors();

        void AddInstructor(InstructorGroupEntity entity);
    }
}
