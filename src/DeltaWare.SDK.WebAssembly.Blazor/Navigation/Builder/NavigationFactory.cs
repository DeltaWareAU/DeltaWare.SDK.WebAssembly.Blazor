using System;
using DeltaWare.SDK.WebAssembly.Blazor.Navigation.References.Types;
using Microsoft.AspNetCore.Components.Routing;

namespace DeltaWare.SDK.WebAssembly.Blazor.Navigation.Builder
{
    internal sealed class NavigationFactory : INavigationBuilder, INavigationFactory
    {
        private readonly NavigationGroupReference _parent;

        public NavigationFactory()
        {
            _parent = new NavigationGroupReference("root", "");
        }

        private NavigationFactory(NavigationGroupReference parent)
        {
            _parent = parent;
        }

        public void AddGroup(string title, string icon = null, bool expanded = false, Action<INavigationBuilder> builder = null)
        {
            NavigationGroupReference group = new NavigationGroupReference(title, icon);

            _parent.AddChildReference(group);

            builder?.Invoke(new NavigationFactory(group));
        }

        public void AddPage(string title, string href, string icon = null, NavLinkMatch linkMatch = NavLinkMatch.Prefix)
        {
            NavigationPageReference page = new NavigationPageReference(title, href, icon, false, linkMatch);

            _parent.AddChildReference(page);
        }

        public void AddHiddenPage(string title, string href, string icon = null, NavLinkMatch linkMatch = NavLinkMatch.Prefix)
        {
            NavigationPageReference page = new NavigationPageReference(title, href, icon, true, linkMatch);

            _parent.AddChildReference(page);
        }

        public NavigationGroupReference Build()
        {
            return _parent;
        }
    }
}