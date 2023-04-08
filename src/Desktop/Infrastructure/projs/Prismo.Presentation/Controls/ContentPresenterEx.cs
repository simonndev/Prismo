using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Prismo.Presentation.Controls
{
    public class ContentPresenterEx : ContentPresenter
    {
        public static RoutedEvent ContentChangedEvent = EventManager.RegisterRoutedEvent(
            "ContentChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ContentPresenter));

        public event RoutedEventHandler ContentChanged
        {
            add { AddHandler(ContentChangedEvent, value); }
            remove { RemoveHandler(ContentChangedEvent, value); }
        }

        public static void AddContentChangedHandler(UIElement el, RoutedEventHandler handler)
        {
            el.AddHandler(ContentChangedEvent, handler);
        }

        public static void RemoveContentChangedHandler(UIElement el, RoutedEventHandler handler)
        {
            el.RemoveHandler(ContentChangedEvent, handler);
        }

        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);
            RaiseEvent(new RoutedEventArgs(ContentChangedEvent, this));
        }
    }
}
