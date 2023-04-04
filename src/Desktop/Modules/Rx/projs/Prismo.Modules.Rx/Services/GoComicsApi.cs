using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Prismo.Modules.Rx.Services
{
    public class GoComicsApi
    {
        private readonly HttpClient _httpClient;

        public GoComicsApi(HttpClient http)
        {
            _httpClient = http ?? throw new ArgumentNullException(nameof(http));
        }
    }
}
