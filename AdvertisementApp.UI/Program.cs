using AdvertisementApp.Business.DependencyResolvers.Microsoft;
using AdvertisementApp.Business.Helpers;
using AdvertisementApp.UI.Mappings.AutoMapper;
using AdvertisementApp.UI.Models;
using AdvertisementApp.UI.ValidationRules.FluentValidation;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;

// create web application
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies();
builder.Services.AddTransient<IValidator<AppUserCreateModel>, AppUserCreateModelValidator>();
builder.Services.AddControllersWithViews();

// custom cookie based authentication. auth. without .Net Identity
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt => 
{
    opt.Cookie.Name = "AdvertisementAppCookie";
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.ExpireTimeSpan = TimeSpan.FromDays(10);
    opt.LoginPath = new PathString("/Account/SignIn");
    opt.LogoutPath = new PathString("/Account/LogOut");
    opt.AccessDeniedPath = new PathString("/Account/AccessDenied");
});

// adding profiles from ProfileHelper
var profiles = ProfileHelper.GetProfiles();
profiles.Add(new AppUserCreateModelProfile());

var mapperConfiguration = new MapperConfiguration(opt =>
{
    opt.AddProfiles(profiles);
});

var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

// build web application
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();