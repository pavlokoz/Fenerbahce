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
    public class StudentController : ApiController
    {
        private readonly IStudentService studentService;
        private readonly IMapper<StudentEntity, StudentDTO> studentMapper;

        public StudentController(IStudentService studentService,
            IMapper<StudentEntity, StudentDTO> studentMapper)
        {
            this.studentService = studentService;
            this.studentMapper = studentMapper;
        }

        [HttpPost]
        public IHttpActionResult CreateStudent([FromBody] StudentDTO student, [FromUri] long groupId)
        {
            student.GroupId = groupId;
            var studentEntity = studentMapper.Map(student);
            studentService.Create(studentEntity);
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetStudent([FromUri] long studentId)
        {
            var studentEntity = studentService.GetById(studentId);
            var studentDTO = studentMapper.Map(studentEntity);
            return Ok(studentDTO);
        }
    }
}
