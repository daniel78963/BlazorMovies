using BlazorMovies.Client;
using BlazorMovies.Client.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app"); //coloca el App.razor
builder.RootComponents.Add<HeadOutlet>("head::after"); //Permite adicionar cabeceras en el head del index.html, y el after, es que lo coloca de �ltimo

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddSingleton<ServicesSingleton>();
//builder.Services.AddSingleton<ServicesTransient>();
ConfigureServices(builder.Services);

await builder.Build().RunAsync();

void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<ServicesSingleton>();
    services.AddTransient<ServicesTransient>();
    services.AddSingleton<IRepository, Repository>();
}