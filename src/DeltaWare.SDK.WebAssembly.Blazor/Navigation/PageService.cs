using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeltaWare.SDK.WebAssembly.Blazor.Navigation.Builder;
using DeltaWare.SDK.WebAssembly.Blazor.Navigation.References;
using DeltaWare.SDK.WebAssembly.Blazor.Navigation.References.Types;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace DeltaWare.SDK.WebAssembly.Blazor.Navigation
{
    internal class PageService : IPageService, IDisposable
    {
        private readonly Queue<string> _locationHistory = new();
        private readonly NavigationManager _navManager;
        private readonly NavigationGroupReference _root;

        public string CurrentLocation => _navManager.Uri.Substring(_navManager.BaseUri.Length - 1);

        public PageService(INavigationFactory navigationFactory, NavigationManager navManager)
        {
            _navManager = navManager;
            _root = navigationFactory.Build();

            _navManager.LocationChanged += OnLocationChange;
        }

        public Task<IEnumerable<INavigationReference>> GetAsync()
        {
            return Task.FromResult((IEnumerable<INavigationReference>)_root.ChildReferences);
        }

        public INavigationPageReference GetCurrentPage()
        {
            var page = _root.FindPage(CurrentLocation);

            return page;
        }

        public INavigationPageReference GetPage(string pageUri)
        {
            var page = _root.FindPage(pageUri);

            return page;
        }

        public Task<bool> GoBackAsync()
        {
            if (!_locationHistory.TryDequeue(out string uri))
            {
                return Task.FromResult(false);
            }

            _navManager.NavigateTo(uri);

            return Task.FromResult(true);
        }

        public IEnumerable<INavigationPageReference> SearchAsync(string value)
        {
            throw new NotImplementedException();
        }

        private void OnLocationChange(object sender, LocationChangedEventArgs args)
        {
            string location = string.Empty;

            if (!string.IsNullOrEmpty(args.Location))
            {
                // The location is returned with the full address, we only want the relative
                // address. So we remove the BaseUri.
                location = args.Location.Remove(0, _navManager.BaseUri.Length - 1);
            }

            if (CurrentLocation != location)
            {
                _locationHistory.Enqueue(CurrentLocation);
            }
        }

        #region IDisposable

        private volatile bool _disposed;

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;

            _navManager.LocationChanged -= OnLocationChange;

            GC.SuppressFinalize(this);
        }

        #endregion IDisposable
    }
}