using System.Collections.Generic;
using System.Threading.Tasks;
using DeltaWare.SDK.WebAssembly.Blazor.Types;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using MudBlazor;

namespace DeltaWare.SDK.WebAssembly.Blazor.Components
{
    public abstract class DialogBaseComponent<TDialog> : ComponentBase where TDialog : ComponentBase
    {
        [Inject] protected IDialogService DialogService { get; set; }
        protected bool IsLoading { get; set; }
        [Inject] protected ILogger<TDialog> Logger { get; set; }
        [CascadingParameter] protected MudDialogInstance MudDialog { get; set; }
        [Inject] protected ISnackbar Snackbar { get; set; }

        protected static async Task<DialogResponse<TResponse>> InternalDisplayAsync<TResponse>(IDialogService dialogService, string title, Dictionary<string, object> parameters = null)
        {
            DialogParameters dialogParameters = new DialogParameters();

            if (parameters != null)
            {
                foreach ((string key, object value) in parameters)
                {
                    dialogParameters.Add(key, value);
                }
            }

            DialogOptions options = new DialogOptions
            {
                DisableBackdropClick = true,
                CloseButton = true
            };

            IDialogReference dialogReference = dialogService.Show<TDialog>(title, dialogParameters, options);

            return DialogResponse.FromResult<TResponse>(await dialogReference.Result);
        }
    }

    public abstract class DialogBaseComponent<TDialog, TResponse> : ComponentBase where TDialog : ComponentBase
    {
        protected TResponse Response { get; set; }

        [Inject] protected IDialogService DialogService { get; set; }
        protected bool IsLoading { get; set; }
        [Inject] protected ILogger<TDialog> Logger { get; set; }
        [CascadingParameter] protected MudDialogInstance MudDialog { get; set; }
        [Inject] protected ISnackbar Snackbar { get; set; }

        protected static async Task<DialogResponse<TResponse>> InternalDisplayAsync(IDialogService dialogService, string title, Dictionary<string, object> parameters = null)
        {
            DialogParameters dialogParameters = new DialogParameters();

            if (parameters != null)
            {
                foreach ((string key, object value) in parameters)
                {
                    dialogParameters.Add(key, value);
                }
            }

            DialogOptions options = new DialogOptions
            {
                DisableBackdropClick = true,
                CloseButton = true
            };

            IDialogReference dialogReference = dialogService.Show<TDialog>(title, dialogParameters, options);

            return DialogResponse.FromResult<TResponse>(await dialogReference.Result);
        }

        protected void Submit()
        {
            MudDialog.Close(DialogResult.Ok(Response));
        }
    }
}