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
    public class DownloadImageNavigationItemViewModel : NavigationItemModel
    {
        public DownloadImageNavigationItemViewModel()
        {
            this.Selectable = true;
            this.Kind = NavKind.Default;
            this.Icon = NavIcons.Default;
            this.ModuleName = "Rx";
            this.Heading = "Rx - Download Image";
            this.SubHeading = "Provide a image URL, download and load it onto UI";
        }
    }
}
