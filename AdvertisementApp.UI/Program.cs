using AdvertisementApp.Business.DependencyResolvers.Microsoft;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();