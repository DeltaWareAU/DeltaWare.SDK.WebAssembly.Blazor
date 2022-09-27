using MudBlazor;

namespace DeltaWare.SDK.WebAssembly.Blazor.Types
{
    public class DialogResponse
    {
        public bool WasCancelled { get; }

        public DialogResponse(bool wasCancelled)
        {
            WasCancelled = wasCancelled;
        }

        public static DialogResponse<T> FromResult<T>(DialogResult result)
        {
            T data = default;

            if (result.Data != null)
            {
                data = (T)result.Data;
            }

            return new(data, result.Cancelled);
        }

        public static DialogResponse FromResult(DialogResult result)
        {
            return new DialogResponse(result.Cancelled);
        }
    }

    public class DialogResponse<T> : DialogResponse
    {
        public T Data { get; }

        public DialogResponse(T data, bool wasCancelled) : base(wasCancelled)
        {
            Data = data;
        }
    }
}