using Fenerbahce.Models.EntityModels;
using System.Collections.Generic;

namespace Fenerbahce.Services.Services
{
    public interface IStudentService: IService<StudentEntity>
    {
        IList<StudentEntity> Search(string text);
        void CreateStudent(StudentEntity student, int parentId);
    }
}
