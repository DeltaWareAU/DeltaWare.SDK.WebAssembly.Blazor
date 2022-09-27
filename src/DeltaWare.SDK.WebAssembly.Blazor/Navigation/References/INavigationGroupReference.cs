using System.Collections.Generic;

namespace DeltaWare.SDK.WebAssembly.Blazor.Navigation.References
{
    public interface INavigationGroupReference : INavigationReference
    {
        IReadOnlyList<INavigationReference> ChildReferences { get; }
        bool Expanded { get; }
    }
}