using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prismo.Presentation;
using Prismo.Presentation.Events;
using System;

namespace Prismo.Modules.Navigation
{
    public class NavigationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var rm = containerProvider.Resolve<IRegionManager>();
            rm.RegisterViewWithRegion<Views.NavigationBarView>(RegionNames.LeftContentRegion);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
