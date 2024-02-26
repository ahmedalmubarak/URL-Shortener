
using Microsoft.EntityFrameworkCore;
using URL_Shortener.ApplicationDbContexts;

namespace URL_Shortener.Services
{
    public class UrlShorteningService
    {
        public const int _numberOfCharInShortLink = 7;
        private const string _alphabit = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private readonly Random _random = new();
        private readonly ApplicationDbContext _dbCOntext;

        public UrlShorteningService(ApplicationDbContext dbCOntext)
        {
            _dbCOntext = dbCOntext;
        }

        public async Task<string> GenerateUniqCode()
        {
            var codeChars = new char[_numberOfCharInShortLink];
            while (true)
            {
                for (int i = 0; i < _numberOfCharInShortLink; i++)
                {
                    var randomIndex = _random.Next(_alphabit.Length - 1);

                    codeChars[i] = _alphabit[randomIndex];
                }
                var code = new string(codeChars);
                if (!await _dbCOntext.ShortenedUrls.AnyAsync(s => s.Code == code))
                {
                    return code;
                }
            }
        }
    }
}
