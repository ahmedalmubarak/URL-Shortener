using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using URL_Shortener.ApplicationDbContexts;
using URL_Shortener.Entities;
using URL_Shortener.Models;
using URL_Shortener.Services;

namespace URL_Shortener.Controllers
{
    [ApiController]
    [Route("api")]
    public class Shorten : Controller
    {
        private readonly UrlShorteningService _service;
        private readonly ApplicationDbContext _dbContext;

        public Shorten(UrlShorteningService service, ApplicationDbContext context)
        {
            _service = service;
            _dbContext = context;
        }
        /// <summary>
        /// A method convert long URL to short one.
        /// </summary>
        /// <param name="request">Take the long URL</param>
        /// <returns></returns>
        [HttpPost("shorten")]
        public async Task<IActionResult> ShortenAsync(ShortenerUrlRequest request)
        {
            if (!Uri.TryCreate(request.Url, UriKind.Absolute, out _))
            {
                return BadRequest("The specifed URL is invalid.");
            }

            var code = await _service.GenerateUniqCode();
            var shortenedUrl = new ShortenedUrl
            {
                id = Guid.NewGuid(),
                LongUrl = request.Url,
                Code = code,
                ShortUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/api/{code}",
                CreatedOnUtc = DateTime.UtcNow,
            };
            await _dbContext.ShortenedUrls.AddAsync(shortenedUrl);
            await _dbContext.SaveChangesAsync();
            return Ok(shortenedUrl.ShortUrl);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult> RedirectLink(string code)
        {
            var shortenedUrl = await _dbContext.ShortenedUrls.FirstOrDefaultAsync(s => s.Code == code);
            if (shortenedUrl == null)
            {
                return NotFound();
            }
            return Redirect(shortenedUrl.LongUrl);
        }
    }
}
