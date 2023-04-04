using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using Prismo.Presentation;
using Prismo.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prismo.Modules.Rx.ViewModels
{
    public class DownloadImagesNavigationItemViewModel : NavigationItemModel
    {
        public DownloadImagesNavigationItemViewModel()
        {
            this.Selectable = true;
            this.Kind = NavKind.Default;
            this.Icon = NavIcons.Default;
            this.ModuleName = "Rx";
            this.Heading = "Rx - Download Images";
            this.SubHeading = "Provide a list of image URLs, download and load them onto UI";
        }
    }
}
