using Prism.Ioc;
using Prism.Regions;
using Prismo.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prismo.Modules.Rx.Views
{
    /// <summary>
    /// Interaction logic for DownloadImageNavigationItemView.xaml
    /// </summary>
    public partial class DownloadImageNavigationItemView : ListBoxItem
    {
        public DownloadImageNavigationItemView(IContainerProvider containerProvider)
        {
            InitializeComponent();

            var regionManager = containerProvider.Resolve<IRegionManager>();

            // Adds the content view for this navigation item; only activates it when user clicks to select.
            var contentView = containerProvider.Resolve<DownloadImageContentView>();
            IRegion? region = null;

            if (regionManager.Regions.ContainsRegionWithName(RegionNames.DynamicContentRegion))
            {
                region = regionManager.Regions[RegionNames.DynamicContentRegion];
                if (!region.ActiveViews.Contains(contentView))
                {
                    region.Add(contentView);
                }
            }

            if (DataContext is ViewModels.DownloadImagesNavigationItemViewModel vm)
            {
                vm.ItemSelected += (s, e) =>
                {
                    if (region != null)
                    {
                        if (!region.ActiveViews.Contains(contentView))
                        {
                            if (region.Views.Contains(contentView))
                            {
                                region.Activate(contentView);
                            }
                        }
                    }
                };
            }
        }
    }
}
