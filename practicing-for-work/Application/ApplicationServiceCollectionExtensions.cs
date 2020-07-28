using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Reflection;
using Practicing_For_Work.Application.Contracts.IService;
using Application.Service;
using Arch.EntityFrameworkCore.UnitOfWork;

namespace Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IHomeService, HomeService>();

            return services;
        }
    }
}
