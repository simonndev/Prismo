using Prism;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prismo.Presentation;
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
    public class NavigationBarViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public NavigationBarViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            //eventAggregator.GetEvent<FetchModuleNavigationItemsEvent>().Subscribe(items =>
            //{
            //    foreach (var item in items)
            //    {
            //        StaticItems.Add(item);
            //    }
            //}, ThreadOption.UIThread);

            var homeItem = new NavigationItemModel() { Icon = NavIcons.Home, Kind = NavKind.Default, Heading = "Home", Selectable = true, IsSelected = false };
            homeItem.ItemSelected += HomeNavItemOnSelected;

            StaticItems = new ObservableCollection<NavigationItemModel> {
                homeItem,
                new NavigationItemModel { Kind = NavKind.Input, Selectable = false }
            };

            SelectedStaticItemIndex = 1;
        }

        public ObservableCollection<NavigationItemModel> StaticItems { get; private set; }
        private int _selectedStaticItemIndex;

        public int SelectedStaticItemIndex
        {
            get { return _selectedStaticItemIndex; }
            set { SetProperty(ref _selectedStaticItemIndex ,value); }
        }


        public ObservableCollection<NavigationItemModel> DynamicItems { get; private set; } = new();

        public ICommand NavigateHomeCommand { get; private set; } = new DelegateCommand(() => { });

        private void HomeNavItemOnSelected(object sender, EventArgs e)
        {
            var homeItem = sender as NavigationItemModel;
            if (homeItem != null)
            {
                var payload = new NavigationItemSelectedEventPayload(homeItem);
                _eventAggregator.GetEvent<NavigationItemSelectedEvent>().Publish(payload);

                // so the Home Nav Item won't keep the focus next time
                homeItem.IsSelected = false;
            }
        }
    }
}
