using Prismo.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prismo.Modules.Rx.ViewModels
{
    public class NavigationViewModel
    {
        public ObservableCollection<NavigationItemModel> NavigationItems { get; private set; } = new()
        {
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "General" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Location" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Account info" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Notifications" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Contacts" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Calendar" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Email" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Tasks" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Messaging" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Background apps" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "App diagnostics" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Documents" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Pictures" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Videos" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Email" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Tasks" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Messaging" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Background apps" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "App diagnostics" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Documents" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Pictures" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Videos" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Background apps" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "App diagnostics" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Documents" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Pictures" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Videos" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Email" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Tasks" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Messaging" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Background apps" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "App diagnostics" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Documents" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Pictures" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Videos" }
        };
    }
}
