using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.DTOModels.MobileDTO;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.Models.Mappers;
using Fenerbahce.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Fenerbahce.Controllers
{
    public class MobileController : ApiController
    {
        private readonly ISportService sportService;
        private readonly IGroupService groupService;
        private readonly ICommentService commentService;
        private readonly IVisitorLogService visitorLogService;
        private readonly IMapper<SportEntity, SportDTO> sportMapper;
        private readonly IMapper<GroupEntity, GroupMobileDTO> groupMapper;
        private readonly IMapper<CommentEntity, CommentDTO> commentMapper;
        private readonly IMapper<StudentEntity, VisitorLogDTO> studentVisitMapper;
        private readonly IMapper<VisitorLogEntity, VisitorLogDTO> visitMapper;

        public MobileController(ISportService sportService,
            IMapper<SportEntity, SportDTO> sportMapper,
            IGroupService groupService,
            IMapper<GroupEntity, GroupMobileDTO> groupMapper,
            ICommentService commentService,
            IVisitorLogService visitorLogService,
            IMapper<CommentEntity, CommentDTO> commentMapper,             
            IMapper<StudentEntity, VisitorLogDTO> studentVisitMapper,
            IMapper<VisitorLogEntity, VisitorLogDTO> visitMapper)
        {
            this.sportService = sportService;
            this.sportMapper = sportMapper;
            this.groupService = groupService;
            this.groupMapper = groupMapper;
            this.commentService = commentService;
            this.visitorLogService = visitorLogService;
            this.commentMapper = commentMapper;
            this.visitMapper = visitMapper;
            this.studentVisitMapper = studentVisitMapper;
        }

        [HttpGet]
        public IHttpActionResult GetAllSports()
        {
            var sports = sportService.GetAll();
            var sportDto = sports.Select(sportMapper.Map).ToList();
            return Ok(sportDto);
        }

        [HttpGet]
        public IHttpActionResult GetGroupBySport([FromUri] long sportId)
        {
            var groups = groupService.GetBySportId(sportId);
            var groupDTO = groups.Select(groupMapper.Map).ToList();
            return Ok(groupDTO);
        }

        [HttpPost]
        public IHttpActionResult CreateGroup([FromBody] CreateGroupDTO groupDTO)
        {
            var group = new GroupEntity()
            {
                GroupId = groupDTO.GroupId,
                GroupName = groupDTO.GroupName,
                SportId = groupDTO.SportId,
                SchoolId = groupDTO.SchoolId
            };
            groupService.Create(group);
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetComments([FromUri] long groupId, [FromUri] DateTime date)
        {
            var comments = commentService.GetByGroupId(groupId, date);
            var commentsDTO = comments.Select(commentMapper.Map).ToList();
            return Ok(commentsDTO);
        }

        [HttpPost]
        public IHttpActionResult CreateComment([FromBody] CommentDTO commentDTO, [FromUri] long groupId)
        {
            var comment = commentMapper.Map(commentDTO);
            comment.GroupId = groupId;
            commentService.Create(comment);
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetVisitLogs([FromUri] long groupId, [FromUri] DateTime date)
        {
            var students = visitorLogService.GetVisitorLog(groupId, date);
            var visitLogs = students.Select(x => {
                var visitLog = studentVisitMapper.Map(x);
                visitLog.LogDate = date;
                return visitLog;
            }
            ).ToList();
            return Ok(visitLogs);
        }

        [HttpPost]
        public IHttpActionResult CreateVisitLogs([FromBody] VisitorLogContainer visitDto)
        {
            var visitLogs = visitDto.Payload?.Select(visitMapper.Map).ToList();
            visitLogs?.ForEach(x => visitorLogService.UpdateState(x));
            return Ok(visitDto);
        }
    }
}