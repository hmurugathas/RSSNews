using RssFeed.Model;
using RssFeed.Model.BBCSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace RssFeed.Services
{
    public class NewsService
    {
        private readonly Uri _source;
        private readonly BbcRssXmlConverter _bbcRssXmlConverter;

        public NewsService(Uri source, BbcRssXmlConverter bbcRssXmlConverter)
        {
            _source = source;
            _bbcRssXmlConverter = bbcRssXmlConverter;
        }

        public async Task<List<NewsItem>> GetNews()
        {
            var newsItems = new List<NewsItem>();

            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(_source);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    newsItems = _bbcRssXmlConverter.GetNewsItems(await response.Content.ReadAsStreamAsync());
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
