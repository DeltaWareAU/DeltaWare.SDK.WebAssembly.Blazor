using System;
using System.Collections.Generic;
using DeltaWare.SDK.WebAssembly.Blazor.Exceptions;

namespace DeltaWare.SDK.WebAssembly.Blazor.Navigation.References.Types
{
    public class NavigationGroupReference : NavigationReferenceBase, INavigationGroupReference
    {
        private readonly List<INavigationReference> _childReferences = new();

        public IReadOnlyList<INavigationReference> ChildReferences => _childReferences;

        public bool Expanded { get; set; }

        public NavigationGroupReference(string title, string icon = null, bool expanded = false) : base(title, icon)
        {
            Expanded = expanded;
        }

        internal NavigationGroupReference(INavigationGroupReference parent, string title, string icon = null, bool expanded = false) : base(title, icon, false, parent)
        {
            Expanded = expanded;
        }

        public void AddChildReference(NavigationReferenceBase child)
        {
            child.Parent = this;

            _childReferences.Add(child);
        }

        public INavigationReference FindChild(Guid identity)
        {
            INavigationReference child = null;

            foreach (INavigationReference childReference in _childReferences)
            {
                INavigationReference foundChild = null;

                if (childReference is NavigationGroupReference groupReference)
                {
                    foundChild = groupReference.FindChild(identity);
                }
                else if (childReference.Identity.Equals(identity))
                {
                    foundChild = childReference;
                }

                if (foundChild == null)
                {
                    continue;
                }

                if (child != null)
                {
                    throw new DuplicateChildReferenceException(foundChild);
                }

                child = foundChild;
            }

            return child;
        }

        public INavigationPageReference FindPage(string uri)
        {
            INavigationPageReference child = null;

            foreach (INavigationReference childReference in _childReferences)
            {
                INavigationPageReference foundChild = null;

                if (childReference is NavigationGroupReference groupReference)
                {
                    foundChild = groupReference.FindPage(uri);
                }
                else if (childReference is NavigationPageReference pageReference && pageReference.Href.Equals(uri))
                {
                    foundChild = pageReference;
                }

                if (foundChild == null)
                {
                    continue;
                }

                if (child != null)
                {
                    throw new DuplicateChildReferenceException(foundChild);
                }

                child = foundChild;
            }

            return child;
        }

        public void RemoveChildReference(NavigationReferenceBase child)
        {
            if (Equals(child.Parent, this))
            {
                throw new ArgumentException($"The provided child {child.Title} is not a child of this group.");
            }

            if (_childReferences.Remove(child))
            {
                child.Parent = null;
            }
        }
    }
}