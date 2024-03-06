var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDependencies(configuration);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();