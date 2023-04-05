using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prismo.Modules.Rx.Services;
using Prismo.Presentation;
using Prismo.Presentation.Events;
using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;

namespace Prismo.Modules.Rx
{
    public class RxModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var rm = containerProvider.Resolve<IRegionManager>();
            rm.RegisterViewWithRegion<Views.StaticNavigationView>(RegionNames.NavigationRegion);
            rm.RegisterViewWithRegion<Views.DownloadImagesNavigationItemView>(RegionNames.DynamicNavigationRegion);

            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
            var handler = new HttpClientHandler
            {
                UseProxy = true,
                Proxy = new WebProxy(new Uri("http://rb-proxy-apac.bosch.com:8080") )
            };
            var httpClient = new HttpClient(handler);

            containerRegistry.RegisterInstance(httpClient, "ImageDownloaderHttpClient");
            containerRegistry.RegisterSingleton<ImageDownloader>(container => new ImageDownloader(container.Resolve<HttpClient>("ImageDownloaderHttpClient")));

            containerRegistry.RegisterSingleton<INavigationItemsProvider>(container => container.Resolve<NavigationItemsProvider>());

            // Register the view's instance
            containerRegistry.RegisterInstance(typeof(Views.DownloadImagesContentView), new Views.DownloadImagesContentView());
        }
    }
}
