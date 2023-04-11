using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Prismo.Modules.GoComics.Models
{
    public class ComicModel : BindableBase
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string SubHeading { get; set; }

        private BitmapImage _avatar;

        public BitmapImage Avatar
        {
            get { return _avatar; }
            set { SetProperty(ref _avatar, value); }
        }

        public string Uri { get; internal set; }
        public string AvatarUrl { get; internal set; }

        public void LoadAvatarFromBytes(byte[] bytes, bool freezable = false)
        {
            var image = new BitmapImage
            {
                CacheOption = BitmapCacheOption.OnLoad,
                CreateOptions = BitmapCreateOptions.PreservePixelFormat
            };

            MemoryStream ms = ToStream(bytes);
            image.BeginInit();
            image.StreamSource = ms;
            image.EndInit();

            if (freezable)
            {
                image.Freeze();
            }

            Avatar = image;
        }

        private static MemoryStream ToStream(byte[] bytes)
        {
            return new MemoryStream(bytes) { Position = 0 };
        }
    }
}
