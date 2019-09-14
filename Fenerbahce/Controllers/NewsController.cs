using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.Models.Mappers;
using Fenerbahce.Services.Services;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace Fenerbahce.Controllers
{
    [Authorize(Roles = "Admin,Instructor")]
    public class NewsController: ApiController
    {
        private readonly INewsService newsService;
        private readonly IMapper<NewsEntity, NewsDTO> newsMapper;

        public NewsController(INewsService newsService,
            IMapper<NewsEntity, NewsDTO> newsMapper)
        {
            this.newsService = newsService;
            this.newsMapper = newsMapper;
        }

        [HttpPost]
        public IHttpActionResult CreateNews(NewsDTO newsDTO)
        {
            var news = newsMapper.Map(newsDTO);
            news.AuthorId = this.User.Identity.GetUserId<int>();
            newsService.Create(news);
            return Ok(news.NewsId);
        }

        [HttpPut]
        public IHttpActionResult UpdateNews(NewsDTO newsDTO)
        {
            var news = newsMapper.Map(newsDTO);
            news.AuthorId = this.User.Identity.GetUserId<int>();
            newsService.Update(news);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(long newsId)
        {
            newsService.Delete(newsId);
            return Ok();
        }
    }
}