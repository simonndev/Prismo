using Prism.Mvvm;

namespace Prismo.Modules.Rx.ViewModels
{
    public class DownloadImagesContentViewModel : BindableBase
    {
        public DownloadImagesContentViewModel()
        {
            Heading = "Content View of Download Images navigation item.";
        }

        public string Heading { get; set; }
    }
}
