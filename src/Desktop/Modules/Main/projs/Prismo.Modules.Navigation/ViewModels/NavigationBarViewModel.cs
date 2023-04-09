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
        private readonly IEventAggregator _eventAggregator;

        public NavigationBarViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<FetchModuleNavigationItemsEvent>().Subscribe(items =>
            {
                foreach (var item in items)
                {
                    StaticItems.Add(item);
                }
            }, ThreadOption.UIThread);
        }

        public ObservableCollection<NavigationItemModel> StaticItems { get; private set; } = new()
        {
            new NavigationItemModel { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Home"},
            new NavigationItemModel { Kind = NavKind.Input, Selectable = false }
        };

        public ObservableCollection<NavigationItemModel> DynamicItems { get; private set; } = new();

        public ICommand NavigateHomeCommand { get; private set; } = new DelegateCommand(() => { });
    }
}
