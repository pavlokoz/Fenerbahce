using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.Models.Mappers;
using Fenerbahce.Services.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Fenerbahce.Controllers
{
	[Authorize]
	public class GroupController : ApiController
	{
		private readonly IGroupService groupService;
		private readonly IMapper<GroupEntity, GroupDetailDTO> groupDetailMapper;
		private readonly IMapper<GroupEntity, GroupDTO> groupMapper;
		private readonly IMapper<UserEntity, SearchUserDTO> searchMapper;
		private readonly ISearchService searchService;

		public GroupController(IGroupService groupService,
			IMapper<GroupEntity, GroupDetailDTO> groupDetailMapper,
			IMapper<GroupEntity, GroupDTO> groupMapper,
			ISearchService searchService,
			IMapper<UserEntity, SearchUserDTO> searchMapper)
		{
			this.groupService = groupService;
			this.groupDetailMapper = groupDetailMapper;
			this.groupMapper = groupMapper;
			this.searchService = searchService;
			this.searchMapper = searchMapper;
		}

		[HttpGet]
		public IHttpActionResult Search([FromUri]string searchCriteria, [FromUri]int roleId)
		{
			var users = searchService.Search(searchCriteria, roleId).ToList();
			var searchDto = users.Select(searchMapper.Map).ToList();
			return Ok(searchDto);
		}

		[HttpGet]
		public IHttpActionResult GetGroupById([FromUri]long groupId)
		{
			var group = groupService.GetById(groupId);
			var groupDetailDTO = groupDetailMapper.Map(group);

			return Ok(groupDetailDTO);
		}

		[HttpGet]
		public IHttpActionResult GetAllGroups()
		{
			var groups = groupService.GetAll();
			var groupsDTO = groups.Select(groupMapper.Map).ToList();
			return Ok(groupsDTO);
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public IHttpActionResult CreateGroup([FromBody]GroupDTO groupDTO)
		{
			var group = groupMapper.Map(groupDTO);
			groupService.Create(group);
			return Ok();
		}

		[Authorize(Roles = "Admin")]
		[HttpDelete]
		public IHttpActionResult DeleteGroup([FromUri]long groupId)
		{
			groupService.Delete(groupId);
			return Ok();
		}

		[Authorize(Roles = "Admin")]
		[HttpPut]
		public IHttpActionResult UpdateGroup([FromBody]GroupDTO groupDTO)
		{
			var group = groupMapper.Map(groupDTO);
			groupService.Update(group);
			return Ok();
		}
	}
}