using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.Models.Mappers;
using Fenerbahce.Services.Services;
using System.Web.Http;

namespace Fenerbahce.Controllers
{
    [Authorize]
    public class ParentController : ApiController
    {
        private readonly IParentService parentService;
        private readonly IMapper<StudentParentEntity, StudentParentDTO> studentParentMapper;

        public ParentController(IParentService parentService,
            IMapper<StudentParentEntity, StudentParentDTO> studentParentMapper)
        {
            this.studentParentMapper = studentParentMapper;
            this.parentService = parentService;
        }

        [Authorize(Roles = "Admin")]
        public IHttpActionResult AddParent(StudentParentDTO studentParent)
        {
            var studentParentEntity = studentParentMapper.Map(studentParent);
            parentService.AddParent(studentParentEntity);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IHttpActionResult DeleteParent([FromUri]int parentId, [FromUri]long studentId)
        {
            var studentParentEntity = new StudentParentEntity
            {
                ParentId = parentId,
                StudentId = studentId
            };
            parentService.Delete(studentParentEntity);
            return Ok();
        }
    }
}
