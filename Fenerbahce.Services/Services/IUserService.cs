using Fenerbahce.Models.EntityModels;
using System.Collections.Generic;

namespace Fenerbahce.Services.Services
{
    public interface IUserService
    {
        List<UserEntity> GetAll();
        void Delete(object id);
    }
}
