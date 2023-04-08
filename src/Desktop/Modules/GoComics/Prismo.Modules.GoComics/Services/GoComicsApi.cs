using HtmlAgilityPack;
using Prismo.Modules.GoComics.Models;
using Prismo.Modules.GoComics.Services.Scrapers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Prismo.Modules.GoComics.Services
{
    public static class GoComicsUris
    {
        public static readonly string AllComics="comics/a-to-z";
    }

    public class GoComicsApi
    {
        private readonly HttpClient _httpClient;

        public GoComicsApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<ComicModel>> GetAllComics()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, GoComicsUris.AllComics);
            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(GoComicsUris.AllComics);
            }

            using Stream responseStream = await response.Content.ReadAsStreamAsync();
            
            HtmlDocument document = new HtmlDocument();
            document.Load(responseStream);

            var strategy = new ComicItemScrapeStrategy(document);

            return strategy.Scrape();
        }
    }
}
