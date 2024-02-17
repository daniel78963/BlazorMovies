using BlazorMovies.Shared.Entities;
using Microsoft.JSInterop;

namespace BlazorMovies.Client.Helpers
{
    public static class IJSRuntimeExtensionMethods
    {
        public static async ValueTask<bool> Confirm(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("console.log", "test of console log using IJSRuntimeExtensionMethods");
            return await js.InvokeAsync<bool>("confirm", message);
        }
    }
}
