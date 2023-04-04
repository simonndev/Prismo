using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prismo.Modules.Rx.Services
{
    public static class ObservableMixin
    {
        public static IObservable<TSource> UsingAsync<TSource, TResource>(
            Func<Task<TResource>> resourceFactoryAsync,
            Func<TResource, IObservable<TSource>> observableFactory)
            where TResource : IDisposable
        {
            return Observable
                .FromAsync(resourceFactoryAsync)
                .SelectMany(resource => Observable.Using(() => resource, observableFactory));
        }
    }
}
