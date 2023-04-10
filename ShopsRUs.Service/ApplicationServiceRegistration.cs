using Microsoft.Extensions.DependencyInjection;
using ShopsRUs.Core.Services;
using ShopsRUs.Service.Mapping;
using ShopsRUs.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Service
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapProfile));
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }
    }
}
