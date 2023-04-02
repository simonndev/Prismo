using Prism.Events;
using Prismo.Presentation.Models;
using System;

namespace Prismo.Presentation.Events
{
    public class NavigationItemSelectedEvent : PubSubEvent<NavigationItemSelectedEventPayload>
    {
    }

    public class NavigationItemSelectedEventPayload
    {
        public NavigationItemSelectedEventPayload(NavigationItemModel source, object? contentView = null, string? moduleName = null)
        {
            Source = source;

            ContentView = contentView;
            ModuleName = moduleName;
        }

        public NavigationItemModel Source { get; private set; }

        public string? ModuleName { get; private set; }

        public object? ContentView { get; private set; }
        public Type? ContentViewType => ContentView?.GetType();
        public string? ContentViewName => ContentViewType?.Name;
    }
}
