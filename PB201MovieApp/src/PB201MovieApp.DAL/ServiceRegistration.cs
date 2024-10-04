using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PB201MovieApp.Core.Repositories;
using PB201MovieApp.DAL.Contexts;
using PB201MovieApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB201MovieApp.DAL
{
    public static class ServiceRegistration
    {
        public static void AddRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();

            services.AddDbContext<AppDBContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
        }
    }

}
