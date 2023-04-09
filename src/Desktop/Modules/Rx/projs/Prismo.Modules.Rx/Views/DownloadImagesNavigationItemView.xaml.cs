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

            IRegion? region = null;

            if (regionManager.Regions.ContainsRegionWithName(RegionNames.DynamicContentRegion))
            {
                region = regionManager.Regions[RegionNames.DynamicContentRegion];
                var contentView = region.GetView(nameof(DownloadImagesContentView));
                if (contentView is null)
                {
                    contentView = containerProvider.Resolve<DownloadImagesContentView>();
                    region.Add(contentView, nameof(DownloadImagesContentView));
                }
            }

            if (DataContext is ViewModels.DownloadImagesNavigationItemViewModel vm)
            {
                vm.ItemSelected += (s, e) =>
                {
                    if (region != null)
                    {
                        var contentView = region.GetView(nameof(DownloadImagesContentView));
                        region.Activate(contentView);
                    }
                };
            }
        }
    }
}
