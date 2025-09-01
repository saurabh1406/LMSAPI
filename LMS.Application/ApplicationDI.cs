using FluentValidation;
using LMS.Application.Common.Mappings;
using LMS.Application.Common.Validator;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            // Register your application services here
            // Example: services.AddScoped<IYourService, YourServiceImplementation>();
            services.AddMediatR(cfg =>cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(typeof(BookDetailsMapping).Assembly);

            // Register FluentValidation
            services.AddValidatorsFromAssemblyContaining<CreateUserValidatior>();

            // Register Validation Behavior
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
