using CoffeeShop.Web;
using CoffeeShop.Web.Services;
using CoffeeShop.Web.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7151/") });
builder.Services.AddScoped<ICoffeeService, CoffeeService>();

await builder.Build().RunAsync();
