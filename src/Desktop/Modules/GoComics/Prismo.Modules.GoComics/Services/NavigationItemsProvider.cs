using Prismo.Presentation.Models;
using System.Collections.Generic;

namespace Prismo.Modules.GoComics.Services
{
    public class NavigationItemsProvider
    {
        private static readonly  string GoComics=nameof(GoComics);

        public IList<NavigationItemModel> GetNavigationItems() {
            return new List<NavigationItemModel>()
            {
                NavigationItemModel.CreateForModule(GoComics, null, GoComics, null, NavKind.Default, NavIcons.Default),
                NavigationItemModel.CreateForModule(GoComics, "Comics", "Trending comics", null, NavKind.Default, NavIcons.Default),
                NavigationItemModel.CreateForModule(GoComics, "Comics", "Popular comics", null, NavKind.Default, NavIcons.Default),
                NavigationItemModel.CreateForModule(GoComics, "Comics", "A to Z comics by title", null, NavKind.Default, NavIcons.Default)
            };
        }
    }
}
