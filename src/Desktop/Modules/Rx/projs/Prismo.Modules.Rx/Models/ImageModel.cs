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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ms"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <remarks>
        /// <para><see cref="BitmapImage"/> should always be created with <see cref="BitmapCacheOption.OnLoad"/>.</para>
        /// <para><see cref="MemoryStream"/> should not be disposed during this process.</para>
        /// </remarks>
        public void LoadImageFromStream(MemoryStream ms, int width, int height)
        {
            var image = new BitmapImage
            {
                CreateOptions = BitmapCreateOptions.PreservePixelFormat,
                CacheOption = BitmapCacheOption.OnLoad,
                DecodePixelWidth = width,
                DecodePixelHeight = height
            };

            image.BeginInit();
            image.StreamSource = ms;
            image.EndInit();
            image.Freeze();

            Image = image;
        }

        public void LoadImageFromBytes(byte[] data, int width, int height)
        {
            var image = new BitmapImage
            {
                CreateOptions = BitmapCreateOptions.PreservePixelFormat,
                CacheOption = BitmapCacheOption.OnLoad,
                DecodePixelWidth = width,
                DecodePixelHeight = height
            };

            MemoryStream ms = new MemoryStream(data);
            image.BeginInit();
            image.StreamSource = ms;
            image.EndInit();
            image.Freeze();

            Image = image;
        }
    }
}
