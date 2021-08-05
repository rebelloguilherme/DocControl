using DocControl.Application.Interfaces;
using DocControl.Application.Mappings;
using DocControl.Application.Services;
using DocControl.Domain.Interfaces;
using DocControl.Infra.Data.Context;
using DocControl.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DocControl.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) //Extension method
        {
            //Registering context
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefautConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext) //migration will be located where my ApplycationDbContext is.
                .Assembly.FullName)));

            services.AddScoped<IDocumentRepository, DocumentRepository>(); //Registering Repository


            services.AddScoped<IDocumentService, DocumentService>(); //Registering Services


            services.AddAutoMapper(typeof(DomainToDTOMappingProfile)); //Registering AutoMapper

            var myhandlers = AppDomain.CurrentDomain.Load("DocControl.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}
