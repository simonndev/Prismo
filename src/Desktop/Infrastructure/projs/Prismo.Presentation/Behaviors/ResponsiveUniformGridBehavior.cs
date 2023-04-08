using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Prismo.Presentation.Behaviors
{
    public class ResponsiveUniformGridBehavior : Behavior<UniformGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            if (AssociatedObject is UniformGrid)
            {
                var uniformGrid = (UniformGrid)AssociatedObject;
                uniformGrid.SizeChanged += UniformGrid_SizeChanged;
            }
        }

        protected override void OnDetaching()
        {
            if (AssociatedObject is UniformGrid)
            {
                var uniformGrid = (UniformGrid)AssociatedObject;
                uniformGrid.SizeChanged -= UniformGrid_SizeChanged;
            }

            base.OnDetaching();
        }

        private static void UniformGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var uniformGrid = (UniformGrid)sender;
            var width = uniformGrid.ActualWidth;
            if (width > 1200)
            {
                uniformGrid.Columns = 5;
            }
            else if (width <= 1200 && width > 960)
            {
                uniformGrid.Columns = 4;
            }
            else if (width <= 960 && width > 768)
            {
                uniformGrid.Columns = 3;
            }
            else if (width <= 768 && width > 480)
            {
                uniformGrid.Columns = 2;
            }
            else
            {
                uniformGrid.Columns = 1;
            }
        }
    }
}
