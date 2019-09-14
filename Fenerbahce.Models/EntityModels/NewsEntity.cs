namespace Fenerbahce.Models.EntityModels
{
    public class NewsEntity
    {
        public long NewsId { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public string Info { get; set; }

        public int AuthorId { get; set; }
        public UserEntity Author { get; set; }
    }
}
