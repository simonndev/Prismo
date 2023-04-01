using Prismo.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prismo.Modules.Rx.Services
{
    public interface INavigationItemsProvider
    {
        IEnumerable<NavigationItemModel> GetNavigationItems();
    }

    public class NavigationItemsProvider : INavigationItemsProvider
    {
        public IEnumerable<NavigationItemModel> GetNavigationItems()
        {
            return new List<NavigationItemModel> {
                new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Rx Item 1" },
                new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Rx Item 2" },
                new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Rx Item 3" },
                new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Rx Item 4" },
                new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Rx Item 5" }
            };
        }
    }
}
