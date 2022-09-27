using System;
using DeltaWare.SDK.WebAssembly.Blazor.Navigation.References;

namespace DeltaWare.SDK.WebAssembly.Blazor.Exceptions
{
    public class DuplicateChildReferenceException : Exception
    {
        public INavigationReference Reference;

        public DuplicateChildReferenceException(INavigationReference reference)
        {
            Reference = reference;
        }
    }
}