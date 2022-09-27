using System;

namespace DeltaWare.SDK.WebAssembly.Blazor.Navigation.References
{
    public interface INavigationReference
    {
        string Icon { get; }
        Guid Identity { get; }
        INavigationGroupReference Parent { get; }
        string Title { get; }
        bool Hidden { get; }
    }
}