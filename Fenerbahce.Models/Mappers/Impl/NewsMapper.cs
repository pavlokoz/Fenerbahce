using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using System;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class NewsMapper : IMapper<NewsEntity, NewsDTO>
    {
        public NewsEntity Map(NewsDTO source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source can not be null");
            }

            return new NewsEntity
            {
                NewsId = source.NewsId,
                Title = source.Title,
                Info = source.Info
            };
        }

        public NewsDTO Map(NewsEntity source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source can not be null");
            }

            return new NewsDTO
            {
                NewsId = source.NewsId,
                Title = source.Title,
                Info = source.Info
            };
        }
    }
}
