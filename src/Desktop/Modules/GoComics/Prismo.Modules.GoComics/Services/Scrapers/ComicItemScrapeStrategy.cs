using HtmlAgilityPack;
using Prismo.Modules.GoComics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Prismo.Modules.GoComics.Services.Scrapers
{
    public class ComicItemScrapeStrategy : ScrapeStrategy<ComicModel>
    {
        public ComicItemScrapeStrategy(HtmlDocument document)
            : base(document)
        {
        }

        public override IEnumerable<ComicModel> Scrape()
        {
            var anchorNodes = Document.DocumentNode.Descendants("a").Where(a => a.HasClass("gc-link-anchor"));
            foreach (var anchorNode in anchorNodes)
            {
                /*
                 * <a name="r" class="gc-link-anchor"></a> <!-- anchorNode -->
                 * <h2 class="gc-type-comics">R</h2> <!-- next sibling element -->
                 * <div class="row content-section-sm"> <!-- the sibling we want -->
                 */
                var contentSectionRowNode = anchorNode.SelectSingleNode("following-sibling::*[self::div]");
                if (contentSectionRowNode != null)
                {
                    foreach (var comicNode in contentSectionRowNode.Descendants("a"))
                    {
                        string uri = comicNode.Attributes["href"].Value;

                        string avatarUrl = string.Empty;
                        var avatarNode = comicNode.Descendants("div")
                            .FirstOrDefault(n => n.HasClass("gc-avatar"));
                        if (avatarNode != null)
                        {
                            avatarUrl = avatarNode.FirstChild.Attributes["src"].Value;
                        }

                        string title = string.Empty;
                        var titleNode = comicNode.Descendants("h4")
                            .FirstOrDefault(n => n.HasClass("media-heading"));
                        if (titleNode != null)
                        {
                            title = titleNode.InnerText;
                        }

                        string subTitle = string.Empty;
                        var subTitleNode = comicNode.Descendants("span")
                            .FirstOrDefault(n => n.HasClass("media-subheading"));
                        if (subTitleNode != null)
                        {
                            subTitle = subTitleNode.InnerText;
                        }

                        yield return new ComicModel
                        {
                            Uri = uri,
                            AvatarUrl = avatarUrl,
                            Heading = title,
                            SubHeading = subTitle
                        };
                    }
                }
            }
        }
    }
}
