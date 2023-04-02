using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prismo.Modules.Rx.Services;
using Prismo.Presentation;
using Prismo.Presentation.Events;
using System;

namespace Prismo.Modules.Rx
{
    public class RxModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var rm = containerProvider.Resolve<IRegionManager>();
            rm.RegisterViewWithRegion<Views.NavigationView>(RegionNames.NavigationRegion);
            rm.RegisterViewWithRegion<Views.DownloadExNavigationItemView>(RegionNames.DynamicNavigationRegion);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<INavigationItemsProvider>(container => container.Resolve<NavigationItemsProvider>());
        }
    }
}
