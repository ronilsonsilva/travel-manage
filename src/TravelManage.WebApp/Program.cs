using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Reflection;
using TravelManage.WebApp;
using TravelManage.WebApp.AutoMapper;
using TravelManage.WebApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient();


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);




//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IMotoristaServices, MotoristaServices>();
builder.Services.AddScoped<IPassageiroServices, PassageiroServices>();
builder.Services.AddScoped<IProprietarioServices, ProprietarioServices>();
builder.Services.AddScoped<ITipoPagamentoServices, TipoPagamentoServices>();
builder.Services.AddScoped<IVeiculoServices, VeiculoServices>();
builder.Services.AddScoped<IViagemServices, ViagemServices>();
builder.Services.AddSingleton(sp => new RestClient(new HttpClient { BaseAddress = new Uri("https://localhost:44345/api") }));


await builder.Build().RunAsync();
