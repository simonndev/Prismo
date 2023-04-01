using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prismo.Modules.Navigation.Models
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
        private NavKind _kind;
        public NavKind Kind
        {
            get { return _kind; }
            set
            {
                if (value != _kind)
                {
                    _kind = value;
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
                    _icon = value;
                    SetProperty(ref _icon, value);
                }
            }
        }

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
                    _inputText = value;
                    SetProperty(ref _inputText, value);
                }
            }
        }

        public bool Selectable { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (Selectable &&  _isSelected != value)
                {
                    _isSelected = value;
                    SetProperty(ref _isSelected, value);
                }
            }
        }
    }
}
