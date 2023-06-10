using Application.Common.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public static class ServiceCollection
{
    public static IServiceCollection AddMyServices(this IServiceCollection services)
    {
        services.AddSingleton<ICarService, CarService>();

        return services;
    }
}
