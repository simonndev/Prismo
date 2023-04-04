using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prismo.Modules.Rx.Services
{
    public  class ImageDownloader
    {
        private readonly HttpClient _httpClient;

        public ImageDownloader(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public IObservable<MemoryStream> DownloadImageStreamObservable(string url)
        {
            return ObservableMixin.UsingAsync(
                () => _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead)
                , response => ObservableMixin.UsingAsync(
                    () => response.Content.ReadAsStreamAsync()
                    , contentStream => Observable.StartAsync(() =>
                    {
                        MemoryStream ms = new MemoryStream();
                        contentStream.CopyToAsync(ms);
                        return Task.FromResult(ms);
                    })
                )
            );
        }

        public IObservable<byte[]> DownloadImageBytesObservable(string url)
        {
            return ObservableMixin.UsingAsync(
                () => _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead)
                , response => Observable.FromAsync(() => response.Content.ReadAsByteArrayAsync()));
        }
    }
}
