using System;
using Microsoft.AspNetCore.Components.Routing;

namespace DeltaWare.SDK.WebAssembly.Blazor.Navigation.References.Types
{
    public class NavigationPageReference : NavigationReferenceBase, INavigationPageReference
    {
        public string Href { get; }
        public NavLinkMatch LinkMatch { get; }

        public NavigationPageReference(string title, string href, string icon = null, bool hidden = false, NavLinkMatch linkMatch = NavLinkMatch.Prefix) : base(title, icon, hidden)
        {
            Href = href ?? throw new ArgumentNullException(nameof(href));
            LinkMatch = linkMatch;
        }

        internal NavigationPageReference(INavigationGroupReference parent, string title, string href, string icon = null, bool hidden = false, NavLinkMatch linkMatch = NavLinkMatch.Prefix) : base(title, icon, hidden, parent)
        {
            Href = href ?? throw new ArgumentNullException(nameof(href));
            LinkMatch = linkMatch;
        }
    }
}