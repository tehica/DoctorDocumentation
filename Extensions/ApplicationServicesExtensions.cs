using DoctorDoc1.interfaces;
using DoctorDoc1.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IEmailSender, EmailSender>();

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IHospitalRepository, HospitalRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();

            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
