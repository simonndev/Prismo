using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prismo.Presentation;
using System;

namespace Prismo.Modules.Rx
{
    public class RxModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegionManager rm = containerProvider.Resolve<IRegionManager>();
            rm.RegisterViewWithRegion<Views.NavigationView>(RegionNames.LeftContentRegion);
            rm.RegisterViewWithRegion<Views.MainView>(RegionNames.MainContentRegion);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
