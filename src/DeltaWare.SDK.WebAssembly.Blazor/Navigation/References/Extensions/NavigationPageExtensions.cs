using MudBlazor;
using System.Collections.Generic;
using DeltaWare.SDK.WebAssembly.Blazor.Navigation.References;

// ReSharper disable once CheckNamespace
namespace DeltaWare.SDK.WebAssembly.Blazor.Navigation
{
    public static class NavigationPageExtensions
    {
        public static List<BreadcrumbItem> GetBreadcrumbs(this INavigationPageReference pageReference)
        {
            List<BreadcrumbItem> breadcrumbs = new List<BreadcrumbItem>
            {
                new("Home", "", false, Icons.Material.Filled.Home)
            };

            foreach (INavigationReference reference in pageReference.GetReferences())
            {
                if (reference is INavigationPageReference page)
                {
                    breadcrumbs.Add(new BreadcrumbItem(page.Title, page.Href, false, page.Icon));
                }
                else
                {
                    breadcrumbs.Add(new BreadcrumbItem(reference.Title, null, true, reference.Icon));
                }
            }

            return breadcrumbs;
        }
    }
}