using Prism.Regions;
using Prismo.Presentation;
using Prismo.Presentation.Helper;
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

namespace Prismo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private readonly IRegionManager _regionManager;

        public MainView(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            InitializeComponent();

            Loaded += (s, e) =>
            {
                // As the visual object we want to find is defined in a ContentTemplate, so
                // 1. Find the ContentPresenter
                ContentPresenter? contentPresenter = UIElementFinder.FindVisualChild<ContentPresenter>(MainContentHolder);
                if (contentPresenter is not null)
                {
                    DataTemplate template = contentPresenter.ContentTemplate;

                    // 2. Find the ContentControl that hosts the navigation content view by its name.
                    ContentControl? holder = (ContentControl)template.FindName("DynamicContentHolder", contentPresenter);
                    if (holder is not null)
                    {
                        // 3. Register it as a Region
                        RegionManager.SetRegionManager(holder, _regionManager);
                        RegionManager.SetRegionName(holder, RegionNames.DynamicContentRegion);
                    }
                }
            };
        }

    }
}
