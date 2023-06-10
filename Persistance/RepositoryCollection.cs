using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class RepositoryCollection
    {
        public static IServiceCollection AddMyRepos(this IServiceCollection services)
        {
            services.AddSingleton<ICarRepository, CarRepository>();

            return services;
        }
    }
}
