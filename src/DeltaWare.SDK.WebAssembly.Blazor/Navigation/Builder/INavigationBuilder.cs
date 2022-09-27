using System;
using Microsoft.AspNetCore.Components.Routing;

namespace DeltaWare.SDK.WebAssembly.Blazor.Navigation.Builder
{
    public interface INavigationBuilder
    {
        void AddGroup(string title, string icon = null, bool expanded = false, Action<INavigationBuilder> builder = null);

        void AddPage(string title, string href, string icon = null, NavLinkMatch linkMatch = NavLinkMatch.Prefix);

        void AddHiddenPage(string title, string href, string icon = null, NavLinkMatch linkMatch = NavLinkMatch.Prefix);
    }
}