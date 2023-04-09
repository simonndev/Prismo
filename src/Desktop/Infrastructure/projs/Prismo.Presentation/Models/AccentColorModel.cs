using Prism.Mvvm;
using System.Windows.Media;

namespace Prismo.Presentation.Models
{
    public class AccentColorModel : BindableBase
    {
        private string? _name;
        public string? Name
        {
            get { return _name; }
            set { this.SetProperty(ref _name, value); }
        }

        private Brush? _colorBrush;
        public Brush? ColorBrush
        {
            get { return _colorBrush; }
            set { this.SetProperty(ref _colorBrush, value); }
        }
    }
}
