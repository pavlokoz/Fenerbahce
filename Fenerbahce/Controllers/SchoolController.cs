using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.Models.Mappers;
using Fenerbahce.Services.Services;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace Fenerbahce.Controllers
{
    [Authorize]
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

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var schools = schoolService.GetAll();
            var schoolsDTO = schools.Select(schoolMapper.Map).ToList();
            return Ok(schoolsDTO);
        }

        [HttpGet]
        public IHttpActionResult GetSchoolById([FromUri]long schoolId)
        {
            var school = schoolService.GetById(schoolId);
            var schoolDetailDTO = schoolDetailMapper.Map(school);

            return Ok(schoolDetailDTO);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IHttpActionResult CreateSchool([FromUri]string schoolName)
        {
            var files = HttpContext.Current.Request.Files;
            if (files.Count > 0)
            {

                var file = HttpContext.Current.Request.Files[0];
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    var school = new SchoolEntity
                    {
                        SchoolName = schoolName,
                        Logo = ms.ToArray()
                    };
                    schoolService.Create(school);
                    return Ok();
                }
            } 
            else
            {
                var school = new SchoolEntity
                {
                    SchoolName = schoolName
                };
                schoolService.Create(school);
                return Ok();
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IHttpActionResult UpdateSchool([FromUri]int schoolId, [FromUri]string schoolName)
        {
            var files = HttpContext.Current.Request.Files;
            if (files.Count > 0)
            {

                var file = HttpContext.Current.Request.Files[0];
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    var school = new SchoolEntity
                    {
                        SchoolId = schoolId,
                        SchoolName = schoolName,
                        Logo = ms.ToArray()
                    };
                    schoolService.Update(school);
                    return Ok();
                }
            }
            else
            {
                var school = new SchoolEntity
                {
                    SchoolId = schoolId,
                    SchoolName = schoolName
                };
                schoolService.Update(school);
                return Ok();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IHttpActionResult DeleteSchool([FromUri]long schoolId)
        {
            schoolService.Delete(schoolId);
            return Ok();
        }

        [HttpGet]
        public HttpResponseMessage GetSchoolImage([FromUri]long schoolId)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
            var imageBytes = schoolService.GetLogoById(schoolId);
            if (imageBytes != null)
            {
                Image myImage = Image.FromStream(new MemoryStream(this.schoolService.GetLogoById(schoolId)));

                MemoryStream memoryStream = new MemoryStream();

                myImage.Save(memoryStream, ImageFormat.Jpeg);

                httpResponseMessage.Content = new ByteArrayContent(memoryStream.ToArray());
                httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
            }

            return httpResponseMessage;
        }
    }
}
