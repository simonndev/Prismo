using Prism.Commands;
using Prism.Mvvm;
using Prismo.Modules.Rx.Models;
using Prismo.Modules.Rx.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows;

namespace Prismo.Modules.Rx.ViewModels
{
    public class DownloadImagesContentViewModel : BindableBase
    {
        private readonly ImageDownloader _imageDownloader;

        public DownloadImagesContentViewModel(ImageDownloader imageDownloader)
        {
            _imageDownloader = imageDownloader ?? throw new ArgumentNullException(nameof(imageDownloader));

            DownloadUrlsCommand= new DelegateCommand(DownloadUrls);
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (value != _isLoading)
                {
                    SetProperty(ref _isLoading, value);
                }
            }
        }

        public ObservableCollection<ImageModel> ImageCollection { get; private set; } = new ObservableCollection<ImageModel>();

        public DelegateCommand DownloadUrlsCommand { get; private set; }

        private void DownloadUrls()
        {
            if (ImageCollection.Count > 0)
            {
                ImageCollection.Clear();
            }

            //IsLoading = true;

            var imageUrls = new List<string>
            {
                "https://assets.gocomics.com/assets/promotional/mid_tfs_u.png",
                "https://avatar.amuniversal.com/feature_avatars/ubadge_images/features/ch/small_u-201701251613.png",
                "https://avatar.amuniversal.com/feature_avatars/ubadge_images/features/bab/small_bab_u_202201031430.png",
                "https://avatar.amuniversal.com/feature_avatars/ubadge_images/features/hc/small_hc_u_202004270658.png",
                "https://avatar.amuniversal.com/feature_avatars/ubadge_images/features/hev/small_u-201701251614.png",
                "https://avatar.amuniversal.com/feature_avatars/ubadge_images/features/cbg/small_cbg_u_202201241139.png",
                "https://avatar.amuniversal.com/feature_avatars/ubadge_images/features/bn/small_u-201701251613.png",
                "https://avatar.amuniversal.com/feature_avatars/ubadge_images/features/mtb/small_mtb_u_201710261329.png",
                "https://avatar.amuniversal.com/feature_avatars/ubadge_images/features/bcn/small_bcn_u_201703201232.png",
                "https://avatar.amuniversal.com/feature_avatars/ubadge_images/features/wtb/small_wtb_u_202204181313.png",
                "https://avatar.amuniversal.com/feature_avatars/ubadge_images/features/hmfr/small_hmfr_u_202208251158.png",
                "https://avatar.amuniversal.com/feature_avatars/ubadge_images/features/lc/small_u-201701251613.png"
            };

            var images = imageUrls.Select(url => new ImageModel { Url = url });
            foreach (var image in images)
            {
                ImageCollection.Add(image);
            }
            var obs = (from img in images.ToObservable()
                       from ms in _imageDownloader.DownloadImageStreamObservable(img.Url)
                           .ObserveOn(CurrentThreadScheduler.Instance)
                           .Do(ms =>
                           {
                               Application.Current.Dispatcher.InvokeAsync(() =>
                               {
                                   img.SetImage(ms, 72, 72);
                               });
                           })
                       select img).Subscribe();
        }

        private void SubscribeImage(ImageModel image)
        {
            // Orders are messed up
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                ImageCollection.Add(image);
            });
        }
    }
}
