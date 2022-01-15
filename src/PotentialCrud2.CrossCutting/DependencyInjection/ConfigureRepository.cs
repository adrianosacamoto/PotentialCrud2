using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PotentialCrud2.Data.Context;
using PotentialCrud2.Data.Implementations;
using PotentialCrud2.Data.Repository;
using PotentialCrud2.Domain.Interfaces;
using PotentialCrud2.Domain.Repository;

namespace PotentialCrud2.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IDesenvolvedorRepository, DesenvolvedorImplementation>();

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "MYSQL".ToLower())
            {
                serviceCollection.AddDbContext<MyContext>
                (
                    options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                );
            }
        }
    }
}
