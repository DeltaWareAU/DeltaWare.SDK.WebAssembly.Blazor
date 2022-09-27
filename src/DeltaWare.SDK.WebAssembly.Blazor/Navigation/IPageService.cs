using System.Collections.Generic;
using System.Threading.Tasks;
using DeltaWare.SDK.WebAssembly.Blazor.Navigation.References;

namespace DeltaWare.SDK.WebAssembly.Blazor.Navigation
{
    public interface IPageService
    {
        Task<IEnumerable<INavigationReference>> GetAsync();

        INavigationPageReference GetCurrentPage();

        INavigationPageReference GetPage(string pageUri);

        public Task<bool> GoBackAsync();

        IEnumerable<INavigationPageReference> SearchAsync(string value);
    }
}