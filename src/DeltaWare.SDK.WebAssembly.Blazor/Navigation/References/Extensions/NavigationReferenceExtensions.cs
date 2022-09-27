using System.Collections.Generic;
using DeltaWare.SDK.WebAssembly.Blazor.Navigation.References;

// ReSharper disable once CheckNamespace
namespace DeltaWare.SDK.WebAssembly.Blazor.Navigation
{
    public static class NavigationReferenceExtensions
    {
        /// <summary>
        /// Returns the parent references for the specifies <see cref="INavigationReference"/>.
        /// </summary>
        public static IEnumerable<INavigationReference> GetReferences(this INavigationReference reference)
        {
            List<INavigationReference> references = new List<INavigationReference>();

            while (reference.Parent != null)
            {
                references.Add(reference);

                reference = reference.Parent;
            }

            references.Reverse();

            return references;
        }
    }
}