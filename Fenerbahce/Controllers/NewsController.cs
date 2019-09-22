using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.Models.Mappers;
using Fenerbahce.Services.Services;
using Microsoft.AspNet.Identity;
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
	public class NewsController : ApiController
	{
		private readonly INewsService newsService;
		private readonly IMapper<NewsEntity, NewsDTO> newsMapper;

		public NewsController(INewsService newsService,
			IMapper<NewsEntity, NewsDTO> newsMapper)
		{
			this.newsService = newsService;
			this.newsMapper = newsMapper;
		}

		[Authorize(Roles = "Admin,Instructor")]
		[HttpPost]
		public IHttpActionResult CreateNews(NewsDTO newsDTO)
		{
			var news = newsMapper.Map(newsDTO);
			news.AuthorId = this.User.Identity.GetUserId<int>();
			newsService.Create(news);
			return Ok(news.NewsId);
		}

		[Authorize(Roles = "Admin,Instructor")]
		[HttpPut]
		public IHttpActionResult UpdateNews(NewsDTO newsDTO)
		{
			var news = newsMapper.Map(newsDTO);
			news.AuthorId = this.User.Identity.GetUserId<int>();
			newsService.Update(news);
			return Ok();
		}

		[Authorize(Roles = "Admin,Instructor")]
		[HttpPut]
		public IHttpActionResult AddNewsImage([FromUri]long newsId)
		{
			var files = HttpContext.Current.Request.Files;
			var file = HttpContext.Current.Request.Files[0];
			using (MemoryStream ms = new MemoryStream())
			{
				file.InputStream.CopyTo(ms);
				newsService.AddNewsImage(newsId, ms.ToArray());
				return Ok();
			}
		}

		[Authorize(Roles = "Admin,Instructor")]
		[HttpDelete]
		public IHttpActionResult Delete(long newsId)
		{
			newsService.Delete(newsId);
			return Ok();
		}

		[HttpGet]
		public IHttpActionResult GetAllNews()
		{
			var news = newsService.GetAll();
			return Ok(news.Select(newsMapper.Map).ToList());
		}

		[HttpGet]
		public IHttpActionResult GetNewsById([FromUri]long newsId)
		{
			var news = newsService.GetById(newsId);
			return Ok(newsMapper.Map(news));
		}

		[HttpGet]
		public HttpResponseMessage GetNewsImage([FromUri]long newsId)
		{
			HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
			var imageBytes = newsService.GetNewsImage(newsId);
			if (imageBytes != null)
			{
				Image myImage = Image.FromStream(new MemoryStream(imageBytes));

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