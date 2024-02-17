using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorMovies.Client.Pages
{
    public partial class Counter
    {
        [Inject] ServicesSingleton singleton { get; set; } = null!;
        [Inject] ServicesTransient transient { get; set; } = null!;
        [Inject] IJSRuntime js { get; set; } = null!;

        IJSObjectReference? module; 

        //Miembro de instacia
        private int currentCount = 0;
        //Static
        private static int currentCountStatic = 0;

        [JSInvokable]
        public async Task IncrementCount()
        {
            //Con esta línea, se va a descargar el archivo de Javascript y no antes con toda la app
            module = await js.InvokeAsync<IJSObjectReference>("import", "./js/Counter.js");
            await module.InvokeVoidAsync("showAlert", "The JS file has been loaded");

            currentCount++;
            currentCountStatic = currentCount;
            singleton.Value = currentCount;
            transient.Value = currentCount;
            await js.InvokeVoidAsync("testNETStatic");
        }

        private async Task IncrementCountJS()
        {
            await js.InvokeVoidAsync("testNETInstance",
                DotNetObjectReference.Create(this)); //Estamos creando una referencia a un objeto de .NET
                                                     //con el this. le estamos enviando el contexto donde me encuentro, es decir, la instancia de la clase Counter.cs
        }

        [JSInvokable]
        public static Task<int> GetCurrentCount()
        {
            return Task.FromResult(currentCountStatic);
        }
    }
}
