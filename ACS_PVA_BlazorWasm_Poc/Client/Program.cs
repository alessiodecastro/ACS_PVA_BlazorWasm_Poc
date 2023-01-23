using ACS_PVA_BlazorWasm_Poc.Client;
using ACS_PVA_BlazorWasm_Poc.Client.Services.AcsService;
using ACS_PVA_BlazorWasm_Poc.Client.Services.ProductService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IACSService, ACSService>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
