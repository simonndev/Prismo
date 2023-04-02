using Prism;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prismo.Presentation.Events;
using Prismo.Presentation.Models;
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
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Home", Selectable = false},
            new NavigationItemModel { Kind = NavKind.Input, Selectable = false }
        };

        public ICommand NavigateHomeCommand { get; private set; } = new DelegateCommand(() => { });
    }
}
