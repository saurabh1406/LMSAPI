using LMS.Infrasturcture.Repository;
using LMSAPI.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrasturcture
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            
            services.AddDbContext<LMSDbContext>(options =>
            {
                options.UseSqlServer("Server=.;Database=LMS;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true;Integrated Security=True;");
            });
            services.AddScoped<IBookDetails, BookDetailsReposity>();
            services.AddScoped<IMemberDetails, MemberDetailsReposity>();
            return services;
        }
    }
}
