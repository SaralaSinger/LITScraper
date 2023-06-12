using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scraper.Data;

namespace Scraper.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperController : ControllerBase
    {
        [HttpGet]
        [Route("scrape")]
        public List<LITItem> Scrape()
        {
            return Scraper.Data.LITScraper.Scrape();
        }
    }
}
