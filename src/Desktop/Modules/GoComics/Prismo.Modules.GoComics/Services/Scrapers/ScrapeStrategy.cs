using HtmlAgilityPack;
using System.Collections.Generic;

namespace Prismo.Modules.GoComics.Services
{
    public abstract class ScrapeStrategy<TItem>
    {
        public ScrapeStrategy(HtmlDocument document)
        {
            Document = document;
        }

        public HtmlDocument Document { get; protected set; }

        public abstract IEnumerable<TItem> Scrape();
    }
}
