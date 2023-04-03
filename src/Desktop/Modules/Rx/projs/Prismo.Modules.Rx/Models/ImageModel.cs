using Prism.Mvvm;
using System.IO;
using System.Windows.Media.Imaging;

namespace Prismo.Modules.Rx.Models
{
    public class ImageModel : BindableBase
    {
        private string _url;
        public string Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }

        private BitmapImage _image;
        public BitmapImage Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        public void SetImage(MemoryStream ms, int width, int height)
        {
            try
            {
                var image = new BitmapImage
                {
                    DecodePixelWidth = width,
                    DecodePixelHeight = height
                };

                image.BeginInit();
                image.StreamSource = ms;
                image.EndInit();

                Image = image;
            }
            finally
            {
                ms.Dispose();
            }

            
        }
    }
}
