using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.Models.Mappers;
using Fenerbahce.Services.Services;
using System.Linq;
using System.Web.Http;

namespace Fenerbahce.Controllers
{
    public class SchoolController : ApiController
    {
        private readonly ISchoolService schoolService;
        private readonly IMapper<SchoolEntity, SchoolDTO> schoolMapper;
        private readonly IMapper<SchoolEntity, SchoolDetailDTO> schoolDetailMapper;

        public SchoolController(ISchoolService schoolService,
            IMapper<SchoolEntity, SchoolDTO> schoolMapper,
            IMapper<SchoolEntity, SchoolDetailDTO> schoolDetailMapper)
        {
            this.schoolService = schoolService;
            this.schoolMapper = schoolMapper;
            this.schoolDetailMapper = schoolDetailMapper;
        }

        public IHttpActionResult GetAll()
        {
            var schools = schoolService.GetAll();
            var schoolsDTO = schools.Select(schoolMapper.Map).ToList();
            return Ok(schoolsDTO);
        }

        public IHttpActionResult GetSchoolById([FromUri]long schoolId)
        {
            var school = schoolService.GetById(schoolId);
            var schoolDetailDTO = schoolDetailMapper.Map(school);

            return Ok(schoolDetailDTO);
        }

        public IHttpActionResult CreateSchool([FromBody]SchoolDTO schoolDTO)
        {
            var school = schoolMapper.Map(schoolDTO);
            schoolService.Create(school);
            return Ok();
        }
    }
}
