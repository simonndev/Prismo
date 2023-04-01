using Prismo.Modules.Navigation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Prismo.Modules.Navigation.ViewModels
{
    public class NavigationBarViewModel
    {
        public NavigationBarViewModel()
        {
        }

        public ObservableCollection<NavigationItemModel> StaticItems { get; private set; } = new()
        {
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Home" },
            new NavigationItemModel { Kind = NavKind.Input }
        };

        public ObservableCollection<NavigationItemModel> NavigationItems { get; private set; } = new()
        {
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "General" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Location" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Camera" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Microphone" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Voice activation" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Account info" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Notifications" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Contacts" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Calendar" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Email" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Tasks" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Messaging" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Background apps" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "App diagnostics" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Documents" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Pictures" },
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Videos" }
        };

        public ICommand NavigateHomeCommand { get;private set; }
    }
}
