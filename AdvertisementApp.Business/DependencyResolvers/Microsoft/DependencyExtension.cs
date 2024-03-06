using AutoMapper;
using AdvertisementApp.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AdvertisementApp.DataAccess.UnitOfWork;
using FluentValidation;
using AdvertisementApp.Dtos.ProvidedServiceDtos;
using AdvertisementApp.Business.ValidationRules.FluentValidation;
using AdvertisementApp.Business.Mappings.AutoMapper;
using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Business.Services;

namespace AdvertisementApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension 
    { 
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt => 
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });

            var mapperConfiguration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new ProvidedServiceProfile());
            });

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);
            
            // add interface dependency
            services.AddScoped<IUow, Uow>();

            // add validator interface dependencies
            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();

            services.AddScoped<IProvidedServiceService, ProvidedServiceService>();
        }
    }
}
