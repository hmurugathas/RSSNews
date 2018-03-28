using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RssFeed.Model
{
    public class NewsItem
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Uri Link { get; set; }

        public MediaThumbnail Image { get; set; }
    }
}
