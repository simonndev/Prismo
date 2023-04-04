using Microsoft.Xaml.Behaviors;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Prismo.Presentation.Behaviors
{
    public class NavigationBarGroupingBehavior : Behavior<ListBox>
    {
        public static bool GetGroupingEnabled(DependencyObject o) => (bool)o.GetValue(GroupingEnabledProperty);
        public static void SetGroupingEnabled(DependencyObject o, bool value) => o.SetValue(GroupingEnabledProperty, value); 

        // Using a DependencyProperty as the backing store for GroupingEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GroupingEnabledProperty =
            DependencyProperty.RegisterAttached("GroupingEnabled"
                , typeof(bool)
                , typeof(NavigationBarGroupingBehavior)
                , new FrameworkPropertyMetadata(false, OnGroupingEnabledChanged));

        private static void OnGroupingEnabledChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var navigationBar = o as ListBox;
            if (navigationBar != null)
            {
                //var behColl = Interaction.GetBehaviors(el);
                //var existingBehavior = behColl.FirstOrDefault(b => b.GetType() == typeof(DragDropBehavior)) as DragDropBehavior;
                //if ((bool)e.NewValue == false && existingBehavior != null)
                //{
                //    behColl.Remove(existingBehavior);
                //}
                //else if ((bool)e.NewValue == true && existingBehavior == null)
                //{
                //    behColl.Add(new DragDropBehavior());
                //}

                ICollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(navigationBar.Items);
                if (!(bool)e.NewValue)
                {
                    cv.GroupDescriptions.Clear();
                }
                else
                {
                    var groupBy = GetGroupBy(o);
                    var groupDescription = new PropertyGroupDescription(groupBy);
                    cv.GroupDescriptions.Add(groupDescription);
                }
            }
        }

        public static string GetGroupBy(DependencyObject o) => (string)o.GetValue(GroupByProperty);
        public static void SetGroupBy(DependencyObject o, string value) => o.SetValue(GroupByProperty, value);

        // Using a DependencyProperty as the backing store for GroupingEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GroupByProperty =
            DependencyProperty.RegisterAttached("GroupBy"
                , typeof(string)
                , typeof(NavigationBarGroupingBehavior)
                , new FrameworkPropertyMetadata(string.Empty));

        protected override void OnAttached()
        {
            //AssociatedObject.group

            base.OnAttached();
        }
    }
}
