using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using WebApp.UI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var mapperConfiguration = new MapperConfiguration(configuration =>
{
    configuration.AddProfile(new MapperProfile());
});
var mapper = mapperConfiguration.CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiBaseUrl") ?? "")
});
builder.Services.AddFluentUIComponents();

await builder.Build().RunAsync();
