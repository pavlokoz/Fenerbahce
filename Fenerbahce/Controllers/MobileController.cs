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
        private readonly IMapper<SportEntity, SportDTO> sportMapper;
        private readonly IMapper<GroupEntity, GroupMobileDTO> groupMapper;
        private readonly IMapper<CommentEntity, CommentDTO> commentMapper;

        public MobileController(ISportService sportService,
            IMapper<SportEntity, SportDTO> sportMapper,
            IGroupService groupService,
            IMapper<GroupEntity, GroupMobileDTO> groupMapper,
            ICommentService commentService,
            IMapper<CommentEntity, CommentDTO> commentMapper)
        {
            this.sportService = sportService;
            this.sportMapper = sportMapper;
            this.groupService = groupService;
            this.groupMapper = groupMapper;
            this.commentService = commentService;
            this.commentMapper = commentMapper;
        }

        [HttpGet]
        public IHttpActionResult GetAllSports()
        {
            var sports = sportService.GetAll();
            var sportDto = sports.Select(sportMapper.Map).ToList();
            Dictionary<string, List<SportDTO>> keyValuePairs = new Dictionary<string, List<SportDTO>>();
            keyValuePairs.Add("category_sport:", sportDto);
            return Ok(keyValuePairs);
        }

        [HttpGet]
        public IHttpActionResult GetGroupBySport([FromUri] long sportId)
        {
            var groups = groupService.GetBySportId(sportId);
            var groupDTO = groups.Select(groupMapper.Map).ToList();
            Dictionary<string, List<GroupMobileDTO>> keyValuePairs = new Dictionary<string, List<GroupMobileDTO>>();
            keyValuePairs.Add("category_group:", groupDTO);
            return Ok(keyValuePairs);
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
            Dictionary<string, List<CommentDTO>> keyValuePairs = new Dictionary<string, List<CommentDTO>>();
            keyValuePairs.Add("comment_data:", commentsDTO);
            return Ok(keyValuePairs);
        }

        [HttpPost]
        public IHttpActionResult CreateComment([FromBody] CommentDTO commentDTO, [FromUri] long groupId)
        {
            var comment = new CommentEntity()
            {
                CommentId = commentDTO.CommentId,
                CommentDate = commentDTO.CommentDate,
                CommentText = commentDTO.CommentText,
                GroupId = groupId
            };
            commentService.Create(comment);
            return Ok();
        }
    }
}