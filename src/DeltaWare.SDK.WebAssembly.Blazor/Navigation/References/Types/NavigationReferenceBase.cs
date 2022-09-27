using System;

namespace DeltaWare.SDK.WebAssembly.Blazor.Navigation.References.Types
{
    public abstract class NavigationReferenceBase : INavigationReference
    {
        public string Icon { get; }
        public Guid Identity { get; } = Guid.NewGuid();
        public INavigationGroupReference Parent { get; internal set; }
        public string Title { get; }
        public bool Hidden { get; }

        protected NavigationReferenceBase(string title, string icon = null, bool hidden = false, INavigationGroupReference parent = null)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Icon = icon;
            Hidden = hidden;
            Parent = parent;
        }

        public override bool Equals(object obj)
        {
            return obj switch
            {
                null => false,
                INavigationReference reference => Identity.Equals(reference.Identity),
                _ => false
            };
        }

        public override int GetHashCode()
        {
            return Identity.GetHashCode();
        }
    }
}