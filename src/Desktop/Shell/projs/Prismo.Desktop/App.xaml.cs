using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Prismo.Modules.Navigation;
using Prismo.Modules.Rx;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Prismo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Views.MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<NavigationModule>(nameof(NavigationModule));
            moduleCatalog.AddModule<RxModule>(nameof(RxModule), InitializationMode.WhenAvailable, nameof(NavigationModule));
        }
    }
}
