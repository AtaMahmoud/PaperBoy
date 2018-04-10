using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PaperBoy.Models;
using PaperBoy.Models.News;
using PaperBoy.Models.Trending;

namespace PaperBoy.Helpers
{
    public static class NewsHelper
    {
        public async static Task<List<NewsInformation>>GetTrendingAsync()
        {
            var results = new List<NewsInformation>();

            var searchUrl = $"https://api.cognitive.microsoft.com/bing/v7.0/news/trendingtopics?cc=US";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Common.CoreConstants.NewsSearchApiKey);

            var uri = new Uri(searchUrl);
            var result = await client.GetStringAsync(uri);
            var newsResult = JsonConvert.DeserializeObject<TrendingNewsResult>(result);

            results = (from item in newsResult.value
                       select new NewsInformation()
                       {
                           Title = item.name,
                           Description=item.query.text,
                           CreatedDate=DateTime.Now,
                           ImageUrl=item.image.url,
                       }).ToList();

            return results.Where(w => !string.IsNullOrWhiteSpace(w.ImageUrl)).Take(10).ToList();
           
        }
    }
}
