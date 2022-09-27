using DeltaWare.SDK.WebAssembly.Blazor.Navigation;
using System;
using DeltaWare.SDK.WebAssembly.Blazor.Navigation;
using DeltaWare.SDK.WebAssembly.Blazor.Navigation.Builder;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class PageServiceCollectionExtensions
    {
        public static IServiceCollection UseNavigation(this IServiceCollection services, Action<INavigationBuilder> builder)
        {
            services.AddSingleton<INavigationFactory>(_ =>
            {
                NavigationFactory factory = new NavigationFactory();

                builder.Invoke(factory);

                return factory;
            });

            services.AddSingleton<IPageService, PageService>();

            return services;
        }
    }
}