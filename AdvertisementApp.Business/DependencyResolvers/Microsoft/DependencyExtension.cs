using AutoMapper;
using FluentValidation;
using AdvertisementApp.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos.ProvidedServiceDtos;
using AdvertisementApp.Business.ValidationRules.FluentValidation;
using AdvertisementApp.Business.Mappings.AutoMapper;
using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Business.Services;
using AdvertisementApp.Dtos.AdvertisementDtos;
using AdvertisementApp.Dtos.AppUserDtos;

namespace AdvertisementApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension 
    { 
        // public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<AdvertisementContext>(opt => 
            {
                // using for connectionstring in appsettings.json. not working
                //opt.UseSqlServer(configuration.GetConnectionString("Local"));

                opt.UseSqlServer("server = (localdb)\\mssqllocaldb; database = AdvertisementAppDb; integrated security = true;");
            });

            var mapperConfiguration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new ProvidedServiceProfile());
                opt.AddProfile(new AdvertisementProfile());
                opt.AddProfile(new AppUserProfile());
            });

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);
            
            // add interface dependency
            services.AddScoped<IUow, Uow>();

            // add validator interface dependencies
            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();

            services.AddScoped<IProvidedServiceService, ProvidedServiceService>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IAppUserService, AppUserService>();
        }
    }
}
