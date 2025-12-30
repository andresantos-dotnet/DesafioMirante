using Application;
using Domain.Interfaces;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Domain.Entities;
using Infra.Repository;
using Infra.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        
        public static void ConfigureDependencies(IServiceCollection serviceCollection)
        {
            var connectionString = "Server=SQL9001.site4now.net;Database=db_aa3182_bemnaweb;User Id=db_aa3182_bemnaweb_admin;Password=Mirante@2026;Integrated Security=False;Pooling=true";
            // Applications
            serviceCollection.AddScoped<IActivityApplication, ActivityApplication>();
            //Repositories
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            //Contexts
            serviceCollection.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connectionString));

            // Registra o Unit of Work
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
