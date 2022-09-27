using Microsoft.AspNetCore.Components.Routing;

namespace DeltaWare.SDK.WebAssembly.Blazor.Navigation.References
{
    public interface INavigationPageReference : INavigationReference
    {
        string Href { get; }
        NavLinkMatch LinkMatch { get; }
    }
}