using Prism.Regions;
using Prismo.Presentation.Models;
using System.Collections.ObjectModel;

namespace Prismo.Modules.Rx.ViewModels
{
    public class StaticNavigationViewModel
    {
        public StaticNavigationViewModel(IRegionManager regionManager)
        {
            
        }

        public ObservableCollection<NavigationItemModel> NavigationItems { get; private set; } = new()
        {
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "General", ModuleName = "A" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Location", ModuleName = "A" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Account info", ModuleName = "A" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Notifications", ModuleName = "A" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Contacts", ModuleName = "A" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Calendar", ModuleName = "A" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Email", ModuleName = "A" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Tasks", ModuleName = "B" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Messaging", ModuleName = "B" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Background apps", ModuleName = "B" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "App diagnostics", ModuleName = "B" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Documents", ModuleName = "B" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Pictures", ModuleName = "B" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Videos", ModuleName = "B" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Email", ModuleName = "B" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Tasks", ModuleName = "C" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Messaging", ModuleName = "C" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Background apps", ModuleName = "C" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "App diagnostics", ModuleName = "C" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Documents", ModuleName = "C" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Pictures", ModuleName = "C" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Videos", ModuleName = "C" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Background apps", ModuleName = "D" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "App diagnostics", ModuleName = "D" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Documents", ModuleName = "D" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Pictures", ModuleName = "D" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Videos", ModuleName = "D" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Email", ModuleName = "D" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Tasks", ModuleName = "D" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Messaging", ModuleName = "E" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Background apps", ModuleName = "E" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "App diagnostics", ModuleName = "E" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Documents", ModuleName = "E" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Pictures", ModuleName = "E" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Selectable = true, Heading = "Videos", ModuleName = "E" }
        };
    }
}
