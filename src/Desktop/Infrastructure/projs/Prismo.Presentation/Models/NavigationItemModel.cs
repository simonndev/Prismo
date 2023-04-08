using Prism.Events;
using Prism.Mvvm;
using Prismo.Presentation.Events;
using System;

namespace Prismo.Presentation.Models
{
    public enum NavIcons
    {
        Default = 0,
        Home
    }

    public enum NavKind
    {
        /// <summary>
        /// Icon and Text
        /// </summary>
        Default = 0,

        /// <summary>
        /// TextBox
        /// </summary>
        Input,
        TextOnly
    }

    public class NavigationItemModel : BindableBase
    {
        private NavigationItemModel(string? moduleName = null, string? category = null, string? heading = null, string? subHeading = null, NavKind kind = NavKind.Default, NavIcons icon = NavIcons.Default, bool selectable = false)
        {
            ModuleName = moduleName;
            Category = category;
            Heading = heading;
            Kind = kind;
            Icon = icon;
            SubHeading = subHeading;
            Selectable = selectable;
        }

        public NavigationItemModel()
        {
        }

        private NavKind _kind;
        public NavKind Kind
        {
            get { return _kind; }
            set
            {
                if (value != _kind)
                {
                    SetProperty(ref _kind, value);
                }
            }
        }

        private NavIcons _icon;
        public NavIcons Icon
        {
            get { return _icon; }
            set
            {
                if (value != _icon)
                {
                    SetProperty(ref _icon, value);
                }
            }
        }

        public string? ModuleName { get; set; }
        public string? Category { get; set; }
        public string? Heading { get; set; }
        public string? SubHeading { get; set; }

        private string? _inputText;
        public string? InputText
        {
            get { return _inputText; }
            set
            {
                if (value is not null)
                {
                    SetProperty(ref _inputText, value);
                }
            }
        }

        public bool Selectable { get; set; }

        /// <summary>
        /// Notify the container that this item has been selected.
        /// </summary>
        /// <remarks>
        /// The container will listen to this event when raised,
        /// and call the <see cref="Prism.Events.IEventAggregator"/> to publish an event to display the associate content view accordingly. 
        /// </remarks>
        public event EventHandler ItemSelected;

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (Selectable && _isSelected != value)
                {
                    if (value)
                    {
                        OnItemSelected();
                    }

                    SetProperty(ref _isSelected, value);
                }
            }
        }

        public static NavigationItemModel Create(string heading, string? subHeading = null, NavKind kind = NavKind.Default, NavIcons icon = NavIcons.Default, bool selectable = false)
        {
            return new NavigationItemModel(null, null, heading, subHeading, kind, icon, selectable);
        }

        public static NavigationItemModel CreateForModule(string moduleName, string? category = null, string? heading = null, string? subHeading = null, NavKind kind = NavKind.Default, NavIcons icon = NavIcons.Default, bool selectable = false)
        {
            return new NavigationItemModel(moduleName, category, heading, subHeading, kind, icon, selectable);
        }

        protected void OnItemSelected()
        {
            var handler = ItemSelected;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void PublishSelectedEvent(IEventAggregator eventAggregator, object? contentView = null, string? moduleName = null)
        {
            if (eventAggregator != null)
            {
                var payload = new NavigationItemSelectedEventPayload(this,contentView,moduleName);
                eventAggregator.GetEvent<NavigationItemSelectedEvent>().Publish(payload);
            }
        }
    }
}
