namespace URL_Shortener.Entities
{
    public class ShortenedUrl
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string LongUrl { get; set; } = string.Empty;
        public string ShortUrl { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;
        public DateTime CreatedOnUtc { get; set; }

    }
}
