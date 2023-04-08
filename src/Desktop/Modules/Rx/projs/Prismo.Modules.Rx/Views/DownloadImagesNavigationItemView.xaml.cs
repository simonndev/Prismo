using Prism.Ioc;
using Prism.Regions;
using Prismo.Presentation;
using System.Windows.Controls;

namespace Prismo.Modules.Rx.Views
{
    /// <summary>
    /// Interaction logic for DownloadImagesNavigationItemView.xaml
    /// </summary>
    public partial class DownloadImagesNavigationItemView : ListBoxItem
    {
        public DownloadImagesNavigationItemView(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();

            InitializeComponent();

            // Adds the content view for this navigation item; only activates it when user clicks to select.
            var contentView = containerProvider.Resolve<DownloadImagesContentView>();
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
                        region.Activate(contentView);
                    }
                };
            }
        }
    }
}
