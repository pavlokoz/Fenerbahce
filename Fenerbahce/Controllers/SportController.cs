using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.Models.Mappers;
using Fenerbahce.Services.Services;
using System.Linq;
using System.Web.Http;

namespace Fenerbahce.Controllers
{
	[Authorize]
	public class SportController : ApiController
	{
		private readonly IMapper<SportEntity, SportDTO> sportMapper;
		private readonly ISportService sportService;

		public SportController(IMapper<SportEntity, SportDTO> sportMapper,
			ISportService sportService)
		{
			this.sportMapper = sportMapper;
			this.sportService = sportService;
		}

		public IHttpActionResult GetAll()
		{
			var sports = sportService.GetAll();
			return Ok(sports.Select(sportMapper.Map).ToList());
		}
	}
}
