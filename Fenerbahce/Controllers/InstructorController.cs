using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.Models.Mappers;
using Fenerbahce.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fenerbahce.Controllers
{
    [Authorize]
    public class InstructorController : ApiController
    {
        private readonly ISearchService searchService;
        private readonly IInstructorService instructorService;
        private readonly IMapper<UserEntity, InstructorDTO> instructorMapper;
        private readonly IMapper<InstructorGroupEntity, GroupInstructorDTO> groupInstructorMapper;

        public InstructorController(ISearchService searchService,
            IMapper<UserEntity, InstructorDTO> instructorMapper,
            IMapper<InstructorGroupEntity, GroupInstructorDTO> groupInstructorMapper,
            IInstructorService instructorService)
        {
            this.searchService = searchService;
            this.instructorMapper = instructorMapper;
            this.groupInstructorMapper = groupInstructorMapper;
            this.instructorService = instructorService;
        }

        [HttpGet]
        public IHttpActionResult GetInstructors()
        {
            var instructors = instructorService.GetInstructors();
            var instructorsDTO = instructors.Select(instructorMapper.Map).ToList();
            return Ok(instructorsDTO);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IHttpActionResult AddInstructor([FromBody] GroupInstructorDTO groupInstructor)
        {
            var entity = groupInstructorMapper.Map(groupInstructor);
            instructorService.AddInstructor(entity);
            return Ok();
        }
    }
}
