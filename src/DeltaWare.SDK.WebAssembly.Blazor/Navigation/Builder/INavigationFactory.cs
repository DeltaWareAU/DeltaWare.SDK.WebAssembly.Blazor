using DeltaWare.SDK.WebAssembly.Blazor.Navigation.References.Types;

namespace DeltaWare.SDK.WebAssembly.Blazor.Navigation.Builder
{
    internal interface INavigationFactory
    {
        NavigationGroupReference Build();
    }
}