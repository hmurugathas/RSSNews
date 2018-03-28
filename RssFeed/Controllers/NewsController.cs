using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RssFeed.Model;
using RssFeed.Services;

namespace RssFeed.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private readonly NewsService _newsFeedService;

        public NewsController(NewsService newsFeedService)
        {
            _newsFeedService = newsFeedService;
        }

        [HttpGet("BBC")]
        public async Task<IActionResult> GetBBCNews()
        {
            // could implement this for cacheing https://github.com/filipw/Strathweb.CacheOutput

            return Ok(await _newsFeedService.GetNews());
        }
    }
}
