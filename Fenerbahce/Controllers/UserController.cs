using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.Models.Mappers;
using Fenerbahce.Services.Services;
using System.Linq;
using System.Web.Http;


namespace Fenerbahce.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private readonly IUserService userService;
        private readonly IMapper<UserEntity, UserDTO> mapper;

        public UserController(IUserService userService,
            IMapper<UserEntity, UserDTO> mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            var users = userService.GetAll();
            var usersDTO = users.Select(mapper.Map).ToList();
            return Ok(usersDTO);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IHttpActionResult DeleteUser([FromUri] int userId)
        {
            userService.Delete(userId);
            return Ok();
        }

    }
}