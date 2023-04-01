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

        public ObservableCollection<NavigationItemModel> NavigationItems { get; private set; } = new();

        public ICommand NavigateHomeCommand { get;private set; }
    }
}
