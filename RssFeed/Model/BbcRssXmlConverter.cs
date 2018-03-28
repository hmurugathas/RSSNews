using RssFeed.Model.BBCSchema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace RssFeed.Model
{
    public class BbcRssXmlConverter
    {
        public BbcRssXmlConverter()
        {
            
        }

        public List<NewsItem> GetNewsItems(Stream news)
        {
            if (news == null)
            {
                throw new ArgumentNullException(nameof(news));
            }

            var newsItems = new List<NewsItem>();

            try
            {
                using (news)
                {
                    var rssXmlContent = new XmlDocument();
                    rssXmlContent.Load(news);

                    var nodes = rssXmlContent.SelectNodes("rss/channel/item");

                    foreach (XmlNode node in nodes)
                    {
                        newsItems.Add(new NewsItem
                        {
                            Title = node[NewsItemXmlSchema.Title].InnerText,
                            Description = node[NewsItemXmlSchema.Description].InnerText,
                            Link = new Uri(node[NewsItemXmlSchema.Link].InnerText),
                            Image = new MediaThumbnail
                            {
                                Height = int.Parse(node[NewsItemXmlSchema.Thumbnail].Attributes[MediaThumbnailXmlSchema.Height].InnerText),
                                Width = int.Parse(node[NewsItemXmlSchema.Thumbnail].Attributes[MediaThumbnailXmlSchema.Width].InnerText),
                                Url = new Uri(node[NewsItemXmlSchema.Thumbnail].Attributes[MediaThumbnailXmlSchema.Url].InnerText)
                            }
                        });
                    }
                }
            }
            catch (Exception)
            {
                // log
            }

            return newsItems;
        }
    }
}
