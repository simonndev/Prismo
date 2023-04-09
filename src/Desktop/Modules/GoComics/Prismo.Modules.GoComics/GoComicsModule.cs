using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prismo.Modules.GoComics.Services;
using Prismo.Presentation.Events;
using System;

namespace Prismo.Modules.GoComics
{
    public class GoComicsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            IEventAggregator eventAggregator = containerProvider.Resolve<IEventAggregator>();
            var navigationItemsProvider = containerProvider.Resolve<NavigationItemsProvider>();
            eventAggregator.GetEvent<FetchModuleNavigationItemsEvent>().Publish(navigationItemsProvider.GetNavigationItems());
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<NavigationItemsProvider>(() => new NavigationItemsProvider());
        }
    }
}
