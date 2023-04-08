using MahApps.Metro.Controls;
using Prism.Regions;
using Prismo.Presentation;
using Prismo.Presentation.Controls;
using Prismo.Presentation.Helper;
using Prismo.ViewModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Prismo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ShellView : MetroWindow
    {
        private readonly IRegionManager _regionManager;

        private bool _set1;
        private  bool _set2;

        public ShellView(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            InitializeComponent();

            var vm = this.DataContext as ShellViewModel;
            vm.ShellContentChanged += OnShellViewContentChanged;

            Loaded += ShellViewOnLoaded;
        }

        private void OnShellViewContentChanged(object? sender, System.EventArgs e)
        {
            if (_set2) return;

            var presenter = UIElementFinder.FindVisualChild<ContentPresenter>(MainContentHolder);
            if (presenter != null)
            {
                // below is the only way to find the ContentControl
                var contentView = (UserControl)presenter.Content;
                var grid = (Grid)contentView.Content;

                // grid.FindChild("DynamicContentHolder") does not work as it is not a visual child
                ItemsControl? holder = (ItemsControl)grid.FindName("DynamicContentHolder");

                // 3. Register it as a Region
                RegionManager.SetRegionManager(holder, _regionManager);
                RegionManager.SetRegionName(holder, RegionNames.DynamicContentRegion);

                _set2 = true;
            }

            // 2b. Find the ContentControl that hosts the navigation content view by its name.
        }

        private void ShellViewOnLoaded(object sender, RoutedEventArgs e)
        {
            if (_set1) return;

            var presenter = UIElementFinder.FindVisualChild<ContentPresenter>(MainContentHolder);
            if (presenter != null)
            {
                var homeView = (UserControl)presenter.Content;

                //ListBox? ug = (ListBox)homeView.FindName("LoadedModulesListBox", presenter);
                ListBox? ug = UIElementFinder.FindChild<ListBox>(homeView, "LoadedModulesListBox");

                // 3. Register it as a Region
                RegionManager.SetRegionManager(ug, _regionManager);
                RegionManager.SetRegionName(ug, RegionNames.DashboashModulesRegion);

                _set1 = true;
            }
        }
    }
}
