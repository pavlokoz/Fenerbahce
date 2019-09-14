using Fenerbahce.Models.EntityModels;

namespace Fenerbahce.Services.Services
{
    public interface INewsService : IService<NewsEntity>
    {
        void AddNewsImage(long newsId, byte[] image);
        byte[] GetNewsImage(long newsId);
    }
}
